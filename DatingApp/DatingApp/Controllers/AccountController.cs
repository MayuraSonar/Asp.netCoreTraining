using System.Threading.Tasks;
using AutoMapper;
using DatingApp.Api.Services.Interfaces;
using DatingApp.ServiceModel.DTOs.Request;
using DatingApp.ServiceModel.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        private readonly ITokenService _tokenService;


        public AccountController(IAccountService accountService, ITokenService tokenService, IMapper mapper)
        {
            _accountService = accountService;
            _tokenService = tokenService;
            _mapper = mapper;

        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        // public async Task<ActionResult<RegisterDto>> Register(string name,string password)
        {
            if (await _accountService.UserExists(registerDto.Name))
                return BadRequest("UserName Already exists!!");
            var createUser = await _accountService.Register(registerDto.Name, registerDto.Password, registerDto.Gender);
            var response = _mapper.Map<UserDetailsDto>(createUser);
            return Ok(response);

        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequestDto loginRequestDto)
       
        {
            if (!await _accountService.UserExists(loginRequestDto.Name))
                return Unauthorized("Invalid UserName /Password");
                var response = await _accountService.Login(loginRequestDto.Name, loginRequestDto.Password);
            if (response == null)
                return Unauthorized("Invalid UserName /Password");
            var loginDtoResponse = _mapper.Map<LoginDto>(response);
            loginDtoResponse.Token = _tokenService.CreateToken(response);
                       return Ok(loginDtoResponse);

        }


    }
}

