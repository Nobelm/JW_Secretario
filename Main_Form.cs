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
        private static Excel.Range Excel_Range;
        private static object[,] cellValue_1 = null;
        public static bool excel_open = false;
        Thread Excel_Thread;
        Thread Save_Excel_Thread;
        public static string File_Path = Application.StartupPath + "\\\\DataBase.xlsx";
        public static List<string> sheet_names = new List<string>();
        public static BindingList<Publicador> List_Pub = new BindingList<Publicador>();
        public static bool pending_refresh = false;
        public static int Selected_Month = 0;

        public enum Categoria
        {
            Ref_Void,
            Publicador,
            P_Auxiliar,
            P_Regular
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
            int mes = 0;
            foreach (Excel.Worksheet worksheet in ExcelBooks.Worksheets)
            {
                Month_Sheet_List.Add(worksheet);
                sheet_names.Add(worksheet.Name);
                mes++;
            }
            pending_refresh = true;
        }

        public void Read_Data_Worksheet()
        {
            List_Pub.Clear();
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
                        case "P_Auxiliar":
                            {
                                aux_pub.Categoria = Categoria.P_Auxiliar;
                                break;
                            }
                        case "P_Regular":
                            {
                                aux_pub.Categoria = Categoria.P_Regular;
                                break;
                            }
                    }

                    List_Pub.Add(aux_pub);
                    i++;
                }
                else
                {
                    break;
                }
            }
        }


        public void Close_Excel()
        {
            ExcelBooks.Close(0);
            ExcelApp.Quit();
            excel_open = false;
        }

        private void Refresh_timer_Tick(object sender, EventArgs e)
        {
            if (pending_refresh)
            {
                Mes_cmbx.Items.Clear();
                for (int i = 0; i < sheet_names.Count; i++)
                {
                    Mes_cmbx.Items.Add(sheet_names[i]);
                }
                if (Mes_cmbx.SelectedIndex < 0)
                {
                    Mes_cmbx.SelectedIndex = 0;
                }
                Data_gridview.DataSource = List_Pub;
                Data_gridview.Refresh();
                Data_gridview.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                pending_refresh = false;
            }
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            Save_Excel_Thread.Start();
        }

        /*@ToDo save all excel data*/
        public void Save_Excel_Handler()
        {
            for (int i = 1; i <= List_Pub.Count; i++)
            {
                Month_Sheet_List[0].Cells[i + 1, 1] = List_Pub[i - 1].Nombre;
                Month_Sheet_List[0].Cells[i + 1, 2] = List_Pub[i - 1].Publicaciones;
                Month_Sheet_List[0].Cells[i + 1, 3] = List_Pub[i - 1].Videos;
                Month_Sheet_List[0].Cells[i + 1, 4] = List_Pub[i - 1].Horas;
                Month_Sheet_List[0].Cells[i + 1, 5] = List_Pub[i - 1].Revisitas;
                Month_Sheet_List[0].Cells[i + 1, 6] = List_Pub[i - 1].Estudios;
                Month_Sheet_List[0].Cells[i + 1, 7] = List_Pub[i - 1].Grupo;
                Month_Sheet_List[0].Cells[i + 1, 8] = List_Pub[i - 1].Categoria.ToString();
            }
            ExcelBooks.Save();
        }

        private void Mes_cmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selected_Month = Mes_cmbx.SelectedIndex;
            Read_Data_Worksheet();
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
            pending_refresh = true;
        }
    }
}
