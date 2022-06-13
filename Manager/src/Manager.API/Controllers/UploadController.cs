using AutoMapper;
using Manager.API.Utilities;
using Manager.API.ViewModels;
using Manager.Core.Exceptions;
using Manager.Services.DTO;
using Microsoft.AspNetCore.Mvc;
using Manager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;

namespace Manager.API.Controllers
{
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFileUploadService _fileUploadService;

        public UploadController(IMapper mapper, IFileUploadService fileUploadService)
        {
            _mapper = mapper;
            _fileUploadService = fileUploadService;
        }

        [HttpPost]
        [Route("/api/v1/upload/avatar")]
        [Authorize]
        public async Task<IActionResult> UploadAvatar([FromBody] ImageUploadViewModel fileUploadAvatarViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(fileUploadAvatarViewModel);

                var imageSrc = Regex.Replace(fileUploadAvatarViewModel.Avatar, "data:image/(png|jpg|gif|jpeg|pjpeg|x-png);base64,", "");
                Regex regex = new Regex(@"^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$");
                Match match = regex.Match(imageSrc);
                if(!match.Success)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "A imagem informada não é válida.",
                        Success = false,
                        Data = null
                    });
                }
                
                var imageURL = await _fileUploadService.UploadAvatarBase64Image(fileUploadAvatarViewModel.Avatar, userDTO);
                Console.WriteLine(imageURL);
                return Ok(new ResultViewModel
                {
                    Message = "Avatar adicionado com sucesso!",
                    Success = true,
                    Data = imageURL
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        // TODO Upload de arquivos relacionados aos eventos
    }
}