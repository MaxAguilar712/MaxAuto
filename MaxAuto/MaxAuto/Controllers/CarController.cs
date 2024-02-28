
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MaxAuto.Repositories;
using MaxAuto.Models;


namespace MaxAuto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
  



        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_carRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var car = _carRepository.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
        //[HttpGet("{id}/PostWithComments")]
        //public IActionResult GetPostWithComments(int id)
        //{
        //    var post = _postRepository.GetByIdWithComments(id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(post);
        //}


        //[HttpGet("GetWithComments")]
        //public IActionResult GetWithComments()
        //{
        //    var posts = _postRepository.GetAllWithComments();
        //    return Ok(posts);
        //}
        ////for later
        //[HttpGet("search")]
        //public IActionResult Search(string q, bool sortDesc)
        //{
        //    return Ok(_postRepository.Search(q, sortDesc));
        //}
        //[HttpGet("Hottest")]
        //public IActionResult SearchHottest(DateTime since)
        //{
        //    var posts = _postRepository.SearchHottest(since);
        //    return Ok(posts);
        //}
        //[HttpPost]
        //public IActionResult Post(Post post)
        //{
        //    _postRepository.Add(post);
        //    return CreatedAtAction("Get", new { id = post.Id }, post);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, Post post)
        //{
        //    if (id != post.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _postRepository.Update(post);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _postRepository.Delete(id);
        //    return NoContent();
        //}
    }
}