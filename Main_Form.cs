using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Threading;
using System.Runtime.CompilerServices;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace JW_Secretario
{
    public partial class Main_Form : Form
    {
        private static Excel.Application ExcelApp;
        private static Excel.Workbook ExcelBooks = null;
        private static Excel.Sheets ExcelSheets;
        //private static Excel.Worksheet Main_Sheet;
        //private static Excel.Worksheet[] Month_Sheet = new Excel.Worksheet[12];
        private static List<Excel.Worksheet> Month_Sheet_List = new List<Excel.Worksheet>();
        public static int Initial_Year = 19;
        public static string[] Months = new string[] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        public static List<string> Filter_Values = new List<string> { "Todos", "Publicador"};
        private static Excel.Range Excel_Range;
        private static object[,] cellValue_1 = null;
        public static bool excel_open = false;
        Thread Excel_Thread;
        Thread Save_Excel_Thread;
        public static string File_Path = Application.StartupPath + "\\\\DataBase.xlsx";
        public static List<string> sheet_names = new List<string>();
        public static List<Publicador> All_Pub_List = new List<Publicador>();
        public static BindingList<Publicador> Show_Pub_Data_List = new BindingList<Publicador>();
        public static bool pending_grid_refresh = false;
        public static bool pending_filters_refresh = false;
        public static int Selected_Month = 0;
        public static short Max_Number_Groups = 1;
        public static DataGridViewCell Previous_cell;
        public static Publicador_Total Total_Pub = new Publicador_Total();
        public static Publicador_Total Total_Aux = new Publicador_Total();
        public static Publicador_Total Total_Reg = new Publicador_Total();
        public static Publicador_Total Grand_Total = new Publicador_Total();
        public static BindingList<Publicador_Total> List_Totals = new BindingList<Publicador_Total>();

        public enum Categoria
        {
            Null,
            Publicador,
            Auxiliar,
            Regular
        }
        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            Excel_Thread = new Thread(() => Excel_Handler());
            Save_Excel_Thread = new Thread(() => Save_Excel_Handler());
            Excel_Thread.Start();
            Refresh_timer.Start();
            List_Totals.Add(Total_Pub);
            List_Totals.Add(Total_Aux);
            List_Totals.Add(Total_Reg);
            List_Totals.Add(Grand_Total);
        }

        private void Main_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Excel_Thread.Abort();
            if (excel_open)
            {
                ExcelBooks.Close(0);
                ExcelApp.Quit();
            }
            for (int i = 0; i < Month_Sheet_List.Count; i++)
            {
                Marshal.ReleaseComObject(Month_Sheet_List[i]);
            }
            Marshal.ReleaseComObject(ExcelBooks);
            Marshal.ReleaseComObject(ExcelApp);
        }

        public void Excel_Handler()
        {
            Open_Excel();
            //Close_Excel();
        }

        public void Open_Excel()
        {
            Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;
            ExcelApp = new Excel.Application();
            excel_open = true;
            ExcelBooks = ExcelApp.Workbooks.Open(File_Path, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, 1, 0);
            ExcelSheets = ExcelBooks.Worksheets;
            foreach (Excel.Worksheet worksheet in ExcelBooks.Worksheets)
            {
                Month_Sheet_List.Add(worksheet);
                sheet_names.Add(worksheet.Name);
            }
            Read_Data_Worksheet();
            pending_filters_refresh = true;
        }

        public void Read_Data_Worksheet()
        {
            All_Pub_List.Clear();
            Excel_Range = Month_Sheet_List[Selected_Month].get_Range("A1", "H200");
            cellValue_1 = (object[,])Excel_Range.get_Value();
            int i = 2;
            Publicador aux_pub;
            while (i < 200)
            {
                aux_pub = new Publicador();
                if (cellValue_1[i, 1] != null)
                {
                    aux_pub.Nombre = cellValue_1[i, 1].ToString();
                    aux_pub.Publicaciones = Convert.ToInt16(cellValue_1[i, 2].ToString());
                    aux_pub.Videos = Convert.ToInt16(cellValue_1[i, 3].ToString());
                    aux_pub.Horas = Convert.ToInt16(cellValue_1[i, 4].ToString());
                    aux_pub.Revisitas = Convert.ToInt16(cellValue_1[i, 5].ToString());
                    aux_pub.Estudios = Convert.ToInt16(cellValue_1[i, 6].ToString());
                    aux_pub.Grupo = Convert.ToInt16(cellValue_1[i, 7].ToString());
                    switch (cellValue_1[i, 8].ToString())
                    {
                        case "Publicador":
                            {
                                aux_pub.Categoria = Categoria.Publicador;
                                break;
                            }
                        case "Auxiliar":
                            {
                                aux_pub.Categoria = Categoria.Auxiliar;
                                break;
                            }
                        case "Regular":
                            {
                                aux_pub.Categoria = Categoria.Regular;
                                break;
                            }
                        case "Null":
                            {
                                aux_pub.Categoria = Categoria.Null;
                                break;
                            }
                    }

                    All_Pub_List.Add(aux_pub);
                    i++;
                }
                else
                {
                    break;
                }
            }
            Max_Number_Groups = (short)All_Pub_List[All_Pub_List.Count - 1].Grupo;
            for (short it = 1; it <= Max_Number_Groups; it++)
            {
                Filter_Values.Add("Grupo " + it.ToString());
            }
            pending_grid_refresh = true;
        }

        public void Close_Excel()
        {
            ExcelBooks.Close(0);
            ExcelApp.Quit();
            excel_open = false;
        }

        private void Refresh_timer_Tick(object sender, EventArgs e)
        {
            if (pending_filters_refresh)
            {
                Mes_cmbx.Items.Clear();
                Cmb_Filter.DataSource = Filter_Values;
                for (int i = 0; i < sheet_names.Count; i++)
                {
                    Mes_cmbx.Items.Add(sheet_names[i]);
                }
                if (Mes_cmbx.SelectedIndex < 0)
                {
                    Mes_cmbx.SelectedIndex = 0;
                }
                pending_filters_refresh = false;
            }
            if (pending_grid_refresh)
            {
                Cmb_Filter.DataSource = Filter_Values;
                Main_Data_gridview.DataSource = Show_Pub_Data_List;
                Main_Data_gridview.Refresh();
                Main_Data_gridview.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                foreach (DataGridViewRow row in Main_Data_gridview.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        Set_Color_Result_DataGrid(cell);
                    }
                }
                Totals_Grid_View.DataSource = List_Totals;
                Totals_Grid_View.Refresh();
                Totals_Grid_View.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                pending_grid_refresh = false;
            }
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            Save_Excel_Thread.Start();
        }

        /*@ToDo save all excel data*/
        public void Save_Excel_Handler()
        {
            for (int i = 1; i <= All_Pub_List.Count; i++)
            {
                Month_Sheet_List[0].Cells[i + 1, 1] = All_Pub_List[i - 1].Nombre;
                Month_Sheet_List[0].Cells[i + 1, 2] = All_Pub_List[i - 1].Publicaciones;
                Month_Sheet_List[0].Cells[i + 1, 3] = All_Pub_List[i - 1].Videos;
                Month_Sheet_List[0].Cells[i + 1, 4] = All_Pub_List[i - 1].Horas;
                Month_Sheet_List[0].Cells[i + 1, 5] = All_Pub_List[i - 1].Revisitas;
                Month_Sheet_List[0].Cells[i + 1, 6] = All_Pub_List[i - 1].Estudios;
                Month_Sheet_List[0].Cells[i + 1, 7] = All_Pub_List[i - 1].Grupo;
                Month_Sheet_List[0].Cells[i + 1, 8] = All_Pub_List[i - 1].Categoria.ToString();
            }
            ExcelBooks.Save();
        }

        private void Mes_cmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selected_Month = Mes_cmbx.SelectedIndex;
            Read_Data_Worksheet();
            Enhance_Filter();
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Excel.Worksheet sheet = Month_Sheet_List[Month_Sheet_List.Count-1];
            sheet.Copy(Type.Missing, sheet);
            var copySheetIndex = sheet.Index + 1;

            Excel.Worksheet copySheet = ExcelSheets.get_Item(copySheetIndex);
            int aux_mes = 99;
            for (int i = 0; i < Months.Length; i++)
            {
                if (ExcelBooks.Sheets[ExcelBooks.Sheets.Count - 1].Name.Contains(Months[i]))
                {
                    if ((i + 1) == 12)
                    {
                        aux_mes = 0;
                    }
                    else
                    {
                        aux_mes = i + 1;
                    }
                    break;
                }
            }

            copySheet.Name = Months[aux_mes] + " " + Initial_Year.ToString();
            ExcelBooks.Save();
            Month_Sheet_List.Add(copySheet);
            sheet_names.Add(copySheet.Name);
            Read_Data_Worksheet();
            pending_grid_refresh = true;
        }

        private void Data_gridview_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = false;
        }

        private void Set_Color_Result_DataGrid(DataGridViewCell cell)
        {
            if (cell.Value != null)
            {
                string str = cell.Value.ToString();
                switch (str)
                {
                    case "Publicador":
                        {
                            cell.Style.BackColor = Color.LightSkyBlue;
                            break;  
                        }
                    case "Auxiliar":
                        {
                            cell.Style.BackColor = Color.LightSeaGreen;
                            break;
                        }
                    case "Regular":
                        {
                            cell.Style.BackColor = Color.LightYellow;
                            break;
                        }
                    case "Null":
                        {
                            cell.Style.BackColor = Color.Gray;
                            break;
                        }
                    default:
                        {
                            if (int.TryParse(str, out int result))
                            {
                                //check averages!
                            }
                            break;
                        }
                }
            }
        }

        private void Cmb_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_Filter.Enabled = false;
            if (Cmb_Filter.SelectedItem.Equals("Publicador"))
            {
                Txt_Publicador.Enabled = true;
                List<string> Aux_List = new List<string>();
                for(int i =0; i < All_Pub_List.Count; i++)
                {
                    Aux_List.Add(All_Pub_List[i].Nombre);
                }
                AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
                autocomplete.AddRange(Aux_List.ToArray());
                Txt_Publicador.AutoCompleteCustomSource = autocomplete;
                //Get Publicador Activity
            }
            else
            {
                Txt_Publicador.Enabled = false;
                Enhance_Filter();
            }
            Cmb_Filter.Enabled = true;
        }

        private void Chkbx_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Chk_Box = (CheckBox)sender;
            if (Chk_Box.Name.Equals(Chk_All.Name))
            {
                if (Chk_Box.Checked)
                {
                    Chk_Pub.Checked = true;
                    Chk_Aux.Checked = true;
                    Chk_Reg.Checked = true;
                    Chk_Nul.Checked = true;
                }
            }
            else
            {
                if (!Chk_Box.Checked)
                {
                    Chk_All.Checked = false;
                }
            }
            if (Chk_Pub.Checked && Chk_Aux.Checked && Chk_Reg.Checked && Chk_Nul.Checked)
            {
                Chk_All.Checked = true;
            }
            Enhance_Filter();
        }

        public void Enhance_Filter()
        {
            Show_Pub_Data_List.Clear();
            if(Cmb_Filter.SelectedIndex == 0) //Todos
            {
                for (int i = 0; i < All_Pub_List.Count; i++)
                {
                    Show_Pub_Data_List.Add(All_Pub_List[i]);
                }
            }
            else //Por Grupo
            {
                string str = Cmb_Filter.SelectedItem.ToString();
                if (int.TryParse(str.Substring(str.Length - 1), out int result))
                {
                    for (int i = 0; i < All_Pub_List.Count; i++)
                    {
                        if (All_Pub_List[i].Grupo == result)
                        {
                            Show_Pub_Data_List.Add(All_Pub_List[i]);
                        }
                    }
                }
            }
            if (!Chk_All.Checked)
            {
                List<int> To_Be_Removed = new List<int>();
                for (int i = 0; i < Show_Pub_Data_List.Count; i++)
                {
                    if ((!Chk_Pub.Checked) && (Show_Pub_Data_List[i].Categoria == Categoria.Publicador))
                    {
                        To_Be_Removed.Add(i);
                    }
                    else if ((!Chk_Aux.Checked) && (Show_Pub_Data_List[i].Categoria == Categoria.Auxiliar))
                    {
                        To_Be_Removed.Add(i);
                    }
                    else if ((!Chk_Reg.Checked) && (Show_Pub_Data_List[i].Categoria == Categoria.Regular))
                    {
                        To_Be_Removed.Add(i);
                    }
                    else if ((!Chk_Nul.Checked) && (Show_Pub_Data_List[i].Categoria == Categoria.Null))
                    {
                        To_Be_Removed.Add(i);
                    }
                }
                for(int i = To_Be_Removed.Count -1; i >= 0; i--)
                {
                    Show_Pub_Data_List.RemoveAt(To_Be_Removed[i]);
                }
            }

            Calculate_Totals();
        }

        private void Data_gridview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string name = "";
            DataGridViewCell cell = Main_Data_gridview.CurrentCell;
            name = Main_Data_gridview[0, cell.RowIndex].Value.ToString();
            Publicador aux_pub = new Publicador
            {
                Nombre = name
            };
            int index = All_Pub_List.FindIndex(x => x.Nombre.Contains(aux_pub.Nombre));
            int value = 0;
            DataGridViewRow row = Main_Data_gridview.CurrentRow;
            int.TryParse(row.Cells[1].Value.ToString(), out value);
            aux_pub.Publicaciones = value;
            int.TryParse(row.Cells[2].Value.ToString(), out value);
            aux_pub.Videos = value;
            int.TryParse(row.Cells[3].Value.ToString(), out value);
            aux_pub.Horas = value;
            int.TryParse(row.Cells[4].Value.ToString(), out value);
            aux_pub.Revisitas = value;
            int.TryParse(row.Cells[5].Value.ToString(), out value);
            aux_pub.Estudios = value;
            int.TryParse(row.Cells[6].Value.ToString(), out value);
            aux_pub.Grupo = value;
            switch(row.Cells[7].Value.ToString())
            {
                case "Null":
                    {
                        aux_pub.Categoria = Categoria.Null;
                        break;
                    }
                case "Publicador":
                    {
                        aux_pub.Categoria = Categoria.Publicador;
                        break;
                    }
                case "Auxiliar":    
                    {
                        aux_pub.Categoria = Categoria.Auxiliar;
                        break;
                    }
                case "Regular":
                    {
                        aux_pub.Categoria = Categoria.Regular;
                        break;
                    }
            }
            if (aux_pub.Horas == 0)
            {
                aux_pub.Categoria = Categoria.Null;
            }
            All_Pub_List[index] = aux_pub;
            foreach (DataGridViewCell aux_Cell in row.Cells)
            {
                Set_Color_Result_DataGrid(aux_Cell);
            }
            Calculate_Totals();
        }

        private void Txt_Publicador_TextChanged(object sender, EventArgs e)
        {
            Publicador aux_pub = new Publicador
            {
                Nombre = Txt_Publicador.Text
            };
            int index = All_Pub_List.FindIndex(x => x.Nombre.Contains(aux_pub.Nombre));
            if (index >= 0)
            {
                Show_Pub_Data_List.Clear();
                Show_Pub_Data_List.Add(All_Pub_List[index]);
                pending_grid_refresh = true;
            }
        }

        public async void Calculate_Totals()
        {
            Total_Pub.Clear();
            Total_Aux.Clear();
            Total_Reg.Clear();
            Grand_Total.Clear();
            for(int i=0; i< Show_Pub_Data_List.Count; i++)
            {
                Publicador aux_pub = Show_Pub_Data_List[i];
                switch (Show_Pub_Data_List[i].Categoria)
                {
                    case Categoria.Publicador:
                        {
                            Total_Pub.Informan++;
                            Total_Pub.Videos += aux_pub.Videos;
                            Total_Pub.Publicaciones += aux_pub.Publicaciones;
                            Total_Pub.Horas += aux_pub.Horas;
                            Total_Pub.Revisitas += aux_pub.Revisitas;
                            Total_Pub.Estudios += aux_pub.Estudios;
                            Total_Pub.Categoria = Categoria.Publicador;
                            break;
                        }
                    case Categoria.Auxiliar:
                        {
                            Total_Aux.Informan++;
                            Total_Aux.Videos += aux_pub.Videos;
                            Total_Aux.Publicaciones += aux_pub.Publicaciones;
                            Total_Aux.Horas += aux_pub.Horas;
                            Total_Aux.Revisitas += aux_pub.Revisitas;
                            Total_Aux.Estudios += aux_pub.Estudios;
                            Total_Aux.Categoria = Categoria.Auxiliar;
                            break;
                        }
                    case Categoria.Regular:
                        {
                            Total_Reg.Informan++;
                            Total_Reg.Videos += aux_pub.Videos;
                            Total_Reg.Publicaciones += aux_pub.Publicaciones;
                            Total_Reg.Horas += aux_pub.Horas;
                            Total_Reg.Revisitas += aux_pub.Revisitas;
                            Total_Reg.Estudios += aux_pub.Estudios;
                            Total_Reg.Categoria = Categoria.Regular;
                            break;
                        }
                }
            }
            Total_Pub.Nombre = "Publicador";
            Total_Aux.Nombre = "Auxiliar";
            Total_Reg.Nombre = "Regular";
            Grand_Total.Nombre = "Totales";
            Grand_Total.Publicaciones = Total_Pub.Publicaciones + Total_Aux.Publicaciones + Total_Reg.Publicaciones;
            Grand_Total.Videos = Total_Pub.Videos + Total_Aux.Videos + Total_Reg.Videos;
            Grand_Total.Horas = Total_Pub.Horas + Total_Aux.Horas + Total_Reg.Horas;
            Grand_Total.Revisitas = Total_Pub.Revisitas + Total_Aux.Revisitas + Total_Reg.Revisitas;
            Grand_Total.Estudios = Total_Pub.Estudios + Total_Aux.Estudios + Total_Reg.Estudios;
            Grand_Total.Informan = Total_Pub.Informan + Total_Aux.Informan + Total_Reg.Informan;

            if (Chk_Promedios.Checked)
            {
                Set_Prom_Totals();
            }
            await Task.Delay(50);
            pending_grid_refresh = true;
        }

        public void Set_Prom_Totals()
        {
            if (Total_Pub.Informan > 0)
            {
                Total_Pub.Videos /= Total_Pub.Informan;
                Total_Pub.Publicaciones /= Total_Pub.Informan;
                Total_Pub.Horas /= Total_Pub.Informan;
                Total_Pub.Revisitas /= Total_Pub.Informan;
                Total_Pub.Estudios /= Total_Pub.Informan;
            }
            if (Total_Aux.Informan > 0)
            {
                Total_Aux.Videos /= Total_Aux.Informan;
                Total_Aux.Publicaciones /= Total_Aux.Informan;
                Total_Aux.Horas /= Total_Aux.Informan;
                Total_Aux.Revisitas /= Total_Aux.Informan;
                Total_Aux.Estudios /= Total_Aux.Informan;
            }
            if (Total_Reg.Informan > 0)
            {
                Total_Reg.Videos /= Total_Reg.Informan;
                Total_Reg.Publicaciones /= Total_Reg.Informan;
                Total_Reg.Horas /= Total_Reg.Informan;
                Total_Reg.Revisitas /= Total_Reg.Informan;
                Total_Reg.Estudios /= Total_Reg.Informan;
            }
            if (Grand_Total.Informan > 0)
            {
                Grand_Total.Videos /= Grand_Total.Informan;
                Grand_Total.Publicaciones /= Grand_Total.Informan;
                Grand_Total.Horas /= Grand_Total.Informan;
                Grand_Total.Revisitas /= Grand_Total.Informan;
                Grand_Total.Estudios /= Grand_Total.Informan;
            }
        }

        private void Chk_Promedios_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Promedios.Checked)
            {
                Set_Prom_Totals();
                pending_grid_refresh = true;
            }
            else
            {
                Calculate_Totals();
            }
        }

        private void Data_gridview_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = Main_Data_gridview.CurrentCell;
            if (cell != null)
            {
                string name_selected = Main_Data_gridview[0, cell.RowIndex].Value.ToString();
                Lbl_Selected_Pub.Text = name_selected;

            }
        }
    }
}
