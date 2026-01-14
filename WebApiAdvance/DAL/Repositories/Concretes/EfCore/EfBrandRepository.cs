using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiAdvance.Core.DAL.Repositories.Concrete.EFCore;
using WebApiAdvance.DAL.EFCore;
using WebApiAdvance.DAL.Repositories.Abstract;
using WebApiAdvance.Entities;

namespace WebApiAdvance.DAL.Repositories.Concrete.EfCore
{
    public class EfBrandRepository : EfBaseRepository<Brand, ApiDbContext>,IBrandRepository
    {
        public EfBrandRepository(ApiDbContext context) : base(context)
        {
        }

        public Brand GetBrandById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
