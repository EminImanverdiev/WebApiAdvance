using Microsoft.EntityFrameworkCore;
using WebApiAdvance.DAL.EFCore;
using WebApiAdvance.DAL.Repositories.Abstract;
using WebApiAdvance.DAL.Repositories.Abstracts;
using WebApiAdvance.DAL.Repositories.Concrete.EfCore;
using WebApiAdvance.DAL.Repositories.Concretes.EfCore;
using WebApiAdvance.DAL.UnitOfWork.Abstract;

namespace WebApiAdvance.DAL.UnitOfWork.Concrete
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApiDbContext _context;
        private readonly IBrandRepository _brandRepository;
        private readonly IProductRepository _prodcutRepository;
        public UnitOfWork(ApiDbContext context)
        {
            _context = context;
        }

        public IBrandRepository BrandRepository => _brandRepository ?? new EfBrandRepository(_context);

        public IProductRepository ProductRepository => _prodcutRepository ?? new EfProdcutRepository(_context);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
