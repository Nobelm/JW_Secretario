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
            this.Data_gridview = new System.Windows.Forms.DataGridView();
            this.Refresh_timer = new System.Windows.Forms.Timer(this.components);
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.Mes_cmbx = new System.Windows.Forms.ComboBox();
            this.btn_nuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Data_gridview)).BeginInit();
            this.SuspendLayout();
            // 
            // Data_gridview
            // 
            this.Data_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data_gridview.Location = new System.Drawing.Point(12, 12);
            this.Data_gridview.Name = "Data_gridview";
            this.Data_gridview.Size = new System.Drawing.Size(645, 351);
            this.Data_gridview.TabIndex = 0;
            // 
            // Refresh_timer
            // 
            this.Refresh_timer.Enabled = true;
            this.Refresh_timer.Interval = 500;
            this.Refresh_timer.Tick += new System.EventHandler(this.Refresh_timer_Tick);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Location = new System.Drawing.Point(986, 88);
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
            this.Mes_cmbx.Location = new System.Drawing.Point(910, 45);
            this.Mes_cmbx.Name = "Mes_cmbx";
            this.Mes_cmbx.Size = new System.Drawing.Size(121, 21);
            this.Mes_cmbx.TabIndex = 2;
            this.Mes_cmbx.SelectedIndexChanged += new System.EventHandler(this.Mes_cmbx_SelectedIndexChanged);
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.Location = new System.Drawing.Point(986, 117);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(75, 23);
            this.btn_nuevo.TabIndex = 3;
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.Btn_nuevo_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 616);
            this.Controls.Add(this.btn_nuevo);
            this.Controls.Add(this.Mes_cmbx);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.Data_gridview);
            this.Name = "Main_Form";
            this.Text = "JW_Secretario";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_Form_FormClosed);
            this.Load += new System.EventHandler(this.Main_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Data_gridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Data_gridview;
        private System.Windows.Forms.Timer Refresh_timer;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.ComboBox Mes_cmbx;
        private System.Windows.Forms.Button btn_nuevo;
    }
}

