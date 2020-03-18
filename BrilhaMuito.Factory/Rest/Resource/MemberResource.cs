using System;
using BrilhaMuito.Factory.Extension;

namespace BrilhaMuito.Factory.Rest.Resource
{
    public class MemberResource
    {
        public MemberResource() { }

        public MemberResource(Guid memberId, Guid userId, string firstName, string lastName, string email, string description, int age, DateTime birthday, bool active)
        {
            MemberId = memberId;
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Description = description;
            Age = age;
            Birthday = birthday;
            Active = active;
        }

        public Guid MemberId { get; set; }

        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        public bool Active { get; set; }
    }
}