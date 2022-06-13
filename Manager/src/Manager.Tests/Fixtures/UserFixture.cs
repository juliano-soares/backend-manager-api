using System.Collections.Generic;
using Bogus;
using Bogus.DataSets;
using Manager.Domain.Entities;
using Manager.Services.DTO;

namespace Manager.Tests.Fixture
{
    public class UserFixture
    {
        public static User CreateValidUser()
        {
            return new User(
                name: new Name().FirstName(),
                username: new Name().FirstName(),
                email: new Internet().Email(),
                phone: "99999999999",
                avatar: "",
                qRCode: "",
                isPresent: true,
                score: 0,
                password: new Internet().Password(),
                linkedin: "",
                github: "",
                role: ""
            );
        }

        public static List<User> CreateListUsers(int limit = 5)
        {
            var list = new List<User>();

            for (int i = 0; i < limit; i++)
                list.Add(CreateValidUser());

            return list;
        }

        public static UserDTO CreateValidUserDTO(bool newId = false)
        {
            return new UserDTO
            {
                Id = newId ? new Randomizer().Int(0, 1000) : 0,
                Name = new Name().FirstName(),
                Email = new Internet().Email(),
                Password = new Internet().Password()
            };
        }

        public static UserDTO CreateInvalidUserDTO()
        {
            return new UserDTO
            {
                Id = 0,
                Name = "",
                Email = "",
                Password = ""
            };
        }
    }
}