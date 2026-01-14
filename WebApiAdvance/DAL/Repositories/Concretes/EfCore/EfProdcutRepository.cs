using WebApiAdvance.Core.DAL.Repositories.Concrete.EFCore;
using WebApiAdvance.DAL.EFCore;
using WebApiAdvance.DAL.Repositories.Abstracts;
using WebApiAdvance.Entities;

namespace WebApiAdvance.DAL.Repositories.Concretes.EfCore
{
    public class EfProdcutRepository : EfBaseRepository<Product, ApiDbContext>, IProductRepository
    {
        public EfProdcutRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
