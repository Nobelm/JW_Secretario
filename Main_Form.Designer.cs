namespace JW_Secretario
{
    partial class Main_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Main_Data_gridview = new System.Windows.Forms.DataGridView();
            this.Refresh_timer = new System.Windows.Forms.Timer(this.components);
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.Mes_cmbx = new System.Windows.Forms.ComboBox();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.Chart_Publicaciones = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Cmb_Filter = new System.Windows.Forms.ComboBox();
            this.Chk_Pub = new System.Windows.Forms.CheckBox();
            this.Chk_Aux = new System.Windows.Forms.CheckBox();
            this.Chk_Reg = new System.Windows.Forms.CheckBox();
            this.Chk_Nul = new System.Windows.Forms.CheckBox();
            this.Chk_All = new System.Windows.Forms.CheckBox();
            this.Txt_Publicador = new System.Windows.Forms.TextBox();
            this.Totals_Grid_View = new System.Windows.Forms.DataGridView();
            this.Chk_Promedios = new System.Windows.Forms.CheckBox();
            this.Lbl_Selected_Pub = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Prom_Grid_View = new System.Windows.Forms.DataGridView();
            this.Pub_Grid_View = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Main_Data_gridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Publicaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Totals_Grid_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Prom_Grid_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pub_Grid_View)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_Data_gridview
            // 
            this.Main_Data_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Main_Data_gridview.Location = new System.Drawing.Point(12, 175);
            this.Main_Data_gridview.Name = "Main_Data_gridview";
            this.Main_Data_gridview.Size = new System.Drawing.Size(709, 405);
            this.Main_Data_gridview.TabIndex = 0;
            this.Main_Data_gridview.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Data_gridview_CellEndEdit);
            this.Main_Data_gridview.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Data_gridview_DataError);
            this.Main_Data_gridview.SelectionChanged += new System.EventHandler(this.Data_gridview_SelectionChanged);
            // 
            // Refresh_timer
            // 
            this.Refresh_timer.Enabled = true;
            this.Refresh_timer.Interval = 500;
            this.Refresh_timer.Tick += new System.EventHandler(this.Refresh_timer_Tick);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Location = new System.Drawing.Point(55, 103);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_Guardar.TabIndex = 1;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Mes_cmbx
            // 
            this.Mes_cmbx.FormattingEnabled = true;
            this.Mes_cmbx.Location = new System.Drawing.Point(79, 60);
            this.Mes_cmbx.Name = "Mes_cmbx";
            this.Mes_cmbx.Size = new System.Drawing.Size(121, 21);
            this.Mes_cmbx.TabIndex = 2;
            this.Mes_cmbx.SelectedIndexChanged += new System.EventHandler(this.Mes_cmbx_SelectedIndexChanged);
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.Location = new System.Drawing.Point(136, 103);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(75, 23);
            this.btn_nuevo.TabIndex = 3;
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.Btn_nuevo_Click);
            // 
            // Chart_Publicaciones
            // 
            chartArea1.Name = "ChartArea1";
            this.Chart_Publicaciones.ChartAreas.Add(chartArea1);
            this.Chart_Publicaciones.Location = new System.Drawing.Point(727, 455);
            this.Chart_Publicaciones.Name = "Chart_Publicaciones";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.Chart_Publicaciones.Series.Add(series1);
            this.Chart_Publicaciones.Size = new System.Drawing.Size(248, 181);
            this.Chart_Publicaciones.TabIndex = 4;
            // 
            // Cmb_Filter
            // 
            this.Cmb_Filter.FormattingEnabled = true;
            this.Cmb_Filter.Location = new System.Drawing.Point(272, 12);
            this.Cmb_Filter.Name = "Cmb_Filter";
            this.Cmb_Filter.Size = new System.Drawing.Size(121, 21);
            this.Cmb_Filter.TabIndex = 5;
            this.Cmb_Filter.SelectedIndexChanged += new System.EventHandler(this.Cmb_Filter_SelectedIndexChanged);
            // 
            // Chk_Pub
            // 
            this.Chk_Pub.AutoSize = true;
            this.Chk_Pub.Checked = true;
            this.Chk_Pub.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_Pub.Location = new System.Drawing.Point(272, 70);
            this.Chk_Pub.Name = "Chk_Pub";
            this.Chk_Pub.Size = new System.Drawing.Size(87, 17);
            this.Chk_Pub.TabIndex = 6;
            this.Chk_Pub.Text = "Publicadores";
            this.Chk_Pub.UseVisualStyleBackColor = true;
            this.Chk_Pub.CheckedChanged += new System.EventHandler(this.Chkbx_CheckedChanged);
            // 
            // Chk_Aux
            // 
            this.Chk_Aux.AutoSize = true;
            this.Chk_Aux.Checked = true;
            this.Chk_Aux.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_Aux.Location = new System.Drawing.Point(272, 96);
            this.Chk_Aux.Name = "Chk_Aux";
            this.Chk_Aux.Size = new System.Drawing.Size(59, 17);
            this.Chk_Aux.TabIndex = 7;
            this.Chk_Aux.Text = "Auxiliar";
            this.Chk_Aux.UseVisualStyleBackColor = true;
            this.Chk_Aux.CheckedChanged += new System.EventHandler(this.Chkbx_CheckedChanged);
            // 
            // Chk_Reg
            // 
            this.Chk_Reg.AutoSize = true;
            this.Chk_Reg.Checked = true;
            this.Chk_Reg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_Reg.Location = new System.Drawing.Point(272, 122);
            this.Chk_Reg.Name = "Chk_Reg";
            this.Chk_Reg.Size = new System.Drawing.Size(63, 17);
            this.Chk_Reg.TabIndex = 8;
            this.Chk_Reg.Text = "Regular";
            this.Chk_Reg.UseVisualStyleBackColor = true;
            this.Chk_Reg.CheckedChanged += new System.EventHandler(this.Chkbx_CheckedChanged);
            // 
            // Chk_Nul
            // 
            this.Chk_Nul.AutoSize = true;
            this.Chk_Nul.Checked = true;
            this.Chk_Nul.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_Nul.Location = new System.Drawing.Point(272, 148);
            this.Chk_Nul.Name = "Chk_Nul";
            this.Chk_Nul.Size = new System.Drawing.Size(77, 17);
            this.Chk_Nul.TabIndex = 9;
            this.Chk_Nul.Text = "No informo";
            this.Chk_Nul.UseVisualStyleBackColor = true;
            this.Chk_Nul.CheckedChanged += new System.EventHandler(this.Chkbx_CheckedChanged);
            // 
            // Chk_All
            // 
            this.Chk_All.AutoSize = true;
            this.Chk_All.Checked = true;
            this.Chk_All.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_All.Location = new System.Drawing.Point(272, 44);
            this.Chk_All.Name = "Chk_All";
            this.Chk_All.Size = new System.Drawing.Size(56, 17);
            this.Chk_All.TabIndex = 10;
            this.Chk_All.Text = "Todos";
            this.Chk_All.UseVisualStyleBackColor = true;
            this.Chk_All.CheckedChanged += new System.EventHandler(this.Chkbx_CheckedChanged);
            // 
            // Txt_Publicador
            // 
            this.Txt_Publicador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Txt_Publicador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Txt_Publicador.Enabled = false;
            this.Txt_Publicador.Location = new System.Drawing.Point(410, 12);
            this.Txt_Publicador.Name = "Txt_Publicador";
            this.Txt_Publicador.Size = new System.Drawing.Size(164, 20);
            this.Txt_Publicador.TabIndex = 11;
            this.Txt_Publicador.TextChanged += new System.EventHandler(this.Txt_Publicador_TextChanged);
            // 
            // Totals_Grid_View
            // 
            this.Totals_Grid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Totals_Grid_View.DefaultCellStyle = dataGridViewCellStyle1;
            this.Totals_Grid_View.Location = new System.Drawing.Point(12, 700);
            this.Totals_Grid_View.Name = "Totals_Grid_View";
            this.Totals_Grid_View.ReadOnly = true;
            this.Totals_Grid_View.Size = new System.Drawing.Size(709, 108);
            this.Totals_Grid_View.TabIndex = 12;
            // 
            // Chk_Promedios
            // 
            this.Chk_Promedios.AutoSize = true;
            this.Chk_Promedios.Location = new System.Drawing.Point(499, 122);
            this.Chk_Promedios.Name = "Chk_Promedios";
            this.Chk_Promedios.Size = new System.Drawing.Size(75, 17);
            this.Chk_Promedios.TabIndex = 13;
            this.Chk_Promedios.Text = "Promedios";
            this.Chk_Promedios.UseVisualStyleBackColor = true;
            this.Chk_Promedios.CheckedChanged += new System.EventHandler(this.Chk_Promedios_CheckedChanged);
            // 
            // Lbl_Selected_Pub
            // 
            this.Lbl_Selected_Pub.AutoSize = true;
            this.Lbl_Selected_Pub.Location = new System.Drawing.Point(775, 20);
            this.Lbl_Selected_Pub.Name = "Lbl_Selected_Pub";
            this.Lbl_Selected_Pub.Size = new System.Drawing.Size(69, 13);
            this.Lbl_Selected_Pub.TabIndex = 14;
            this.Lbl_Selected_Pub.Text = "<Publicador>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Vista";
            // 
            // Prom_Grid_View
            // 
            this.Prom_Grid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Prom_Grid_View.DefaultCellStyle = dataGridViewCellStyle2;
            this.Prom_Grid_View.Location = new System.Drawing.Point(12, 586);
            this.Prom_Grid_View.Name = "Prom_Grid_View";
            this.Prom_Grid_View.ReadOnly = true;
            this.Prom_Grid_View.Size = new System.Drawing.Size(709, 108);
            this.Prom_Grid_View.TabIndex = 17;
            // 
            // Pub_Grid_View
            // 
            this.Pub_Grid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Pub_Grid_View.Location = new System.Drawing.Point(727, 44);
            this.Pub_Grid_View.Name = "Pub_Grid_View";
            this.Pub_Grid_View.Size = new System.Drawing.Size(669, 405);
            this.Pub_Grid_View.TabIndex = 18;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 838);
            this.Controls.Add(this.Pub_Grid_View);
            this.Controls.Add(this.Prom_Grid_View);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lbl_Selected_Pub);
            this.Controls.Add(this.Chk_Promedios);
            this.Controls.Add(this.Totals_Grid_View);
            this.Controls.Add(this.Txt_Publicador);
            this.Controls.Add(this.Chk_All);
            this.Controls.Add(this.Chk_Nul);
            this.Controls.Add(this.Chk_Reg);
            this.Controls.Add(this.Chk_Aux);
            this.Controls.Add(this.Chk_Pub);
            this.Controls.Add(this.Cmb_Filter);
            this.Controls.Add(this.Chart_Publicaciones);
            this.Controls.Add(this.btn_nuevo);
            this.Controls.Add(this.Mes_cmbx);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.Main_Data_gridview);
            this.Name = "Main_Form";
            this.Text = "JW_Secretario";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_Form_FormClosed);
            this.Load += new System.EventHandler(this.Main_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Main_Data_gridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Publicaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Totals_Grid_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Prom_Grid_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pub_Grid_View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Main_Data_gridview;
        private System.Windows.Forms.Timer Refresh_timer;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.ComboBox Mes_cmbx;
        private System.Windows.Forms.Button btn_nuevo;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Publicaciones;
        private System.Windows.Forms.ComboBox Cmb_Filter;
        private System.Windows.Forms.CheckBox Chk_Pub;
        private System.Windows.Forms.CheckBox Chk_Aux;
        private System.Windows.Forms.CheckBox Chk_Reg;
        private System.Windows.Forms.CheckBox Chk_Nul;
        private System.Windows.Forms.CheckBox Chk_All;
        private System.Windows.Forms.TextBox Txt_Publicador;
        private System.Windows.Forms.DataGridView Totals_Grid_View;
        private System.Windows.Forms.CheckBox Chk_Promedios;
        private System.Windows.Forms.Label Lbl_Selected_Pub;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView Prom_Grid_View;
        private System.Windows.Forms.DataGridView Pub_Grid_View;
    }
}

