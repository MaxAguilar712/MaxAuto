using Microsoft.AspNetCore.Mvc;
using MaxAuto.Models;
using MaxAuto.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaxAuto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        //private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUserRepository _userRepository;
        public UserProfileController(IUserRepository userRepository)
        {
            //_userProfileRepository = userProfileRepository;
            _userRepository = userRepository;
        }
        [HttpGet("GetByEmail")]
        public IActionResult GetByEmail(string email)
        {
            var user = _userRepository.GetByEmail(email);

            if (email == null || user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("GetById/{Id}")]
        public IActionResult GetById(int Id)
        {
            var user = _userRepository.GetById(Id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var profiles = _userRepository.GetAllProfiles();
            return Ok(profiles);
        }

        [HttpGet("GetByStatusId/{id}")]
        public IActionResult GetByStatusId(int id)
        {
            var profiles = _userRepository.GetByStatusId(id);
            return Ok(profiles);
        }

        [HttpPost]
        public IActionResult Post(UserProfile userProfile)    //POST method to SET the UserStatusId IF one isn't set already.
        {
            userProfile.CreateDateTime = DateTime.Now;
            userProfile.UserTypeId = UserType.AUTHOR_ID;
            _userRepository.Add(userProfile);
            if (userProfile.UserStatusId == 0)
            {
                userProfile.UserStatusId = UserStatus.ACTIVE_ID;
            }
            return CreatedAtAction(
                "GetByEmail",
                new { email = userProfile.Email },
                userProfile);
        }


        [HttpPut("UpdateUserStatus/{id}")]
        public IActionResult Put(int id, UserProfile user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _userRepository.UpdateStatusId(user);
            return NoContent();
        }
    }
}