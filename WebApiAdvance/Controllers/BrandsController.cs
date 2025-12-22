using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApiAdvance.DAL.EFCore;
using WebApiAdvance.Entities;
using WebApiAdvance.Entities.DTOs.Brands;

namespace WebApiAdvance.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        IMapper _mapper;

        public BrandsController(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetBrandDto>>> GetAllBrands()
        {
            var result = await _context.Brands.Select(b => new GetBrandDto
            {
                Name = b.Name
            }).ToListAsync();
           
            return StatusCode((int)HttpStatusCode.OK, result);
        }
        [HttpPost]
        
        public async Task<IActionResult> CreateBrand(CreateBrandDto dto)
        {
            var brand = _mapper.Map<Brand>(dto);
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(Guid id,UpdateBrandDto dto)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(b=>b.Id==id);
            if (brand != null)
            {
                brand.Name = dto.Name;
                brand.Description = dto.Description;
                brand.UpdatedAt = DateTime.UtcNow;
                _context.Brands.Update(brand);
                await _context.SaveChangesAsync();
                return Ok();
               
            }
            return BadRequest(new
            {
                status = HttpStatusCode.BadRequest,
                message = "Brand tapilmadi"
            });

        }
        [HttpGet]
        public async Task<ActionResult<GetBrandDto>> GetBrandById(Guid id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (brand != null)
            {
                GetBrandDto dto = new GetBrandDto()
                {
                    Name = brand.Name
                };
                return Ok(dto);
            }
            return BadRequest(new
            {
                status = HttpStatusCode.BadRequest,
                message = "Brand tapilmadi"
            });
        }



    }
}
