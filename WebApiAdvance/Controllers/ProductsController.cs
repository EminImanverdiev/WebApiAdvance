using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAdvance.DAL.EFCore;
using WebApiAdvance.Entities;
using WebApiAdvance.Entities.DTOs.Products;

namespace WebApiAdvance.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IMapper _mapper;
        private readonly ApiDbContext _context;

        public ProductsController(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]

        public async Task<IActionResult> AddProduct(CreateProductDto dto)
        {
            Product newProduct = _mapper.Map<Product>(dto);

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return Ok(newProduct);

        }
        [HttpGet]

        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products.Include(p=>p.Brand).ToListAsync();
            var result = _mapper.Map<List<GetProdcutDto>>(products);
            return Ok(result);
        }   
    }
}
