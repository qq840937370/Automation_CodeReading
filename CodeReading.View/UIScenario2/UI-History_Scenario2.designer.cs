namespace CodeReading.View
{
    partial class UI_History_Scenario2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_History_Scenario2));
            this.dgv_Historys = new System.Windows.Forms.DataGridView();
            this.lbl__From = new System.Windows.Forms.Label();
            this.lbl__To = new System.Windows.Forms.Label();
            this.lbl_Rod = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.dtpDtp_From = new System.Windows.Forms.DateTimePicker();
            this.dtpDtp_To = new System.Windows.Forms.DateTimePicker();
            this.lbl_HospitalNo = new System.Windows.Forms.Label();
            this.txt_HospitalNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.detailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbl_ResultsCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Historys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Historys
            // 
            this.dgv_Historys.AllowUserToAddRows = false;
            this.dgv_Historys.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Historys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Historys.Location = new System.Drawing.Point(16, 122);
            this.dgv_Historys.Name = "dgv_Historys";
            this.dgv_Historys.RowTemplate.Height = 23;
            this.dgv_Historys.Size = new System.Drawing.Size(1892, 946);
            this.dgv_Historys.TabIndex = 0;
            // 
            // lbl__From
            // 
            this.lbl__From.AutoSize = true;
            this.lbl__From.BackColor = System.Drawing.Color.Transparent;
            this.lbl__From.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl__From.ForeColor = System.Drawing.Color.Black;
            this.lbl__From.Location = new System.Drawing.Point(14, 63);
            this.lbl__From.Name = "lbl__From";
            this.lbl__From.Size = new System.Drawing.Size(120, 17);
            this.lbl__From.TabIndex = 1;
            this.lbl__From.Text = "扫描开始时刻：";
            // 
            // lbl__To
            // 
            this.lbl__To.AutoSize = true;
            this.lbl__To.BackColor = System.Drawing.Color.Transparent;
            this.lbl__To.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl__To.ForeColor = System.Drawing.Color.Black;
            this.lbl__To.Location = new System.Drawing.Point(393, 63);
            this.lbl__To.Name = "lbl__To";
            this.lbl__To.Size = new System.Drawing.Size(120, 17);
            this.lbl__To.TabIndex = 3;
            this.lbl__To.Text = "扫描结束时刻：";
            // 
            // lbl_Rod
            // 
            this.lbl_Rod.AutoSize = true;
            this.lbl_Rod.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Rod.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Rod.ForeColor = System.Drawing.Color.Black;
            this.lbl_Rod.Location = new System.Drawing.Point(379, 63);
            this.lbl_Rod.Name = "lbl_Rod";
            this.lbl_Rod.Size = new System.Drawing.Size(13, 17);
            this.lbl_Rod.TabIndex = 5;
            this.lbl_Rod.Text = "-";
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("华文新魏", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.ForeColor = System.Drawing.Color.Black;
            this.lbl_Title.Location = new System.Drawing.Point(10, 9);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(143, 33);
            this.lbl_Title.TabIndex = 14;
            this.lbl_Title.Text = "扫描记录";
            // 
            // dtpDtp_From
            // 
            this.dtpDtp_From.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtpDtp_From.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDtp_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDtp_From.Location = new System.Drawing.Point(145, 60);
            this.dtpDtp_From.Name = "dtpDtp_From";
            this.dtpDtp_From.Size = new System.Drawing.Size(228, 24);
            this.dtpDtp_From.TabIndex = 15;
            // 
            // dtpDtp_To
            // 
            this.dtpDtp_To.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtpDtp_To.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDtp_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDtp_To.Location = new System.Drawing.Point(524, 60);
            this.dtpDtp_To.Name = "dtpDtp_To";
            this.dtpDtp_To.Size = new System.Drawing.Size(228, 24);
            this.dtpDtp_To.TabIndex = 16;
            // 
            // lbl_HospitalNo
            // 
            this.lbl_HospitalNo.AutoSize = true;
            this.lbl_HospitalNo.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_HospitalNo.Location = new System.Drawing.Point(816, 63);
            this.lbl_HospitalNo.Name = "lbl_HospitalNo";
            this.lbl_HospitalNo.Size = new System.Drawing.Size(72, 17);
            this.lbl_HospitalNo.TabIndex = 17;
            this.lbl_HospitalNo.Text = "住院号：";
            // 
            // txt_HospitalNo
            // 
            this.txt_HospitalNo.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_HospitalNo.Location = new System.Drawing.Point(885, 60);
            this.txt_HospitalNo.Name = "txt_HospitalNo";
            this.txt_HospitalNo.Size = new System.Drawing.Size(133, 24);
            this.txt_HospitalNo.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2108, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2175, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "label7";
            // 
            // btn_Search
            // 
            this.btn_Search.AutoSize = true;
            this.btn_Search.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Search.Location = new System.Drawing.Point(1810, 58);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(87, 27);
            this.btn_Search.TabIndex = 21;
            this.btn_Search.Text = "检索";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // lbl_ResultsCount
            // 
            this.lbl_ResultsCount.AutoSize = true;
            this.lbl_ResultsCount.Location = new System.Drawing.Point(17, 104);
            this.lbl_ResultsCount.Name = "lbl_ResultsCount";
            this.lbl_ResultsCount.Size = new System.Drawing.Size(0, 12);
            this.lbl_ResultsCount.TabIndex = 22;
            // 
            // UI_History_Scenario2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.lbl_ResultsCount);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_HospitalNo);
            this.Controls.Add(this.lbl_HospitalNo);
            this.Controls.Add(this.dtpDtp_To);
            this.Controls.Add(this.dtpDtp_From);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.lbl_Rod);
            this.Controls.Add(this.lbl__To);
            this.Controls.Add(this.lbl__From);
            this.Controls.Add(this.dgv_Historys);
            this.Font = new System.Drawing.Font("华文新魏", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UI_History_Scenario2";
            this.Text = "华时数字工业相机读码_扫描记录";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.UI_History_Scenario2_Activated);
            this.Load += new System.EventHandler(this.UI_History_Scenario2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Historys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Historys;
        private System.Windows.Forms.DataGridViewTextBoxColumn scanDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label lbl__From;
        private System.Windows.Forms.Label lbl__To;
        private System.Windows.Forms.Label lbl_Rod;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.DateTimePicker dtpDtp_From;
        private System.Windows.Forms.DateTimePicker dtpDtp_To;
        private System.Windows.Forms.Label lbl_HospitalNo;
        private System.Windows.Forms.TextBox txt_HospitalNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.BindingSource detailBindingSource;
        private System.Windows.Forms.Label lbl_ResultsCount;
    }
}