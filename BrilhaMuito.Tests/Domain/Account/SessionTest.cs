using System;
using FluentAssertions;
using NUnit.Framework;

namespace BrilhaMuito.Tests.Domain.Account
{
    [TestFixture]
    public class SessionTest
    {

        [Test]
        public void Verfiy_Session_Is_Closed()
        {
            var startDate = new DateTime(2017, 10, 04);
            var endDate = new DateTime(2018, 10, 05);
            var isClosed =  DateTime.Today > startDate && DateTime.Today >= endDate;
            isClosed.Should().BeTrue();
        }
    }
}
