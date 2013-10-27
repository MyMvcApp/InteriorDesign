using System.Text;
using System.Threading.Tasks;
using InteriorDesign.IRepository.Front;
using InteriorDesign.Repository;
using InteriorDesign.Model.Front;
using InteriorDesign.Context;

namespace InteriorDesign.Repository.Front
{
    public class PagedPeoPleRepository : BaseRepository<PagedPeoPle, InteriorDesignContext>, IPagedPeoPleRepository
    {
        public PagedPeoPleRepository(InteriorDesignContext context): base(context){}
    }
}
