using MaxAuto.Models;
using MaxAuto.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace MaxAuto.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class CarPartController : Controller
        {

            private readonly ICarPartRepository _carPartRepository;
            public CarPartController(ICarPartRepository carPartRepository)
            {
                _carPartRepository = carPartRepository;
            }

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_carPartRepository.GetAll());
            }


        [HttpGet("GetParts")]
        public IActionResult GetPart()
        {
            return Ok(_carPartRepository.GetParts());
        }

        [HttpGet("{id}")]
            public IActionResult Get(int id)
            {
                var carpart = _carPartRepository.GetById(id);
                if (carpart == null)
                {
                    return NotFound();
                }
                return Ok(carpart);
            }

            [HttpPost]
            public IActionResult Post(CarPart carpart)
            {   
            _carPartRepository.Add(carpart);
            return CreatedAtAction("Get", new { id = carpart.Id }, carpart);
            }

    }

}

