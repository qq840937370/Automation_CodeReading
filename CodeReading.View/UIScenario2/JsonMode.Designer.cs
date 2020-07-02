namespace CodeReading.View.UIScenario2
{
    partial class JsonMode
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
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_Pass = new System.Windows.Forms.Label();
            this.lbl_JinQian = new System.Windows.Forms.Label();
            this.lbl_QianZi = new System.Windows.Forms.Label();
            this.lbl_Page = new System.Windows.Forms.Label();
            this.lbl_Seal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "模拟流程";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_Pass
            // 
            this.lbl_Pass.AutoSize = true;
            this.lbl_Pass.Location = new System.Drawing.Point(24, 222);
            this.lbl_Pass.Name = "lbl_Pass";
            this.lbl_Pass.Size = new System.Drawing.Size(53, 12);
            this.lbl_Pass.TabIndex = 1;
            this.lbl_Pass.Text = "是否通过";
            // 
            // lbl_JinQian
            // 
            this.lbl_JinQian.AutoSize = true;
            this.lbl_JinQian.Location = new System.Drawing.Point(24, 112);
            this.lbl_JinQian.Name = "lbl_JinQian";
            this.lbl_JinQian.Size = new System.Drawing.Size(65, 12);
            this.lbl_JinQian.TabIndex = 2;
            this.lbl_JinQian.Text = "金钱对不对";
            // 
            // lbl_QianZi
            // 
            this.lbl_QianZi.AutoSize = true;
            this.lbl_QianZi.Location = new System.Drawing.Point(24, 150);
            this.lbl_QianZi.Name = "lbl_QianZi";
            this.lbl_QianZi.Size = new System.Drawing.Size(53, 12);
            this.lbl_QianZi.TabIndex = 3;
            this.lbl_QianZi.Text = "是否签字";
            // 
            // lbl_Page
            // 
            this.lbl_Page.AutoSize = true;
            this.lbl_Page.Location = new System.Drawing.Point(24, 79);
            this.lbl_Page.Name = "lbl_Page";
            this.lbl_Page.Size = new System.Drawing.Size(71, 12);
            this.lbl_Page.TabIndex = 4;
            this.lbl_Page.Text = "表单名+页码";
            // 
            // lbl_Seal
            // 
            this.lbl_Seal.AutoSize = true;
            this.lbl_Seal.Location = new System.Drawing.Point(24, 188);
            this.lbl_Seal.Name = "lbl_Seal";
            this.lbl_Seal.Size = new System.Drawing.Size(53, 12);
            this.lbl_Seal.TabIndex = 5;
            this.lbl_Seal.Text = "是否盖章";
            // 
            // JsonMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 293);
            this.Controls.Add(this.lbl_Seal);
            this.Controls.Add(this.lbl_Page);
            this.Controls.Add(this.lbl_QianZi);
            this.Controls.Add(this.lbl_JinQian);
            this.Controls.Add(this.lbl_Pass);
            this.Controls.Add(this.button1);
            this.Name = "JsonMode";
            this.Text = "JsonMode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_Pass;
        private System.Windows.Forms.Label lbl_JinQian;
        private System.Windows.Forms.Label lbl_QianZi;
        private System.Windows.Forms.Label lbl_Page;
        private System.Windows.Forms.Label lbl_Seal;
    }
}