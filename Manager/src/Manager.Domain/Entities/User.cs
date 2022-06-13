using Manager.Domain.Interfaces;
using Manager.Domain.Validators;

namespace Manager.Domain.Entities
{
    public class User : Base, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string? Phone { get; private set; }
        public string? Avatar { get; private set; }
        public string? QRCode { get; private set; }
        public bool IsPresent { get; private set; }
        public long? Score { get; private set; }
        public string Password { get; private set; }
        public string? Linkedin { get; private set; }
        public string? Github { get; private set; }
        public string Role { get; private set; }

        protected User() { }

        public User(string name,
            string username,
            string email,
            string? phone,
            string? avatar,
            string? qRCode,
            bool isPresent,
            long? score,
            string password,
            string? linkedin,
            string? github, string role)
        {
            Name = name;
            Username = username;
            Email = email;
            Phone = phone;
            Avatar = avatar;
            QRCode = qRCode;
            IsPresent = isPresent;
            Score = score;
            Password = password;
            Linkedin = linkedin;
            Github = github;
            Role = role;
        }

        public void SetName(string name)
        {
            Name = name;
            Validate();
        }

        public void SetUsername(string username)
        {
            Username = username;
            Validate();
        }

        public void SetEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void SetPhone(string phone)
        {
            Phone = phone;
            Validate();
        }

        public void SetAvatar(string avatar)
        {
            Avatar = avatar;
            Validate();
        }

        public void SetQRCode(string? qrcode)
        {
            QRCode = qrcode;
            Validate();
        }

        public void SetIsPresent(bool isPresent)
        {
            IsPresent = isPresent;
            Validate();
        }

        public void SetScore(long score)
        {
            Score = score;
            Validate();
        }

        public void SetPassword(string password)
        {
            Password = password;
            Validate();
        }

        public void SetLinkedin(string linkedin)
        {
            Linkedin = linkedin;
            Validate();
        }

        public void SetGithub(string github)
        {
            Github = github;
            Validate();
        }

        public void SetRole(string role)
        {
            Role = role;
            Validate();
        }

        public bool Validate() => base.Validate<UserValidator, User>(new UserValidator(), this);
    }
}