using MaxAuto.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MaxAuto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : Controller
    {




        private readonly IPartRepository _partRepository;
        public PartController(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_partRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var car = _partRepository.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
    }
}