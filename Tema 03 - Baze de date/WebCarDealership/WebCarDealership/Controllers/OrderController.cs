using CarDealership.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership.Requests;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public OrderController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string sortOrder)
        {
            //var orders = await _dbContext.Customers.ToListAsync();

            var IdSortParm = String.IsNullOrEmpty(sortOrder) ? "idDesc" : "";

            var orders = from p in _dbContext.Orders
                         select p;

            switch (sortOrder)
            {
                case "idDesc":
                    orders = orders.OrderByDescending(p => p.Id);
                    break;
                default:
                    orders = orders.OrderBy(p => p.Id);
                    break;
            }

            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            var offer = await _dbContext.CarOffers.FirstOrDefaultAsync(offer => offer.Id == model.CarOfferId);
            if (offer == null)
            {
                return NotFound("car offer not found");
            }

            if (offer.AvailableStock <= model.Quantity)
            {
                return BadRequest("Not enough cars of this model are available in stock!");
            }

            offer.AvailableStock -= model.Quantity;

            var dbOrder = new Order()
            {
                CarOfferId = model.CarOfferId,
                CustomerId = model.CustomerId,
                Date = DateTime.UtcNow,
                Quantity = model.Quantity,
                OrderAmount = model.Quantity * offer.UnitPrice
            };
            _dbContext.Orders.Add(dbOrder);

            int numberOfRecordsAffected = await _dbContext.SaveChangesAsync();
            if (numberOfRecordsAffected == 0)
            {
            }

            return Ok(dbOrder);
        }



    }
}
