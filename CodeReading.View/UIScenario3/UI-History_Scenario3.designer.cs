namespace CodeReading.View
{
    partial class UI_History_Scenario3
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_History_Scenario3));
            this.lbl__From = new System.Windows.Forms.Label();
            this.lbl__To = new System.Windows.Forms.Label();
            this.lbl_Rod = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.dtpDtp_From = new System.Windows.Forms.DateTimePicker();
            this.dtpDtp_To = new System.Windows.Forms.DateTimePicker();
            this.lbl_HospitalizationNum = new System.Windows.Forms.Label();
            this.txt_HospitalizationNum = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.detailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbl_ResultsCount = new System.Windows.Forms.Label();
            this.lbl_DbId = new System.Windows.Forms.Label();
            this.lbl_Sign = new System.Windows.Forms.Label();
            this.hWinctl_HistoryBMP = new HalconDotNet.HWindowControl();
            this.txt_Other2 = new System.Windows.Forms.TextBox();
            this.lbl_Other2 = new System.Windows.Forms.Label();
            this.txt_Other1 = new System.Windows.Forms.TextBox();
            this.lbl_Other1 = new System.Windows.Forms.Label();
            this.lbl_Pass = new System.Windows.Forms.Label();
            this.cmb_DbId = new System.Windows.Forms.ComboBox();
            this.cmb_Sign = new System.Windows.Forms.ComboBox();
            this.cmb_Pass = new System.Windows.Forms.ComboBox();
            this.dgv_HistoryTable = new System.Windows.Forms.DataGridView();
            this.ScanDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DbId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtherID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Signed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_ShowimgIS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.detailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HistoryTable)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl__From
            // 
            this.lbl__From.AutoSize = true;
            this.lbl__From.BackColor = System.Drawing.Color.Transparent;
            this.lbl__From.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl__From.ForeColor = System.Drawing.Color.Black;
            this.lbl__From.Location = new System.Drawing.Point(19, 59);
            this.lbl__From.Name = "lbl__From";
            this.lbl__From.Size = new System.Drawing.Size(120, 16);
            this.lbl__From.TabIndex = 1;
            this.lbl__From.Text = "扫描开始时刻：";
            // 
            // lbl__To
            // 
            this.lbl__To.AutoSize = true;
            this.lbl__To.BackColor = System.Drawing.Color.Transparent;
            this.lbl__To.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl__To.ForeColor = System.Drawing.Color.Black;
            this.lbl__To.Location = new System.Drawing.Point(344, 59);
            this.lbl__To.Name = "lbl__To";
            this.lbl__To.Size = new System.Drawing.Size(120, 16);
            this.lbl__To.TabIndex = 3;
            this.lbl__To.Text = "扫描结束时刻：";
            // 
            // lbl_Rod
            // 
            this.lbl_Rod.AutoSize = true;
            this.lbl_Rod.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Rod.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Rod.ForeColor = System.Drawing.Color.Black;
            this.lbl_Rod.Location = new System.Drawing.Point(332, 59);
            this.lbl_Rod.Name = "lbl_Rod";
            this.lbl_Rod.Size = new System.Drawing.Size(13, 17);
            this.lbl_Rod.TabIndex = 5;
            this.lbl_Rod.Text = "-";
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.ForeColor = System.Drawing.Color.Black;
            this.lbl_Title.Location = new System.Drawing.Point(9, 9);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(143, 33);
            this.lbl_Title.TabIndex = 14;
            this.lbl_Title.Text = "扫描记录";
            // 
            // dtpDtp_From
            // 
            this.dtpDtp_From.CalendarFont = new System.Drawing.Font("宋体", 12F);
            this.dtpDtp_From.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtpDtp_From.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDtp_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDtp_From.Location = new System.Drawing.Point(131, 55);
            this.dtpDtp_From.Name = "dtpDtp_From";
            this.dtpDtp_From.Size = new System.Drawing.Size(196, 26);
            this.dtpDtp_From.TabIndex = 15;
            // 
            // dtpDtp_To
            // 
            this.dtpDtp_To.CalendarFont = new System.Drawing.Font("宋体", 12F);
            this.dtpDtp_To.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtpDtp_To.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDtp_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDtp_To.Location = new System.Drawing.Point(456, 55);
            this.dtpDtp_To.Name = "dtpDtp_To";
            this.dtpDtp_To.Size = new System.Drawing.Size(196, 26);
            this.dtpDtp_To.TabIndex = 16;
            // 
            // lbl_HospitalizationNum
            // 
            this.lbl_HospitalizationNum.AutoSize = true;
            this.lbl_HospitalizationNum.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_HospitalizationNum.Location = new System.Drawing.Point(1011, 60);
            this.lbl_HospitalizationNum.Name = "lbl_HospitalizationNum";
            this.lbl_HospitalizationNum.Size = new System.Drawing.Size(72, 16);
            this.lbl_HospitalizationNum.TabIndex = 17;
            this.lbl_HospitalizationNum.Text = "住院号：";
            // 
            // txt_HospitalizationNum
            // 
            this.txt_HospitalizationNum.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_HospitalizationNum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_HospitalizationNum.Location = new System.Drawing.Point(1076, 55);
            this.txt_HospitalizationNum.Name = "txt_HospitalizationNum";
            this.txt_HospitalizationNum.Size = new System.Drawing.Size(144, 26);
            this.txt_HospitalizationNum.TabIndex = 18;
            // 
            // btn_Search
            // 
            this.btn_Search.AutoSize = true;
            this.btn_Search.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_Search.Location = new System.Drawing.Point(1806, 100);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 27);
            this.btn_Search.TabIndex = 21;
            this.btn_Search.Text = "检索";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // lbl_ResultsCount
            // 
            this.lbl_ResultsCount.AutoSize = true;
            this.lbl_ResultsCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ResultsCount.Location = new System.Drawing.Point(18, 141);
            this.lbl_ResultsCount.Name = "lbl_ResultsCount";
            this.lbl_ResultsCount.Size = new System.Drawing.Size(83, 12);
            this.lbl_ResultsCount.TabIndex = 22;
            this.lbl_ResultsCount.Text = "查询结果：0件";
            // 
            // lbl_DbId
            // 
            this.lbl_DbId.AutoSize = true;
            this.lbl_DbId.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_DbId.Location = new System.Drawing.Point(685, 60);
            this.lbl_DbId.Name = "lbl_DbId";
            this.lbl_DbId.Size = new System.Drawing.Size(88, 16);
            this.lbl_DbId.TabIndex = 23;
            this.lbl_DbId.Text = "表单类别：";
            // 
            // lbl_Sign
            // 
            this.lbl_Sign.AutoSize = true;
            this.lbl_Sign.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Sign.Location = new System.Drawing.Point(1251, 60);
            this.lbl_Sign.Name = "lbl_Sign";
            this.lbl_Sign.Size = new System.Drawing.Size(88, 16);
            this.lbl_Sign.TabIndex = 25;
            this.lbl_Sign.Text = "有无签字：";
            // 
            // hWinctl_HistoryBMP
            // 
            this.hWinctl_HistoryBMP.BackColor = System.Drawing.Color.Black;
            this.hWinctl_HistoryBMP.BorderColor = System.Drawing.Color.Black;
            this.hWinctl_HistoryBMP.ImagePart = new System.Drawing.Rectangle(0, 0, 620, 810);
            this.hWinctl_HistoryBMP.Location = new System.Drawing.Point(1182, 156);
            this.hWinctl_HistoryBMP.Name = "hWinctl_HistoryBMP";
            this.hWinctl_HistoryBMP.Size = new System.Drawing.Size(704, 869);
            this.hWinctl_HistoryBMP.TabIndex = 27;
            this.hWinctl_HistoryBMP.WindowSize = new System.Drawing.Size(704, 869);
            // 
            // txt_Other2
            // 
            this.txt_Other2.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_Other2.Location = new System.Drawing.Point(490, 100);
            this.txt_Other2.Name = "txt_Other2";
            this.txt_Other2.Size = new System.Drawing.Size(487, 26);
            this.txt_Other2.TabIndex = 31;
            // 
            // lbl_Other2
            // 
            this.lbl_Other2.AutoSize = true;
            this.lbl_Other2.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Other2.Location = new System.Drawing.Point(363, 105);
            this.lbl_Other2.Name = "lbl_Other2";
            this.lbl_Other2.Size = new System.Drawing.Size(136, 16);
            this.lbl_Other2.TabIndex = 30;
            this.lbl_Other2.Text = "模拟查询条件二：";
            // 
            // txt_Other1
            // 
            this.txt_Other1.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_Other1.Location = new System.Drawing.Point(146, 100);
            this.txt_Other1.Name = "txt_Other1";
            this.txt_Other1.Size = new System.Drawing.Size(184, 26);
            this.txt_Other1.TabIndex = 29;
            // 
            // lbl_Other1
            // 
            this.lbl_Other1.AutoSize = true;
            this.lbl_Other1.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Other1.Location = new System.Drawing.Point(19, 105);
            this.lbl_Other1.Name = "lbl_Other1";
            this.lbl_Other1.Size = new System.Drawing.Size(136, 16);
            this.lbl_Other1.TabIndex = 28;
            this.lbl_Other1.Text = "模拟查询条件一：";
            // 
            // lbl_Pass
            // 
            this.lbl_Pass.AutoSize = true;
            this.lbl_Pass.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Pass.Location = new System.Drawing.Point(1479, 60);
            this.lbl_Pass.Name = "lbl_Pass";
            this.lbl_Pass.Size = new System.Drawing.Size(88, 16);
            this.lbl_Pass.TabIndex = 32;
            this.lbl_Pass.Text = "是否通过：";
            // 
            // cmb_DbId
            // 
            this.cmb_DbId.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_DbId.FormattingEnabled = true;
            this.cmb_DbId.Items.AddRange(new object[] {
            "全部",
            "跟台人体植入物使用清单",
            "高净值耗材使用清单",
            "耗材仓库配送出库单"});
            this.cmb_DbId.Location = new System.Drawing.Point(765, 57);
            this.cmb_DbId.Name = "cmb_DbId";
            this.cmb_DbId.Size = new System.Drawing.Size(212, 24);
            this.cmb_DbId.TabIndex = 34;
            // 
            // cmb_Sign
            // 
            this.cmb_Sign.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Sign.FormattingEnabled = true;
            this.cmb_Sign.Items.AddRange(new object[] {
            "全部",
            "已签字",
            "未签字"});
            this.cmb_Sign.Location = new System.Drawing.Point(1332, 57);
            this.cmb_Sign.Name = "cmb_Sign";
            this.cmb_Sign.Size = new System.Drawing.Size(116, 24);
            this.cmb_Sign.TabIndex = 35;
            // 
            // cmb_Pass
            // 
            this.cmb_Pass.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Pass.FormattingEnabled = true;
            this.cmb_Pass.Items.AddRange(new object[] {
            "全部",
            "通过",
            "未通过"});
            this.cmb_Pass.Location = new System.Drawing.Point(1560, 57);
            this.cmb_Pass.Name = "cmb_Pass";
            this.cmb_Pass.Size = new System.Drawing.Size(116, 24);
            this.cmb_Pass.TabIndex = 36;
            // 
            // dgv_HistoryTable
            // 
            this.dgv_HistoryTable.AllowUserToAddRows = false;
            this.dgv_HistoryTable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_HistoryTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_HistoryTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HistoryTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScanDate,
            this.DbId,
            this.OtherID,
            this.TagCode,
            this.Signed,
            this.Pass,
            this.FileName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_HistoryTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_HistoryTable.Location = new System.Drawing.Point(12, 156);
            this.dgv_HistoryTable.Name = "dgv_HistoryTable";
            this.dgv_HistoryTable.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_HistoryTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_HistoryTable.RowHeadersVisible = false;
            this.dgv_HistoryTable.RowTemplate.Height = 23;
            this.dgv_HistoryTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_HistoryTable.Size = new System.Drawing.Size(1152, 869);
            this.dgv_HistoryTable.TabIndex = 37;
            this.dgv_HistoryTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_HistoryTable_CellClick);
            // 
            // ScanDate
            // 
            this.ScanDate.DataPropertyName = "ScanDate";
            this.ScanDate.HeaderText = "扫描日期";
            this.ScanDate.Name = "ScanDate";
            this.ScanDate.ReadOnly = true;
            this.ScanDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ScanDate.Width = 160;
            // 
            // DbId
            // 
            this.DbId.DataPropertyName = "DbId";
            this.DbId.HeaderText = "录取表单类别";
            this.DbId.Name = "DbId";
            this.DbId.ReadOnly = true;
            this.DbId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // OtherID
            // 
            this.OtherID.DataPropertyName = "OtherID";
            this.OtherID.HeaderText = "住院号（模拟主键）";
            this.OtherID.Name = "OtherID";
            this.OtherID.ReadOnly = true;
            this.OtherID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OtherID.Width = 200;
            // 
            // TagCode
            // 
            this.TagCode.DataPropertyName = "TagCode";
            this.TagCode.HeaderText = "条形码";
            this.TagCode.Name = "TagCode";
            this.TagCode.ReadOnly = true;
            this.TagCode.Width = 403;
            // 
            // Signed
            // 
            this.Signed.DataPropertyName = "Signed";
            this.Signed.HeaderText = "签字";
            this.Signed.Name = "Signed";
            this.Signed.ReadOnly = true;
            this.Signed.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Signed.Width = 60;
            // 
            // Pass
            // 
            this.Pass.DataPropertyName = "Pass";
            this.Pass.HeaderText = "是否通过";
            this.Pass.Name = "Pass";
            this.Pass.ReadOnly = true;
            this.Pass.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Pass.Width = 77;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "图片名";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FileName.Width = 150;
            // 
            // lbl_ShowimgIS
            // 
            this.lbl_ShowimgIS.AutoSize = true;
            this.lbl_ShowimgIS.BackColor = System.Drawing.Color.Black;
            this.lbl_ShowimgIS.ForeColor = System.Drawing.Color.Red;
            this.lbl_ShowimgIS.Location = new System.Drawing.Point(1508, 553);
            this.lbl_ShowimgIS.Name = "lbl_ShowimgIS";
            this.lbl_ShowimgIS.Size = new System.Drawing.Size(89, 12);
            this.lbl_ShowimgIS.TabIndex = 38;
            this.lbl_ShowimgIS.Text = "图片丢失！！！";
            // 
            // UI_History_Scenario3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 1037);
            this.Controls.Add(this.lbl_ShowimgIS);
            this.Controls.Add(this.dgv_HistoryTable);
            this.Controls.Add(this.cmb_Pass);
            this.Controls.Add(this.cmb_Sign);
            this.Controls.Add(this.cmb_DbId);
            this.Controls.Add(this.lbl_Pass);
            this.Controls.Add(this.txt_Other2);
            this.Controls.Add(this.lbl_Other2);
            this.Controls.Add(this.txt_Other1);
            this.Controls.Add(this.lbl_Other1);
            this.Controls.Add(this.hWinctl_HistoryBMP);
            this.Controls.Add(this.lbl_Sign);
            this.Controls.Add(this.lbl_DbId);
            this.Controls.Add(this.lbl_ResultsCount);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.txt_HospitalizationNum);
            this.Controls.Add(this.lbl_HospitalizationNum);
            this.Controls.Add(this.dtpDtp_To);
            this.Controls.Add(this.dtpDtp_From);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.lbl_Rod);
            this.Controls.Add(this.lbl__To);
            this.Controls.Add(this.lbl__From);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UI_History_Scenario3";
            this.Text = "华时数字工业相机读码_扫描记录";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.UI_History_Scenario3_Activated);
            this.Load += new System.EventHandler(this.UI_History_Scenario3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HistoryTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Label lbl_HospitalizationNum;
        private System.Windows.Forms.TextBox txt_HospitalizationNum;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.BindingSource detailBindingSource;
        private System.Windows.Forms.Label lbl_ResultsCount;
        private System.Windows.Forms.Label lbl_DbId;
        private System.Windows.Forms.Label lbl_Sign;
        private HalconDotNet.HWindowControl hWinctl_HistoryBMP;
        private System.Windows.Forms.TextBox txt_Other2;
        private System.Windows.Forms.Label lbl_Other2;
        private System.Windows.Forms.TextBox txt_Other1;
        private System.Windows.Forms.Label lbl_Other1;
        private System.Windows.Forms.Label lbl_Pass;
        private System.Windows.Forms.ComboBox cmb_DbId;
        private System.Windows.Forms.ComboBox cmb_Sign;
        private System.Windows.Forms.ComboBox cmb_Pass;
        private System.Windows.Forms.DataGridView dgv_HistoryTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DbId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OtherID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Signed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.Label lbl_ShowimgIS;
    }
}