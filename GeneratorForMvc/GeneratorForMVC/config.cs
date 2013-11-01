using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GeneratorForMVC
{
    public class About
    {
        public static Dictionary<string, string> mPbDic = new Dictionary<string, string>();
    }

    public class Config
    {
        /// <summary>
        /// 放置的文件夹名
        /// </summary>
        public string mFolderName { get; set; }

        /// <summary>
        /// 放置的二级文件夹名
        /// </summary>
        public string mSecFolderName { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public StringBuilder mStringBuilder { get; set; }

        /// <summary>
        /// 生成的文件名
        /// </summary>
        public string mFileName { get; set; }

        /// <summary>
        /// 后缀名
        /// </summary>
        public string mSuffix { get; set; }

        /// <summary>
        /// 属于哪个模块
        /// </summary>
        public ModuleEnum mModule { get; set; }
    }

    /// <summary>
    /// 模块枚举
    /// </summary>
    public enum ModuleEnum
    {
        Repository,
        IRepository,
        Controllers,
        Views
    }

    /// <summary>
    /// 前台后台
    /// </summary>
    public enum TypeEnum
    { 
        Front,
        End,
        Common
    }

    /// <summary>
    /// 后缀名枚举
    /// </summary>
    public enum SuffixEnum
    { 
        cs,
        cshtml
    }

    public class FileOperate
    {
        private string mBasePath = "CodeData\\";
        private string mStartupPath = Application.StartupPath + "\\";
        private string mFullPath = "";

        public FileOperate(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                mStartupPath = path;
            }

            mFullPath = mStartupPath + mBasePath;
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public void WriteFile(Config con)
        {
            StreamWriter Writer = null;
            string path = "";

            try
            {
                if (!Directory.Exists(mFullPath))
                {
                    Directory.CreateDirectory(mFullPath);
                }

                if (!Directory.Exists(mFullPath + con.mFolderName))
                {
                    Directory.CreateDirectory(mFullPath + con.mFolderName);
                }

                if (!string.IsNullOrEmpty(con.mSecFolderName))
                {
                    if (!Directory.Exists(mFullPath + con.mFolderName + "\\" + con.mSecFolderName))
                    {
                        Directory.CreateDirectory(mFullPath + con.mFolderName + "\\" + con.mSecFolderName);
                    }
                }
                path = mFullPath + con.mFolderName + "\\" + con.mSecFolderName + "\\" + con.mFileName + con.mSuffix;

                Writer = new StreamWriter(path, true);
                Writer.Write(con.mStringBuilder.ToString());

                Writer.Flush();
                Writer.Close();
            }
            catch(Exception ex)
            {
                if (Writer != null)
                {
                    Writer.Flush();
                    Writer.Close();
                }

                throw ex;
            }
        }

        /// <summary>
        /// 清空文件夹(线程操作)
        /// </summary>
        /// <returns></returns>
        public void ClearFile()
        {
            try
            {
                if (Directory.Exists(mFullPath))
                {
                    Directory.Delete(mFullPath, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 验证文件是否存在
        /// </summary>
        /// <returns></returns>
        public bool CheckFile()
        {
            return Directory.Exists(mFullPath);
        }
    }
}
