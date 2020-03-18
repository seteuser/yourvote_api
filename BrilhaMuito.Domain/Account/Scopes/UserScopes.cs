using System;
using System.Collections.Generic;
using System.Dynamic;
using BrilhaMuito.Domain.Account.Entities;

namespace BrilhaMuito.Domain.Account.Scopes
{
    public static class UserScopes
    {
        public static bool IsEmpty(this User user)
        {
            return user == null;
        }

        public static User ToUser(this ExpandoObject document)
        {
            var dictionary = (IDictionary<string, object>)document;
            return new User(Guid.Parse(dictionary["_id"].ToString()),
                dictionary.ContainsKey("FirstName") ? dictionary["FirstName"].ToString() : null,
                dictionary.ContainsKey("LastName") ? dictionary["LastName"].ToString() : null,
                dictionary.ContainsKey("Email") ? dictionary["Email"].ToString() : null,
                dictionary.ContainsKey("Password") ? dictionary["Password"].ToString() : null,
                dictionary.ContainsKey("Salt") ? dictionary["Salt"].ToString() : null,
                dictionary.ContainsKey("Active") && Convert.ToBoolean(dictionary["Active"].ToString()));
        }

        public static User ToUser(this IDictionary<string, object> dictionary)
        {
            return new User(Guid.Parse(dictionary["_id"].ToString()),
                dictionary.ContainsKey("FirstName") ? dictionary["FirstName"].ToString() : null,
                dictionary.ContainsKey("LastName") ? dictionary["LastName"].ToString() : null,
                dictionary.ContainsKey("Email") ? dictionary["Email"].ToString() : null,
                dictionary.ContainsKey("Password") ? dictionary["Password"].ToString() : null,
                dictionary.ContainsKey("Salt") ? dictionary["Salt"].ToString() : null,
                dictionary.ContainsKey("Active") && Convert.ToBoolean(dictionary["Active"].ToString()));
        }
    }
}