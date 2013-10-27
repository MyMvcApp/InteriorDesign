using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Model.End
{
    /// <summary>
    /// 后台管理员表
    /// </summary>
    public class AdminUser : BaseModel
    {
        [MaxLength(50)]
        [Display(Name="管理员名称")]
        public string AdminName { get; set; }
        [MaxLength(50)]
        [Display(Name = "管理员密码")]
        public string AdminPwd { get; set; }
        [Display(Name = "管理员真实名称")]
        public string RealName { get; set; }
        [Display(Name = "管理员最后登录时间")]
        public DateTime? LastLoginDate { get; set; }
        [Display(Name = "管理员最后登录IP")]
        public string LastLoginIp { get; set; }
        /// <summary>
        /// 0超级管理员1普通管理员
        /// </summary>
        [Display(Name = "管理员管理员类型")]
        public int AdminType { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        [Display(Name = "管理员登录次数")]
        public int LoginAmount { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Display(Name = "管理员手机号码")]
        public string Telephone { get; set; }
        [Display(Name = "QQ")]
        public string QQ { get; set; }

    }

    public class UpdatePwdParm
    {
        /// <summary>
        /// 旧密码
        /// </summary>
        public string AdminPwd { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        public string AdminNewPwd { get; set; }
    }
}
