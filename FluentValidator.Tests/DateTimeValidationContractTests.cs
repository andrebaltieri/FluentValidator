using FluentValidator.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FluentValidator.Tests
{
    [TestClass]
    class DateTimeValidationContractTests
    {
        [TestMethod]
        [TestCategory("DateTimeValidation")]
        public void IsGreaterThan()
        {
            var date1 = DateTime.Now;
            var date2 = date1.AddMinutes(1);

            var wrong = new ValidationContract()
                .Requires()
                .IsGreaterThan(date2, date1, "DateTime", "Date 2 is greater than Date 1");

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(1, wrong.Notifications.Count);          
        }

        [TestMethod]
        [TestCategory("DateTimeValidation")]
        public void IsGreaterOrEqualsThan()
        {
            var date1 = DateTime.Now;
            var date2 = date1;

            var wrong = new ValidationContract()
                .Requires()
                .IsGreaterOrEqualsThan(date2, date1, "DateTime", "Date 2 is greater or equals than Date 1");

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(1, wrong.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("DateTimeValidation")]
        public void IsLowerThan()
        {
            var date1 = DateTime.Now;
            var date2 = date1.AddMinutes(-1);

            var wrong = new ValidationContract()
                .Requires()
                .IsLowerThan(date1, date2, "DateTime", "Date 1 is lower than Date 2");

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(1, wrong.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("DateTimeValidation")]
        public void IsLowerOrEqualsThan()
        {
            var date1 = DateTime.Now;
            var date2 = date1;

            var wrong = new ValidationContract()
                .Requires()
                .IsLowerOrEqualsThan(date1, date2, "DateTime", "Date 1 is lower than Date 2");

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(1, wrong.Notifications.Count);
        }
    }
}
