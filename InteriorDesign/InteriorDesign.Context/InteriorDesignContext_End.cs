using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using InteriorDesign.Model;

namespace InteriorDesign.Context
{
    //后端基础模块的表
    public partial class InteriorDesignContext
    {
        public DbSet<AdminUser> AdminUser { get; set; }
    }
}
