using Microsoft.AspNetCore.Mvc;
using MaxAuto.Repositories;
using MaxAuto.Models;




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



        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
