using CustomerOrderManagement.Domain.Entities;
using CustomerOrderManagement.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();
            return Ok(orders);
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        // POST: api/Order
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (order == null)
                return BadRequest();

            order.SetOrderDate(DateTime.UtcNow); // Use the domain method

            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // PUT: api/Order/product/{id}
        [HttpPut("product/{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] Product product)
        {
            if (id != product.Id)
                return BadRequest();

            var existingProduct = await _unitOfWork.Products.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound();

            existingProduct.UpdateProduct(product.Name, product.Price);

            await _unitOfWork.Products.UpdateAsync(existingProduct);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        // PUT: api/Order/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] Order order)
        {
            if (id != order.Id)
                return BadRequest();

            var existingOrder = await _unitOfWork.Orders.GetByIdAsync(id);
            if (existingOrder == null)
                return NotFound();

            // Use the new SetOrderDate method if you added it
            existingOrder.SetOrderDate(DateTime.UtcNow);

            await _unitOfWork.Orders.UpdateAsync(existingOrder);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
                return NotFound();

            await _unitOfWork.Orders.DeleteAsync(order);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}