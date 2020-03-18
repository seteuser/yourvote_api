using System;

namespace BrilhaMuito.Domain.Account.Entities
{
    public class User : IEntityBase
    {
        public User(Guid userId, string firstName, string lastName, string email, string password, string salt, bool active)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Salt = salt;
            Active = active;
        }

        public User() { }

        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public bool Active { get; set; }

        public string FullName => $"{FirstName} {LastName}";

    }
}