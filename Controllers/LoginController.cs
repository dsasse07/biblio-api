using AutoMapper;
using BiblioApi.Dtos.Auth;
using BiblioApi.Dtos.User;
using BiblioApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiblioApi.Controllers
{

    [ApiController]
    [Route("rpc-api")]
    public class LoginController : ControllerBase
    {
        private readonly IUsersService _userService;
        private readonly IMapper _mapper;

        public LoginController(
            IUsersService userService,
            IMapper mapper
        )
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public ActionResult<UserDto> LoginUser(LoginDto loginInfo){
            var existingUser = _userService.GetUserByFirstName(loginInfo.FirstName);

            if (existingUser is null){
                return NotFound();
            }

            var userDto = _mapper.Map<UserDto>(existingUser);
            return Ok(userDto);
        }

    }
}