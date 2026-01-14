using WebApiAdvance.DAL.Repositories.Abstract;
using WebApiAdvance.DAL.Repositories.Abstracts;

namespace WebApiAdvance.DAL.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        public IBrandRepository BrandRepository { get; }
        public IProductRepository ProductRepository { get; }
        Task SaveAsync();

    }
}
