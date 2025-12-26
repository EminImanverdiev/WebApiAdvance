using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAdvance.DAL.EFCore;
using WebApiAdvance.Entities;
using WebApiAdvance.Entities.DTOs.Orders;

namespace WebApiAdvance.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IMapper _mapper;
        private readonly ApiDbContext _context;

        public OrdersController(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]

        public async Task <ActionResult<List<GetOrderDto>>> GetAllOrders()
        {
            var orders = await _context.Orders.ToListAsync();

            return Ok(_mapper.Map<List<GetOrderDto>>(orders));

        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            var order = _mapper.Map<Order>(createOrderDto);

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete]

        public async Task<IActionResult> RemoveOrder(Guid id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpPut]
        public async Task<IActionResult>UpdateOrder(Guid id, CreateOrderDto dto)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, order);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult>GetOrderbyId(Guid id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetOrderDto>(order));
        }
    }
}
