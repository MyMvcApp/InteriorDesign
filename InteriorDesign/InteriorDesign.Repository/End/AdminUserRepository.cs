using System.Text;
using System.Threading.Tasks;
using InteriorDesign.IRepository.End;
using InteriorDesign.Repository;
using InteriorDesign.Model.End;
using InteriorDesign.Context;

namespace InteriorDesign.Repository.End
{
    public class AdminUserRepository : BaseRepository<AdminUser, InteriorDesignContext>, IAdminUserRepository
    {
        public AdminUserRepository(InteriorDesignContext context) : base(context) { }
    }
}
