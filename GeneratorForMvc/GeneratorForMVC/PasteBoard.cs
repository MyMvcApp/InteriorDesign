using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorForMVC
{
    public partial class PasteBoard : Form
    {
        string mPath = Application.StartupPath + "\\PasteBoard";
        public bool mIsSave;

        public PasteBoard()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string content = txt_content.Text;
            string filename = txt_filename.Text;
            if (content.Equals("") || filename.Equals(""))
            {
                MessageBox.Show("操作数据不足！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (WriteIn(filename))
            {
                mIsSave = true;
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private bool WriteIn(string filename)
        {
            StreamWriter w = null;
            string path = Application.StartupPath + "\\PasteBoard";

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                w = new StreamWriter(path + "\\" + filename + ".pb", false);
                w.Write(txt_content.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("出错啦！" + ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (w != null)
                {
                    w.Flush();
                    w.Close();
                }
            }

            return true;
        }

        private void cb_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb != null && cb.SelectedItem != null)
            {
                if (About.mPbDic.ContainsKey(cb.SelectedItem.ToString()))
                {
                    if (Directory.Exists(mPath))
                    {
                        StreamReader r = null;
                        try
                        {
                            r = new StreamReader(About.mPbDic[cb.SelectedItem.ToString()]);
                            txt_content.Text = r.ReadToEnd();
                            txt_filename.Text = cb.SelectedItem.ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("出错啦！" + ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (r != null)
                            {
                                r.Close();
                            }
                        }
                    }
                }
            }
        }

        private List<string> DataBing()
        {
            if (Directory.Exists(mPath))
            {
                List<string> list = null;
                About.mPbDic.Clear();

                try
                {
                    list = new List<string>();
                    string[] filenames = Directory.GetFiles(mPath);
                    foreach (string item in filenames)
                    {
                        string name = item.Substring(item.LastIndexOf('\\') + 1);
                        About.mPbDic.Add(name, item);
                        list.Add(name);
                    }

                    return list;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出错啦！" + ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return null;
        }

        private void PasteBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btn_look_Click(object sender, EventArgs e)
        {
            if (btn_look.Text == "打开预览")
            {
                lbl_select.Enabled = true;
                cb_select.Enabled = true;
                btn_look.Text = "关闭预览";

                cb_select.DataSource = DataBing();
            }
            else
            {
                lbl_select.Enabled = false;
                cb_select.Enabled = false;
                btn_look.Text = "打开预览";

                cb_select.DataSource = null;
                txt_content.Clear();
            }
        }
    }
}
