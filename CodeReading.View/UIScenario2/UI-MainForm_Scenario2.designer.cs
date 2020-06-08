namespace CodeReading.View
{
    partial class UI_MainForm_Scenario2
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_MainForm_Scenario2));
            this.openProjectFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveProjectFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer_Now = new System.Windows.Forms.Timer(this.components);
            this.bds_CumulativeData = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_History = new System.Windows.Forms.Button();
            this.btn_OpenCamera = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_CurrentData = new System.Windows.Forms.DataGridView();
            this.ScanDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DbId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtherID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_CumulativeData = new System.Windows.Forms.DataGridView();
            this.hisyScanDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hisyDbId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hisyOtherID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hisyTagCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hisySign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hisyPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hisyFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grp2 = new System.Windows.Forms.GroupBox();
            this.hWinctl_ICS = new HalconDotNet.HWindowControl();
            this.grp1 = new System.Windows.Forms.GroupBox();
            this.hWinctl_RTA = new HalconDotNet.HWindowControl();
            this.miniToolStrip = new System.Windows.Forms.StatusStrip();
            this.tsCuurrentProject = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_ImgNumber = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_CameraStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsErrMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbl_Time = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.bds_CumulativeData)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CurrentData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CumulativeData)).BeginInit();
            this.grp2.SuspendLayout();
            this.grp1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openProjectFileDialog
            // 
            this.openProjectFileDialog.Filter = "工程文件|*.prj";
            // 
            // saveProjectFileDialog
            // 
            this.saveProjectFileDialog.Filter = "工程文件|*.prj";
            this.saveProjectFileDialog.RestoreDirectory = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "bmp|*.bmp|All files|*.*";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // timer_Now
            // 
            this.timer_Now.Tick += new System.EventHandler(this.timer_Now_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.grp2);
            this.panel1.Controls.Add(this.grp1);
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 960);
            this.panel1.TabIndex = 11;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_History);
            this.groupBox4.Controls.Add(this.btn_OpenCamera);
            this.groupBox4.Location = new System.Drawing.Point(1292, 671);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(279, 168);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "执行操作";
            // 
            // btn_History
            // 
            this.btn_History.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_History.Location = new System.Drawing.Point(143, 20);
            this.btn_History.Name = "btn_History";
            this.btn_History.Size = new System.Drawing.Size(128, 35);
            this.btn_History.TabIndex = 23;
            this.btn_History.Text = "扫描记录";
            this.btn_History.UseVisualStyleBackColor = true;
            this.btn_History.Click += new System.EventHandler(this.tsmi_History_Click);
            // 
            // btn_OpenCamera
            // 
            this.btn_OpenCamera.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OpenCamera.Location = new System.Drawing.Point(9, 20);
            this.btn_OpenCamera.Name = "btn_OpenCamera";
            this.btn_OpenCamera.Size = new System.Drawing.Size(128, 35);
            this.btn_OpenCamera.TabIndex = 22;
            this.btn_OpenCamera.Text = "打开相机";
            this.btn_OpenCamera.UseVisualStyleBackColor = true;
            this.btn_OpenCamera.Click += new System.EventHandler(this.tsmi_OpenCamera_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(1577, 671);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(311, 168);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "扫描结果";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "未通过";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_CurrentData);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 845);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1876, 112);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "当前扫描信息";
            // 
            // dgv_CurrentData
            // 
            this.dgv_CurrentData.AllowUserToAddRows = false;
            this.dgv_CurrentData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CurrentData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScanDate,
            this.DbId,
            this.OtherID,
            this.TagCode,
            this.Sign,
            this.Pass,
            this.FileName});
            this.dgv_CurrentData.Location = new System.Drawing.Point(7, 20);
            this.dgv_CurrentData.Name = "dgv_CurrentData";
            this.dgv_CurrentData.RowHeadersVisible = false;
            this.dgv_CurrentData.RowTemplate.Height = 23;
            this.dgv_CurrentData.Size = new System.Drawing.Size(1863, 83);
            this.dgv_CurrentData.TabIndex = 18;
            // 
            // ScanDate
            // 
            this.ScanDate.HeaderText = "扫描日期";
            this.ScanDate.Name = "ScanDate";
            this.ScanDate.ReadOnly = true;
            this.ScanDate.Width = 150;
            // 
            // DbId
            // 
            this.DbId.HeaderText = "录取表单类别";
            this.DbId.Name = "DbId";
            this.DbId.ReadOnly = true;
            this.DbId.Width = 150;
            // 
            // OtherID
            // 
            this.OtherID.HeaderText = "住院号（模拟主键）";
            this.OtherID.Name = "OtherID";
            this.OtherID.ReadOnly = true;
            this.OtherID.Width = 185;
            // 
            // TagCode
            // 
            this.TagCode.HeaderText = "条形码";
            this.TagCode.Name = "TagCode";
            this.TagCode.Width = 900;
            // 
            // Sign
            // 
            this.Sign.HeaderText = "签字";
            this.Sign.Name = "Sign";
            this.Sign.ReadOnly = true;
            // 
            // Pass
            // 
            this.Pass.HeaderText = "是否通过";
            this.Pass.Name = "Pass";
            // 
            // FileName
            // 
            this.FileName.FillWeight = 150F;
            this.FileName.HeaderText = "图片名";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 275;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 649);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(429, 178);
            this.dataGridView1.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_CumulativeData);
            this.groupBox1.Location = new System.Drawing.Point(1292, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 660);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "历史扫描信息";
            // 
            // dgv_CumulativeData
            // 
            this.dgv_CumulativeData.AllowUserToAddRows = false;
            this.dgv_CumulativeData.AllowUserToDeleteRows = false;
            this.dgv_CumulativeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CumulativeData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hisyScanDate,
            this.hisyDbId,
            this.hisyOtherID,
            this.hisyTagCode,
            this.hisySign,
            this.hisyPass,
            this.hisyFileName});
            this.dgv_CumulativeData.Location = new System.Drawing.Point(7, 17);
            this.dgv_CumulativeData.Name = "dgv_CumulativeData";
            this.dgv_CumulativeData.ReadOnly = true;
            this.dgv_CumulativeData.RowHeadersVisible = false;
            this.dgv_CumulativeData.RowTemplate.Height = 23;
            this.dgv_CumulativeData.Size = new System.Drawing.Size(583, 634);
            this.dgv_CumulativeData.TabIndex = 17;
            // 
            // hisyScanDate
            // 
            this.hisyScanDate.HeaderText = "扫描日期";
            this.hisyScanDate.Name = "hisyScanDate";
            this.hisyScanDate.ReadOnly = true;
            this.hisyScanDate.Width = 150;
            // 
            // hisyDbId
            // 
            this.hisyDbId.HeaderText = "录取表单类别";
            this.hisyDbId.Name = "hisyDbId";
            this.hisyDbId.ReadOnly = true;
            this.hisyDbId.Width = 105;
            // 
            // hisyOtherID
            // 
            this.hisyOtherID.HeaderText = "住院号（模拟主键）";
            this.hisyOtherID.Name = "hisyOtherID";
            this.hisyOtherID.ReadOnly = true;
            // 
            // hisyTagCode
            // 
            this.hisyTagCode.HeaderText = "条形码";
            this.hisyTagCode.Name = "hisyTagCode";
            this.hisyTagCode.ReadOnly = true;
            // 
            // hisySign
            // 
            this.hisySign.HeaderText = "签字";
            this.hisySign.Name = "hisySign";
            this.hisySign.ReadOnly = true;
            this.hisySign.Width = 60;
            // 
            // hisyPass
            // 
            this.hisyPass.HeaderText = "是否通过";
            this.hisyPass.Name = "hisyPass";
            this.hisyPass.ReadOnly = true;
            this.hisyPass.Width = 60;
            // 
            // hisyFileName
            // 
            this.hisyFileName.HeaderText = "图片名";
            this.hisyFileName.Name = "hisyFileName";
            this.hisyFileName.ReadOnly = true;
            // 
            // grp2
            // 
            this.grp2.Controls.Add(this.hWinctl_ICS);
            this.grp2.ForeColor = System.Drawing.Color.Black;
            this.grp2.Location = new System.Drawing.Point(652, 3);
            this.grp2.Name = "grp2";
            this.grp2.Size = new System.Drawing.Size(634, 836);
            this.grp2.TabIndex = 2;
            this.grp2.TabStop = false;
            this.grp2.Text = "实时捕捉";
            // 
            // hWinctl_ICS
            // 
            this.hWinctl_ICS.BackColor = System.Drawing.Color.Black;
            this.hWinctl_ICS.BorderColor = System.Drawing.Color.Black;
            this.hWinctl_ICS.ImagePart = new System.Drawing.Rectangle(0, 0, 3020, 3850);
            this.hWinctl_ICS.Location = new System.Drawing.Point(6, 17);
            this.hWinctl_ICS.Name = "hWinctl_ICS";
            this.hWinctl_ICS.Size = new System.Drawing.Size(620, 810);
            this.hWinctl_ICS.TabIndex = 1;
            this.hWinctl_ICS.WindowSize = new System.Drawing.Size(620, 810);
            // 
            // grp1
            // 
            this.grp1.Controls.Add(this.hWinctl_RTA);
            this.grp1.ForeColor = System.Drawing.Color.Black;
            this.grp1.Location = new System.Drawing.Point(12, 3);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(634, 836);
            this.grp1.TabIndex = 1;
            this.grp1.TabStop = false;
            this.grp1.Text = "实时影像";
            // 
            // hWinctl_RTA
            // 
            this.hWinctl_RTA.BackColor = System.Drawing.Color.Black;
            this.hWinctl_RTA.BorderColor = System.Drawing.Color.Black;
            this.hWinctl_RTA.ImagePart = new System.Drawing.Rectangle(16, 0, 3020, 3850);
            this.hWinctl_RTA.Location = new System.Drawing.Point(7, 17);
            this.hWinctl_RTA.Name = "hWinctl_RTA";
            this.hWinctl_RTA.Size = new System.Drawing.Size(620, 810);
            this.hWinctl_RTA.TabIndex = 0;
            this.hWinctl_RTA.WindowSize = new System.Drawing.Size(620, 810);
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "新项选择";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Location = new System.Drawing.Point(1902, 24);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(1900, 22);
            this.miniToolStrip.TabIndex = 13;
            // 
            // tsCuurrentProject
            // 
            this.tsCuurrentProject.Name = "tsCuurrentProject";
            this.tsCuurrentProject.Size = new System.Drawing.Size(0, 17);
            // 
            // tssl_ImgNumber
            // 
            this.tssl_ImgNumber.ForeColor = System.Drawing.Color.Black;
            this.tssl_ImgNumber.Name = "tssl_ImgNumber";
            this.tssl_ImgNumber.Size = new System.Drawing.Size(99, 17);
            this.tssl_ImgNumber.Text = "已扫描文件：0个";
            // 
            // tssl_CameraStatus
            // 
            this.tssl_CameraStatus.ForeColor = System.Drawing.Color.Black;
            this.tssl_CameraStatus.Margin = new System.Windows.Forms.Padding(40, 3, 0, 2);
            this.tssl_CameraStatus.Name = "tssl_CameraStatus";
            this.tssl_CameraStatus.Size = new System.Drawing.Size(92, 17);
            this.tssl_CameraStatus.Text = "扫描相机未连接";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(40, 3, 0, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel2.Text = "相机帧率：";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Navy;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(40, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "请放上文件";
            // 
            // tsErrMessage
            // 
            this.tsErrMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.tsErrMessage.Name = "tsErrMessage";
            this.tsErrMessage.Size = new System.Drawing.Size(1406, 17);
            this.tsErrMessage.Spring = true;
            // 
            // tslbl_Time
            // 
            this.tslbl_Time.ForeColor = System.Drawing.Color.Black;
            this.tslbl_Time.Name = "tslbl_Time";
            this.tslbl_Time.Size = new System.Drawing.Size(32, 17);
            this.tslbl_Time.Text = "时间";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelMain.Controls.Add(this.lbl_Title);
            this.panelMain.Controls.Add(this.statusStrip1);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1900, 1037);
            this.panelMain.TabIndex = 9;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.Location = new System.Drawing.Point(9, 9);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(411, 33);
            this.lbl_Title.TabIndex = 14;
            this.lbl_Title.Text = "医院财务纸质表单读取系统";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCuurrentProject,
            this.tssl_ImgNumber,
            this.tssl_CameraStatus,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1,
            this.tsErrMessage,
            this.tslbl_Time});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1015);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1900, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // UI_MainForm_Scenario2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 1037);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "UI_MainForm_Scenario2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "华时数字工业相机读码_内测版_V1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UI_MainForm_Scenario2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bds_CumulativeData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CurrentData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CumulativeData)).EndInit();
            this.grp2.ResumeLayout(false);
            this.grp1.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion
        private System.Windows.Forms.OpenFileDialog openProjectFileDialog;
        private System.Windows.Forms.SaveFileDialog saveProjectFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer timer_Now;
        private System.Windows.Forms.BindingSource bds_CumulativeData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_History;
        private System.Windows.Forms.Button btn_OpenCamera;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DataGridView dgv_CurrentData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DbId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OtherID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sign;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_CumulativeData;
        private System.Windows.Forms.DataGridViewTextBoxColumn hisyScanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn hisyDbId;
        private System.Windows.Forms.DataGridViewTextBoxColumn hisyOtherID;
        private System.Windows.Forms.DataGridViewTextBoxColumn hisyTagCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn hisySign;
        private System.Windows.Forms.DataGridViewTextBoxColumn hisyPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn hisyFileName;
        private System.Windows.Forms.GroupBox grp2;
        private HalconDotNet.HWindowControl hWinctl_ICS;
        private System.Windows.Forms.GroupBox grp1;
        private HalconDotNet.HWindowControl hWinctl_RTA;
        private System.Windows.Forms.StatusStrip miniToolStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsCuurrentProject;
        private System.Windows.Forms.ToolStripStatusLabel tssl_ImgNumber;
        private System.Windows.Forms.ToolStripStatusLabel tssl_CameraStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsErrMessage;
        private System.Windows.Forms.ToolStripStatusLabel tslbl_Time;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label lbl_Title;
    }
}