using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using BrilhaMuito.Domain.Account.Entities;

namespace BrilhaMuito.Domain.Account.Scopes
{
    public static class SessionScopes
    {
        public static bool IsEmpty(this Session session)
        {
            return session == null;
        }


        public static Session ToSession(this ExpandoObject document)
        {
            var dictionary = (IDictionary<string, object>)document;
            var session = GetSession(dictionary);
            return session;
        }

        public static Session ToSession(this IDictionary<string, object> dictionary)
        {
            var session = GetSession(dictionary);
            return session;
        }

        private static Session GetSession(IDictionary<string, object> dictionary)
        {
            var interval = ((IDictionary<string, object>)dictionary["Interval"]).ToInterval();
            var memberObjects = (List<object>)dictionary["Members"];
            var members = memberObjects.Select(x => Guid.Parse(x.ToString())).ToArray();
            var session = new Session(Guid.Parse(dictionary["_id"].ToString()),
                Guid.Parse(dictionary["UserId"].ToString()),
                dictionary["Title"].ToString(), dictionary["Description"].ToString(), interval, members,
                dictionary["Token"].ToString(), bool.Parse(dictionary["Active"].ToString()));
            return session;
        }

    }
}