using System.Text.Json.Serialization;

namespace Manager.Services.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Avatar { get; set; }
        public string? Qrcode { get; set; }
        public string Linkedin { get; set; }
        public string Github { get; set; }
        public bool IsPresent { get; set; }
        public long Score { get; private set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Role { get; set; }

        public UserDTO()
        { }

        public UserDTO(
            long id, 
            string name, 
            string username, 
            string email, 
            string phone,
            string? avatar,
            string? qrcode, 
            string linkedin, 
            string github, 
            bool isPresent, 
            long score, 
            string password,
            string role
        )
        {
            Id = id;
            Name = name;
            Username = username;
            Email = email;
            Phone = phone;
            Avatar = avatar;
            Qrcode = qrcode;
            Linkedin = linkedin;
            Github = github;
            IsPresent = isPresent;
            Score = score;
            Password = password;
            Role = role;
        }
    }
}