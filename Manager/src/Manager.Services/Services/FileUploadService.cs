using AutoMapper;
using Azure.Storage.Blobs;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using System.Text.RegularExpressions;

namespace Manager.Services.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public FileUploadService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> UploadAvatarBase64Image(string base64Image, UserDTO userDTO)
        {
            var user = await _userRepository.GetByEmail(userDTO.Email);

            if (user == null)
            {
                throw new DomainException("Usuário não encontrado.");
            }

            var type = base64Image.Split(';')[0].Split('/');
            var filename = user.Id + "." + type[1].ToString();

            var imageSrc = Regex.Replace(base64Image, "data:image/(png|jpg|gif|jpeg|pjpeg|x-png);base64,", "");
            byte[] imageBytes = Convert.FromBase64String(imageSrc);
            var blobClient = new BlobClient("CNN STRING AZURE", "avatar", filename);

            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream);
            }

            user.Validate();
            user.SetAvatar(blobClient.Uri.AbsoluteUri);

            var userUpdated = await _userRepository.Update(user);
            return _mapper.Map<UserDTO>(userUpdated);
        }
    }
}
