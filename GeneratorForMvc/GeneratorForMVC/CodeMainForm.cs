using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace GeneratorForMVC
{
    public partial class CodeMainForm : Form
    {
        private delegate string DgCodeGenerate(Dictionary<string, Module[]> data);
        private delegate void DgEndCodeGenerate();
        private delegate void DgWriteLog(string msg);

        private static Dictionary<string, Module[]> mTreeNodeData = null;
        private static Hashtable mConfigData = null;
        private DgEndCodeGenerate mDgEndCodeGenerate = null;
        private DgCodeGenerate mDgCodeGenerate = null;
        private DgWriteLog mDgWriteLog = null;
        private int mTryCount;
        private string mSelectPath;
        private string mSelectView;

        public CodeMainForm()
        {
            InitializeComponent();

            try
            {
                mTreeNodeData = new Dictionary<string, Module[]>();

                mConfigData = new Hashtable();
                mConfigData.Add("namespace", ConfigurationManager.AppSettings["namespace"]);
                mConfigData.Add("filter", ConfigurationManager.AppSettings["filter"]);
                mConfigData.Add("usingRepositoryFront", ConfigurationManager.AppSettings["usingRepositoryFront"]);
                mConfigData.Add("usingRepositoryEnd", ConfigurationManager.AppSettings["usingRepositoryEnd"]);
                mConfigData.Add("usingIRepositoryFront", ConfigurationManager.AppSettings["usingIRepositoryFront"]);
                mConfigData.Add("usingIRepositoryEnd", ConfigurationManager.AppSettings["usingIRepositoryEnd"]);
                //mConfigData.Add("usingControllersCommon", ConfigurationManager.AppSettings["usingControllersCommon"]);
                mConfigData.Add("usingControllersEnd", ConfigurationManager.AppSettings["usingControllersEnd"]);

                cb_select.DataSource = DataBing();

                string path = Application.StartupPath + "\\Plugin";
                LoadPlugin(path, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("出错啦！" + ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPlugin(string path, bool isSave)
        {
            if (!Directory.Exists(path) && !isSave)
            {
                return;
            }
            string[] files = null;

            try
            {
                if (!isSave)
                {
                    files = Directory.GetFiles(path);
                }
                else
                {
                    files = new string[] { path };
                }
                foreach (string item in files)
                {
                    if (!item.ToUpper().EndsWith(".DLL")) { continue; }

                    byte[] addinStream = File.ReadAllBytes(item);
                    Assembly ass = Assembly.Load(addinStream);
                    string name = ass.ManifestModule.ScopeName;
                    Module[] mods = ass.GetModules();
                    if (mods.Length > 0)
                    {
                        bool isClear = false;
                        foreach (Module mod in mods)
                        {
                            Type[] typs = mod.GetTypes();
                            isClear = true;
                            if (isClear)
                            {
                                tv_types.Nodes.Clear();
                            }
                            foreach (Type typ in typs)
                            {
                                tv_types.Nodes.Add(typ.Name);
                            }
                            isClear = false;
                        }

                        if (mTreeNodeData.ContainsKey(name))
                        {
                            return;
                        }
                        tv_code.Nodes.Add(name);
                        tv_code.SelectedNode = tv_code.Nodes[tv_code.Nodes.Count - 1];
                        mTreeNodeData.Add(name, mods);

                        if (isSave)
                        {
                            File.Copy(path, Application.StartupPath + "\\Plugin\\" + name);
                        }
                    }
                    else
                    {
                        MessageBox.Show("对不起，插件未包含可用数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("出错啦！" + ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            if (mTreeNodeData == null
                || mTreeNodeData.Count <= 0)
            {
                MessageBox.Show("操作数据不足！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mSelectPath = txt_targetpath.Text.Trim();
            mSelectView = cb_select.SelectedItem.ToString();
            SetControlState(false);

            try
            {
                mDgCodeGenerate = new DgCodeGenerate(Start);
                mDgCodeGenerate.BeginInvoke(mTreeNodeData, AsyncCallback, mDgCodeGenerate);

                mDgEndCodeGenerate = new DgEndCodeGenerate(End);
                mDgWriteLog = new DgWriteLog(WriteLog);
            }
            catch (Exception ex)
            {
                MessageBox.Show("出错啦！" + ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt_targetpath.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        /// <summary>
        /// 开启异步写文件
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string Start(Dictionary<string, Module[]> data)
        {
            try
            {
                FileOperate file = new FileOperate(mSelectPath);
                file.ClearFile();

                while (file.CheckFile())
                {
                    Thread.Sleep(100);
                }

                foreach (string key in data.Keys)
                {
                    Module[] module = data[key];
                    foreach (Module mod in module)
                    {
                        Type[] typs = mod.GetTypes();
                        foreach (Type tp in typs)
                        {
                            if (mConfigData["filter"].ToString().Contains(tp.Name)) { continue; }

                            // Repository
                            Config con = new Config();
                            string classname = tp.Name + ModuleEnum.Repository.ToString();
                            string[] space = tp.Namespace.Split('.');
                            string secspace = "";
                            string sapceRepository = "";
                            string sapceIRepository = "";
                            if (space.Length > 2)
                            {
                                con.mSecFolderName = space[2];
                                if (con.mSecFolderName.Equals(TypeEnum.End.ToString()))
                                {
                                    sapceRepository = mConfigData["usingRepositoryEnd"].ToString();
                                    sapceIRepository = mConfigData["usingIRepositoryEnd"].ToString();
                                }
                                else if (con.mSecFolderName.Equals(TypeEnum.Front.ToString()))
                                {
                                    sapceRepository = mConfigData["usingRepositoryFront"].ToString();
                                    sapceIRepository = mConfigData["usingIRepositoryFront"].ToString();
                                }
                                secspace = "." + con.mSecFolderName;
                            }

                            con.mStringBuilder = new StringBuilder();
                            con.mStringBuilder.AppendLine(sapceRepository);
                            con.mStringBuilder.AppendLine("");
                            con.mStringBuilder.AppendLine("namespace " + mConfigData["namespace"]
                                + "." + ModuleEnum.Repository.ToString() + secspace);
                            con.mStringBuilder.AppendLine("{");
                            con.mStringBuilder.AppendLine("    public class " + classname + ":" + "BaseRepository<"
                                + tp.Name + ">," + mConfigData["namespace"] + "Context>, I" + classname);
                            con.mStringBuilder.AppendLine("    {");
                            con.mStringBuilder.AppendLine("        public " + classname + "(" + mConfigData["namespace"] + "Context context) : base(context) { }");
                            con.mStringBuilder.AppendLine("    }");
                            con.mStringBuilder.AppendLine("}");
                            con.mSuffix = "." + SuffixEnum.cs.ToString();
                            con.mFileName = classname;
                            con.mFolderName = ModuleEnum.Repository.ToString();
                            file.WriteFile(con);

                            // IRepository
                            con.mStringBuilder = new StringBuilder();
                            con.mStringBuilder.AppendLine(sapceIRepository);
                            con.mStringBuilder.AppendLine("");
                            con.mStringBuilder.AppendLine("namespace " + mConfigData["namespace"]
                                + "." + ModuleEnum.IRepository.ToString() + secspace);
                            con.mStringBuilder.AppendLine("{");
                            con.mStringBuilder.AppendLine("    public interface I" + classname + " : IBaseRepository<" + tp.Name
                                + ", " + mConfigData["namespace"] + "Context>{}");
                            con.mStringBuilder.AppendLine("}");
                            con.mSuffix = "." + SuffixEnum.cs.ToString();
                            con.mFileName = "I" + classname;
                            con.mFolderName = ModuleEnum.IRepository.ToString();
                            file.WriteFile(con);

                            // Views
                            con.mFolderName = ModuleEnum.Views.ToString();
                            con.mSuffix = "." + SuffixEnum.cshtml.ToString();
                            con.mStringBuilder = new StringBuilder();
                            con.mStringBuilder.AppendLine(LoadView(mSelectView, tp));
                            con.mFileName = "Index";
                            con.mSecFolderName = tp.Name;
                            file.WriteFile(con);

                            // Controllers
                            string lowerclassname = classname.Substring(0, 1).ToLower() + classname.Substring(1);

                            con.mFolderName = ModuleEnum.Controllers.ToString();
                            con.mSuffix = "." + SuffixEnum.cs.ToString();
                            con.mStringBuilder = new StringBuilder();
                            con.mStringBuilder.AppendLine(mConfigData["usingControllersEnd"].ToString());
                            con.mStringBuilder.AppendLine("");
                            con.mStringBuilder.AppendLine("namespace " + mConfigData["namespace"]
                                + "." + ModuleEnum.Controllers.ToString() + "." + TypeEnum.Common.ToString()
                                + "." + con.mFolderName + "." + TypeEnum.End.ToString());
                            con.mStringBuilder.AppendLine("{");
                            con.mStringBuilder.AppendLine("    public class " + tp.Name + "Controller : BaseCRUDController<" + tp.Name + ", InteriorDesignContext>");
                            con.mStringBuilder.AppendLine("    {");
                            con.mStringBuilder.AppendLine("        private I" + classname + " " + lowerclassname + ";");
                            con.mStringBuilder.AppendLine("        public " + tp.Name + "Controller()");
                            con.mStringBuilder.AppendLine("        {");
                            con.mStringBuilder.AppendLine("            " + lowerclassname + " = new " + classname + "(new " + mConfigData["namespace"] + "Context());");
                            con.mStringBuilder.AppendLine("            BaseReposity = " + lowerclassname + ";");
                            con.mStringBuilder.AppendLine("        }");
                            con.mStringBuilder.AppendLine("    }");
                            con.mStringBuilder.AppendLine("}");
                            con.mFileName = tp.Name + "Controller";
                            con.mSecFolderName = TypeEnum.End.ToString();
                            file.WriteFile(con);

                            //con.mFolderName = ModuleEnum.Controllers.ToString();
                            //con.mSuffix = "." + SuffixEnum.cs.ToString();
                            //con.mStringBuilder = new StringBuilder();
                            //con.mStringBuilder.AppendLine(mConfigData["usingControllersEnd"].ToString());
                            //con.mStringBuilder.AppendLine("");
                            //con.mStringBuilder.AppendLine("namespace " + mConfigData["namespace"]
                            //    + "." + ModuleEnum.Controllers.ToString() + "." + TypeEnum.End.ToString()
                            //    + "." + con.mFolderName);
                            //con.mFileName = tp.Name + "Controller";
                            //con.mSecFolderName = TypeEnum.End.ToString();
                            //file.WriteFile(con);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

            return "成功";
        }

        /// <summary>
        /// 加载视图模板
        /// </summary>
        /// <param name="viewNo"></param>
        private string LoadView(string viewNo, Type tp)
        {
            StreamReader r = null;

            if (About.mPbDic.ContainsKey(viewNo))
            {
                StringBuilder sbTh = new StringBuilder();
                StringBuilder sbTable = new StringBuilder();
                r = new StreamReader(About.mPbDic[viewNo]);
                string c = r.ReadToEnd();
                r.Close();

                PropertyInfo[] props = tp.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (PropertyInfo p in props)
                {
                    sbTh.AppendFormat("<th data-options=\"field:'{0}',width:80,sortable:true\">{0}</th>\r\n", "@Html.LabelFor(m => m." + p.Name + ")");
                    sbTable.AppendLine("<tr>");
                    sbTable.AppendFormat("<td>@Html.LabelFor(m => m.{0})：</td>", p.Name);
                    sbTable.AppendFormat("<td>@Html.TextBoxFor(m => m.{0}, new {{ @name = \"{0}\" }})</td>", p.Name);
                    sbTable.AppendLine("</tr>");
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat(
                    c,
                    "@model " + tp.Namespace + "." + tp.Name,
                    sbTh.ToString(),
                    tp.Name,
                    tp.Name + "Form",
                    sbTable.ToString());

                return sb.ToString();
            }

            return "";
        }

        /// <summary>
        /// 结束
        /// </summary>
        private void End()
        {
            SetControlState(true);

            mDgEndCodeGenerate = null;
            mDgCodeGenerate = null;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="msg"></param>
        private void WriteLog(string msg)
        {
            txt_log.Text += msg + "\r\n";
        }

        /// <summary>
        /// 异步回调
        /// </summary>
        /// <param name="ir"></param>
        private void AsyncCallback(IAsyncResult ir)
        {
            DgCodeGenerate cg = ir.AsyncState as DgCodeGenerate;
            string ret = cg.EndInvoke(ir);
            mTryCount++;
            if (!ret.Equals("成功") && mTryCount < 2)
            {
                cg.BeginInvoke(mTreeNodeData, AsyncCallback, cg);
            }
            else
            {
                if (mDgEndCodeGenerate != null)
                {
                    this.Invoke(mDgEndCodeGenerate);
                }
            }

            this.BeginInvoke(mDgWriteLog, ret);
        }

        /// <summary>
        /// 设置控件状态
        /// </summary>
        /// <param name="state"></param>
        private void SetControlState(bool state)
        {
            txt_targetpath.Enabled = state;
            btn_open.Enabled = state;
            btn_go.Enabled = state;
            tv_code.Enabled = state;
            tv_types.Enabled = state;
        }

        private void tv_code_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                if (!path.ToUpper().EndsWith(".DLL"))
                {
                    MessageBox.Show("对不起，只支持*.DLL类型文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadPlugin(path, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("出错啦！" + ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tv_code_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void tv_code_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeView tv = sender as TreeView;
                TreeNode tn = tv.SelectedNode;
                if (mTreeNodeData.ContainsKey(tn.Text))
                {
                    Module[] module = mTreeNodeData[tn.Text];
                    tv_types.Nodes.Clear();
                    foreach (Module mod in module)
                    {
                        Type[] typs = mod.GetTypes();
                        foreach (Type typ in typs)
                        {
                            tv_types.Nodes.Add(typ.Name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("出错啦！" + ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CodeMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mDgEndCodeGenerate = null;
            mDgCodeGenerate = null;
            mDgWriteLog = null;
        }

        private void btn_paste_Click(object sender, EventArgs e)
        {
            PasteBoard pb = new PasteBoard();
            if (pb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (pb.mIsSave)
                {
                    cb_select.DataSource = DataBing();
                }
            }
        }

        private List<string> DataBing()
        {
            string path = Application.StartupPath + "\\PasteBoard";
            if (Directory.Exists(path))
            {
                List<string> list = null;

                try
                {
                    list = new List<string>();
                    string[] filenames = Directory.GetFiles(path);
                    foreach (string item in filenames)
                    {
                        string name = item.Substring(item.LastIndexOf('\\') + 1);
                        list.Add(name);
                        if (!About.mPbDic.ContainsKey(name))
                        {
                            About.mPbDic.Add(name, item);
                        }
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
    }
}
