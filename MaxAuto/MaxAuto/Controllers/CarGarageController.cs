using Microsoft.AspNetCore.Mvc;
using MaxAuto.Repositories;
using MaxAuto.Models;
using Azure;
using Microsoft.Data.SqlClient;




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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _carGarageRepository.Delete(id);
                return NoContent();
            }
            catch (SqlException ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine("SQL Exception occurred: " + ex.Message);
                return StatusCode(500, "An error occurred while deleting the post.");
            }
        }


        [HttpGet("GetById/{Id}")]
        public IActionResult GetById(int Id)
        {
            var garagecar = _carGarageRepository.GetById(Id);

            if (garagecar == null)
            {
                return NotFound();
            }
            return Ok(garagecar);
        }



        [HttpPut("UpdateNickName/{id}")]
        public IActionResult Put(int id, CarGarage garagecar)
        {
            if (id != garagecar.Id)
            {
                return BadRequest();
            }

            _carGarageRepository.UpdateNickName(garagecar);
            return NoContent();
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
