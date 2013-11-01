namespace GeneratorForMVC
{
    partial class CodeMainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tv_code = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tv_types = new System.Windows.Forms.TreeView();
            this.btn_open = new System.Windows.Forms.Button();
            this.txt_targetpath = new System.Windows.Forms.TextBox();
            this.btn_go = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.btn_paste = new System.Windows.Forms.Button();
            this.cb_select = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tv_code
            // 
            this.tv_code.AllowDrop = true;
            this.tv_code.BackColor = System.Drawing.SystemColors.Control;
            this.tv_code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_code.Location = new System.Drawing.Point(3, 17);
            this.tv_code.Name = "tv_code";
            this.tv_code.Size = new System.Drawing.Size(170, 295);
            this.tv_code.TabIndex = 3;
            this.tv_code.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_code_AfterSelect);
            this.tv_code.DragDrop += new System.Windows.Forms.DragEventHandler(this.tv_code_DragDrop);
            this.tv_code.DragEnter += new System.Windows.Forms.DragEventHandler(this.tv_code_DragEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tv_code);
            this.groupBox1.Location = new System.Drawing.Point(12, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 315);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已装载组件";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tv_types);
            this.groupBox2.Location = new System.Drawing.Point(194, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 196);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "包含类型";
            // 
            // tv_types
            // 
            this.tv_types.AllowDrop = true;
            this.tv_types.BackColor = System.Drawing.SystemColors.Control;
            this.tv_types.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_types.Location = new System.Drawing.Point(3, 17);
            this.tv_types.Name = "tv_types";
            this.tv_types.Size = new System.Drawing.Size(338, 176);
            this.tv_types.TabIndex = 4;
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(343, 18);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(62, 23);
            this.btn_open.TabIndex = 8;
            this.btn_open.Text = "打开";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // txt_targetpath
            // 
            this.txt_targetpath.BackColor = System.Drawing.SystemColors.Control;
            this.txt_targetpath.Location = new System.Drawing.Point(108, 20);
            this.txt_targetpath.Name = "txt_targetpath";
            this.txt_targetpath.ReadOnly = true;
            this.txt_targetpath.Size = new System.Drawing.Size(218, 21);
            this.txt_targetpath.TabIndex = 7;
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(425, 18);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(113, 56);
            this.btn_go.TabIndex = 9;
            this.btn_go.Text = "启动生成";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "代码放置路径：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_log);
            this.groupBox3.Location = new System.Drawing.Point(194, 282);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 113);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "日志";
            // 
            // txt_log
            // 
            this.txt_log.BackColor = System.Drawing.SystemColors.Control;
            this.txt_log.ForeColor = System.Drawing.Color.Red;
            this.txt_log.Location = new System.Drawing.Point(6, 20);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(332, 87);
            this.txt_log.TabIndex = 0;
            // 
            // btn_paste
            // 
            this.btn_paste.Location = new System.Drawing.Point(343, 51);
            this.btn_paste.Name = "btn_paste";
            this.btn_paste.Size = new System.Drawing.Size(62, 23);
            this.btn_paste.TabIndex = 12;
            this.btn_paste.Text = "制作模板";
            this.btn_paste.UseVisualStyleBackColor = true;
            this.btn_paste.Click += new System.EventHandler(this.btn_paste_Click);
            // 
            // cb_select
            // 
            this.cb_select.BackColor = System.Drawing.SystemColors.Control;
            this.cb_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_select.FormattingEnabled = true;
            this.cb_select.Location = new System.Drawing.Point(108, 51);
            this.cb_select.Name = "cb_select";
            this.cb_select.Size = new System.Drawing.Size(218, 20);
            this.cb_select.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "选择视图模版：";
            // 
            // CodeMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 407);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_select);
            this.Controls.Add(this.btn_paste);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_go);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.txt_targetpath);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CodeMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mvc代码生成器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CodeMainForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TreeView tv_code;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.TextBox txt_targetpath;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tv_types;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.Button btn_paste;
        private System.Windows.Forms.ComboBox cb_select;
        private System.Windows.Forms.Label label2;
    }
}

