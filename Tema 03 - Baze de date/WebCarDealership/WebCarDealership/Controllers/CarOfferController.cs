using System.Threading.Tasks;
using CarDealership.Data;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership;

namespace CarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarOfferController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public CarOfferController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var offers = await _dbContext.CarOffers.ToListAsync();
            return Ok(offers);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarOfferRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = new CarOffer
            {
                Make = model.Make,
                Model = model.Model,
                AvailableStock = model.AvailableStock,
                UnitPrice = model.UnitPrice
            };

            _dbContext.CarOffers.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }

        [HttpPut]
        public Task<IActionResult> Edit(CarOffer carOffer)
        {
            var _carOffer = _dbContext.CarOffers.FirstOrDefault(x => x.Id == carOffer.Id);
            if (_carOffer == null)
            {
                _carOffer.Make = carOffer.Make;
                _carOffer.Model = carOffer.Model;
                _carOffer.AvailableStock = carOffer.AvailableStock;
                _carOffer.UnitPrice = carOffer.UnitPrice;

                _dbContext.SaveChanges();
            }

            return Ok(_carOffer);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest(ModelState);
            }
            CarOffer carOffer = _dbContext.CarOffers.Find(id);
            if (carOffer == null)
            {
                return BadRequest(ModelState);
            }
            return Ok(carOffer);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carOffer = await _dbContext.CarOffers.FindAsync(id);
            _dbContext.CarOffers.Remove(carOffer);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AngajatExists(int id)
        {
            return _dbContext.CarOffers.Any(e => e.Id == id);
        }
    }
}