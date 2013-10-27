using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using InteriorDesign.Model.Front;
namespace InteriorDesign.Context
{
    //前端的表
    public partial class InteriorDesignContext : DbContext
    {
        //EF Code First采用直接加载的模式不用Lazy模式
        public InteriorDesignContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        //添加前台用到的表
        public DbSet<PagedPeoPle> PagedPeoPle { get; set; }

       
    }
}
