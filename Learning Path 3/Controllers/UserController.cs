using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserById(Guid ID_User)
        {
            var user = await _userService.GetUserById(ID_User);
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddUser([FromBody]UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { ID_User = user.ID_User }, user);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateUser([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _userService.UpdateUser(user);
            return Ok();
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteUser (Guid ID_User)
        {
            _userService.DeleteUser(ID_User);
            return Ok();
        }

    }
}
