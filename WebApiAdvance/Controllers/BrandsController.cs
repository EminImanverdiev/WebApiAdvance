using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApiAdvance.DAL.EFCore;
using WebApiAdvance.DAL.Repositories.Abstract;
using WebApiAdvance.DAL.UnitOfWork.Abstract;
using WebApiAdvance.Entities;
using WebApiAdvance.Entities.DTOs.Brands;

namespace WebApiAdvance.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BrandsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Authorize (Roles ="User")]
        public async Task<ActionResult<List<GetBrandDto>>> GetAllBrands(int page=1,int size=15)
        {
            var brands = await _unitOfWork.BrandRepository.GetAllPaginatedAsync(page, size);

            var result = _mapper.Map<List<GetBrandDto>>(brands);

            return StatusCode((int)HttpStatusCode.OK, result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto dto)
        {
            var brand = _mapper.Map<Brand>(dto);
            await _unitOfWork.BrandRepository.AddAsync(brand);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(Guid id,UpdateBrandDto dto)
        {
            var brand = await _unitOfWork.BrandRepository.Get(b=>b.Id==id);
            if (brand != null)
            {
                brand.Name = dto.Name == null ? brand.Name : dto.Name;
                brand.Description = dto.Description == null ? brand.Description : dto.Description;
                brand.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.SaveAsync();
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
            var brand = await _unitOfWork.BrandRepository.Get(b => b.Id == id);

            if (brand != null)
            {
                return Ok(_mapper.Map<GetBrandDto>(brand));
            }
            return BadRequest(new
            {
                status = HttpStatusCode.BadRequest,
                message = "Brand tapilmadi"
            });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(Guid id)
        {
           var brand = await _unitOfWork.BrandRepository.Get(b=> b.Id == id);
           
            if(brand == null)
            {
                return NotFound();
            }
            _unitOfWork.BrandRepository.Delete(brand.Id);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}
