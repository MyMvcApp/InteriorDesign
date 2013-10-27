using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Model.Front
{
    /// <summary>
    /// 员工表
    /// </summary>
    public class PagedPeoPle : BaseModel
    {
        [Required(ErrorMessage = "人员的名称不能为空！")]
        [Display(Name = "员工名称")]
        public string Name { get; set; }
        [Required(ErrorMessage = "人员的年龄不能为空！")]
        [Display(Name = "员工年龄")]
        public int Age { get; set; }
        [Display(Name = "员工性别")]
        public bool Sex { get; set; }
    }
}
