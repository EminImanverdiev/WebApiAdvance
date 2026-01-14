using System.Linq.Expressions;
using WebApiAdvance.Core.DAL.Repositories.Abstract;
using WebApiAdvance.Entities;

namespace WebApiAdvance.DAL.Repositories.Abstract
{
    public interface IBrandRepository:IRepository<Brand>
    {
        public Brand GetBrandById(int id);
   
    }
}

