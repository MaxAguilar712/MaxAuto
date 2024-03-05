using Microsoft.AspNetCore.Mvc;
using MaxAuto.Repositories;
using MaxAuto.Models;
using Azure;




namespace MaxAuto.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarGarageController : Controller
    {

        private readonly ICarGarageRepository _carGarageRepository;
        public CarGarageController(ICarGarageRepository carGarageRepository)
        {
            _carGarageRepository = carGarageRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_carGarageRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var garagecar = _carGarageRepository.GetByUserId(id);
            if (garagecar == null)
            {
                return NotFound();
            }
            return Ok(garagecar);
        }

        [HttpPost]
        public IActionResult Post(CarGarage garagecar)
        {
            _carGarageRepository.Add(garagecar);
            return CreatedAtAction("Get", new { id = garagecar.Id }, garagecar);
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
