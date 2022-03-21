using System.Threading.Tasks;
using CarDealership.Data;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership;
using CarDealership.Data.Models;

namespace CarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CostumerController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public CostumerController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = new Customer
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email
            };

            _dbContext.Customers.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }

        [HttpPut]
        public Task<IActionResult> Edit(Customer customer)
        {
            var _customer = _dbContext.Customers.FirstOrDefault(x => x.Id == customer.Id);
            if(_customer == null)
            {
                _customer.Name = customer.Name;
                _customer.Email = customer.Email;

                _dbContext.SaveChanges();
            }

            return Ok(_customer);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest(ModelState);
            }
            Customer costumer = _dbContext.Customers.Find(id);
            if (costumer == null)
            {
                return BadRequest(ModelState);
            }
            return Ok(costumer);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var costumer = await _dbContext.Customers.FindAsync(id);
            _dbContext.Customers.Remove(costumer);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AngajatExists(int id)
        {
            return _dbContext.Customers.Any(e => e.Id == id);
        }

    }
}