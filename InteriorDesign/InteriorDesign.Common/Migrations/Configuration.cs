using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using InteriorDesign.Model.End;
using InteriorDesign.Helper;
using InteriorDesign.Context;
namespace InteriorDesign.Common.Migrations
{
    //根据对应的Model的更改，支持数据库自动迁移，如果需要查看迁移生成的脚本请使用Update-Database -Verbose命令在程序包管理器控制台输出
    internal sealed class Configuration : DbMigrationsConfiguration<InteriorDesignContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(InteriorDesignContext context)
        {
            context.AdminUser.AddOrUpdate(p=>p.AdminName, new AdminUser() {  AdminName="admin", AdminPwd=WebHelper.GetMD5Hash("123"), AdminType=0, LoginAmount=1});
        }
    }
}
