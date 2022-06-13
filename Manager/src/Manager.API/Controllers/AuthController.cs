using AutoMapper;
using EscNet.Hashers.Interfaces.Algorithms;
using Manager.API.Token;
using Manager.API.Utilities;
using Manager.API.ViewModels;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IArgon2IdHasher _hasher;

        public AuthController(IConfiguration configuration, ITokenGenerator tokenGenerator, IUserService userService, IMapper mapper = null, IArgon2IdHasher hasher = null)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
            _userService = userService;
            _mapper = mapper;
            _hasher = hasher;
        }

        [HttpPost]
        [Route("/api/v1/auth/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
        {
            try
            {
                var user = await _userService.GetByEmail(loginViewModel.Email);
                var password = _hasher.Hash(loginViewModel.Password);
                
                if (loginViewModel.Email == user?.Email && password == user?.Password)
                {

                    UserDTO userDTO = _mapper.Map<UserDTO>(user);
                    return Ok(new ResultViewModel
                    {
                        Message = "Usuário autenticado com sucesso!",
                        Success = true,
                        Data = new
                        {
                            Token = _tokenGenerator.GenerateToken(userDTO),
                            TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                        }
                    });
                }
                else
                {
                    return StatusCode(401, Responses.UnauthorizedErrorMessage());
                }
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}