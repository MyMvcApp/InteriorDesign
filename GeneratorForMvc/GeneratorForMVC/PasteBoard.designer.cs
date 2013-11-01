namespace GeneratorForMVC
{
    partial class PasteBoard
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
            this.txt_content = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_filename = new System.Windows.Forms.TextBox();
            this.lbl_select = new System.Windows.Forms.Label();
            this.cb_select = new System.Windows.Forms.ComboBox();
            this.btn_look = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_content
            // 
            this.txt_content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_content.Location = new System.Drawing.Point(12, 30);
            this.txt_content.Multiline = true;
            this.txt_content.Name = "txt_content";
            this.txt_content.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_content.Size = new System.Drawing.Size(618, 377);
            this.txt_content.TabIndex = 0;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Location = new System.Drawing.Point(555, 414);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(12, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "请在需要动态填入的位置打上{数字},其它打上{{}}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "文件名：";
            // 
            // txt_filename
            // 
            this.txt_filename.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_filename.Location = new System.Drawing.Point(394, 415);
            this.txt_filename.Name = "txt_filename";
            this.txt_filename.Size = new System.Drawing.Size(155, 21);
            this.txt_filename.TabIndex = 4;
            // 
            // lbl_select
            // 
            this.lbl_select.AutoSize = true;
            this.lbl_select.Enabled = false;
            this.lbl_select.Location = new System.Drawing.Point(13, 9);
            this.lbl_select.Name = "lbl_select";
            this.lbl_select.Size = new System.Drawing.Size(89, 12);
            this.lbl_select.TabIndex = 16;
            this.lbl_select.Text = "选择视图模版：";
            // 
            // cb_select
            // 
            this.cb_select.BackColor = System.Drawing.SystemColors.Control;
            this.cb_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_select.Enabled = false;
            this.cb_select.FormattingEnabled = true;
            this.cb_select.Location = new System.Drawing.Point(105, 6);
            this.cb_select.Name = "cb_select";
            this.cb_select.Size = new System.Drawing.Size(218, 20);
            this.cb_select.TabIndex = 15;
            this.cb_select.SelectedIndexChanged += new System.EventHandler(this.cb_select_SelectedIndexChanged);
            // 
            // btn_look
            // 
            this.btn_look.Location = new System.Drawing.Point(333, 3);
            this.btn_look.Name = "btn_look";
            this.btn_look.Size = new System.Drawing.Size(75, 23);
            this.btn_look.TabIndex = 17;
            this.btn_look.Text = "打开预览";
            this.btn_look.UseVisualStyleBackColor = true;
            this.btn_look.Click += new System.EventHandler(this.btn_look_Click);
            // 
            // PasteBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 445);
            this.Controls.Add(this.btn_look);
            this.Controls.Add(this.lbl_select);
            this.Controls.Add(this.cb_select);
            this.Controls.Add(this.txt_filename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_content);
            this.Name = "PasteBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "模版生成器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PasteBoard_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_content;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_filename;
        private System.Windows.Forms.Label lbl_select;
        private System.Windows.Forms.ComboBox cb_select;
        private System.Windows.Forms.Button btn_look;

    }
}