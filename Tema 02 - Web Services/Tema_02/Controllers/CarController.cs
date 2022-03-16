using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tema_02.IService;
using Tema_02.Model;

namespace Tema_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : GenericController<Car>
    {
        public CarController(IGenericService<Car> genericService) : base(genericService)
        {

        }
    }
}
