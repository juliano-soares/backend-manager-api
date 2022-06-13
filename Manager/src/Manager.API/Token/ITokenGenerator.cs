using Manager.Services.DTO;

namespace Manager.API.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(UserDTO userDTO);
    }
}