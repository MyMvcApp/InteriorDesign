using System.Text;
using System.Threading.Tasks;
using InteriorDesign.IRepository;
using InteriorDesign.Repository;
using InteriorDesign.Model;
using InteriorDesign.Context;

namespace InteriorDesign.Repository
{
    public class PagedPeoPleRepository : BaseRepository<PagedPeoPle, InteriorDesignContext>, IPagedPeoPleRepository
    {
        public PagedPeoPleRepository(InteriorDesignContext context): base(context){}
    }
}
