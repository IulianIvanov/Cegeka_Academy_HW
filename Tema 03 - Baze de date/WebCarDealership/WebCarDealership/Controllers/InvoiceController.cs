using System.Threading.Tasks;
using CarDealership.Data;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership;
using WebCarDealership.Requests;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public InvoiceController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var invoices = await _dbContext.Invoices.ToListAsync();
            return Ok(invoices);
        }


        [HttpPost]
        public async Task<IActionResult> Post(InvoiceRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invoice = await _dbContext.Invoices.FirstOrDefaultAsync(invoice => invoice.Id == model.InvoiceId);
            if (invoice == null)
            {
                return NotFound("invoice not found");
            }

            var dbInvoice = new Invoice()
            {
                Id = model.InvoiceId,
                CustomerId = model.CustomerId,
                InvoiceDate = DateTime.UtcNow,
                InvoiceNumber = model.InvoiceNumber,
                Amount = model.Amount
            };
            _dbContext.Invoices.Add(dbInvoice);

            int numberOfRecordsAffected = await _dbContext.SaveChangesAsync();

            return Ok(dbInvoice);
        }



    }
}
