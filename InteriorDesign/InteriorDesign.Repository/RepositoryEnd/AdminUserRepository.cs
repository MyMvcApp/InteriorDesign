using System.Text;
using System.Threading.Tasks;
using InteriorDesign.IRepository;
using InteriorDesign.Repository;
using InteriorDesign.Model;
using InteriorDesign.Context;

namespace InteriorDesign.Repository
{
    public class AdminUserRepository : BaseRepository<AdminUser, InteriorDesignContext>, IAdminUserRepository
    {
        public AdminUserRepository(InteriorDesignContext context) : base(context) { }
    }
}
