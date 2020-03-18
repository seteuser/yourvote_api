using System;
using System.Collections.Generic;
using System.Dynamic;
using BrilhaMuito.Domain.Account.Entities;

namespace BrilhaMuito.Domain.Account.Scopes
{
    public static class MemberScopes
    {
        public static bool IsEmpty(this Member member)
        {
            return member == null;
        }

        public static Member ToMember(this ExpandoObject document)
        {
            var dictionary = (IDictionary<string, object>)document;
            return new Member(
                Guid.Parse(dictionary["_id"].ToString()),
                Guid.Parse(dictionary["UserId"].ToString()),
                dictionary.ContainsKey("FirstName") ? dictionary["FirstName"].ToString() : null,
                dictionary.ContainsKey("LastName") ? dictionary["LastName"].ToString() : null,
                dictionary.ContainsKey("Email") ? dictionary["Email"].ToString() : null,
                dictionary.ContainsKey("Description") ? dictionary["Description"].ToString() : null,
                dictionary.ContainsKey("Birthday")
                    ? Convert.ToDateTime(dictionary["Birthday"].ToString())
                    : DateTime.MinValue,
                dictionary.ContainsKey("Active") && Convert.ToBoolean(dictionary["Active"].ToString())
            );
        }


        public static Member ToMember(this IDictionary<string, object> dictionary)
        {
            return new Member(Guid.Parse(dictionary["_id"].ToString()),
                Guid.Parse(dictionary["UserId"].ToString()),
                dictionary.ContainsKey("FirstName") ? dictionary["FirstName"].ToString() : null,
                dictionary.ContainsKey("LastName") ? dictionary["LastName"].ToString() : null,
                dictionary.ContainsKey("Email") ? dictionary["Email"].ToString() : null,
                dictionary.ContainsKey("Description") ? dictionary["Description"].ToString() : null,
                dictionary.ContainsKey("Birthday") ? Convert.ToDateTime(dictionary["Birthday"].ToString()).MyAge() :0,
                dictionary.ContainsKey("Birthday")
                    ? Convert.ToDateTime(dictionary["Birthday"].ToString())
                    : DateTime.MinValue,
                dictionary.ContainsKey("Active") && Convert.ToBoolean(dictionary["Active"].ToString())
            );
        }

        public static int MyAge(this DateTime date)
        {
            var today = DateTime.Today;
            int age = today.Year - date.Year;
            if (today < date.AddYears(age)) age--;

            return age;
        }
    }
}