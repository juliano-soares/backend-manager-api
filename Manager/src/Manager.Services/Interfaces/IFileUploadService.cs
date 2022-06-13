using Manager.Services.DTO;

namespace Manager.Services.Interfaces
{
    public interface IFileUploadService
    {
        Task<UserDTO> UploadAvatarBase64Image(string base64Image, UserDTO userDTO);
    }
}

