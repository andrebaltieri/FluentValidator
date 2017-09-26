using FluentValidator.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FluentValidator.Tests
{
    [TestClass]
    public class DateTimeValidationContractTests
    {
        private Dummy _dummy;

        [TestMethod]
        [TestCategory("DateTimeValidation")]
        public void IsGreaterThan()
        {
            _dummy = new Dummy();
            _dummy.dateTimeProp = new DateTime(2005, 5, 15, 16, 0, 0);

            var wrong = new ValidationContract()
                .Requires()
                .IsGreaterThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMilliseconds(1), nameof(_dummy.dateTimeProp), "Date 1 should be greater than Date 2")
                .IsGreaterThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddSeconds(1), nameof(_dummy.dateTimeProp), "Date 1 should be greater than Date 2")
                .IsGreaterThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMinutes(1), nameof(_dummy.dateTimeProp), "Date 1 should be greater than Date 2");

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(3, wrong.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .IsGreaterThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMilliseconds(-2), nameof(_dummy.dateTimeProp), "Date 1 is not greater than Date 2")
                .IsGreaterThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddSeconds(-2), nameof(_dummy.dateTimeProp), "Date 1 is not greater than Date 2")
                .IsGreaterThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMinutes(-2), nameof(_dummy.dateTimeProp), "Date 1 is not greater than Date 2");

            Assert.AreEqual(true, right.IsValid);
        }

        [TestMethod]
        [TestCategory("DateTimeValidation")]
        public void IsGreaterOrEqualsThan()
        {
            _dummy = new Dummy();
            _dummy.dateTimeProp = new DateTime(2017, 1, 1, 12, 0, 0);

            var wrong = new ValidationContract()
                .Requires()
                .IsGreaterOrEqualsThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMilliseconds(1), nameof(_dummy.dateTimeProp), "Date 1 should be greater than Date 2")
                .IsGreaterOrEqualsThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddSeconds(1), nameof(_dummy.dateTimeProp), "Date 1 should be greater than Date 2")
                .IsGreaterOrEqualsThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMinutes(1), nameof(_dummy.dateTimeProp), "Date 1 should be greater than Date 2");

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(3, wrong.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .IsGreaterOrEqualsThan(_dummy.dateTimeProp, _dummy.dateTimeProp, nameof(_dummy.dateTimeProp), "Date 1 is not greater or equals than Date 2")
                .IsGreaterOrEqualsThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMilliseconds(-1), nameof(_dummy.dateTimeProp), "Date 1 is not greater or equals than Date 2")
                .IsGreaterOrEqualsThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddSeconds(-1), nameof(_dummy.dateTimeProp), "Date 1 is not greater or equals than Date 2")
                .IsGreaterOrEqualsThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMinutes(-1), nameof(_dummy.dateTimeProp), "Date 1 is not greater or equals than Date 2");

            Assert.AreEqual(true, right.IsValid);
        }

        [TestMethod]
        [TestCategory("DateTimeValidation")]
        public void IsLowerThan()
        {
            _dummy = new Dummy();
            _dummy.dateTimeProp = new DateTime(2017, 9, 26, 15, 0, 0);

            var wrong = new ValidationContract()
                .Requires()
                .IsLowerThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMilliseconds(-1), nameof(_dummy.dateTimeProp), "Date 1 should be lower than Date 2")
                .IsLowerThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddSeconds(-1), nameof(_dummy.dateTimeProp), "Date 1 should be lower than Date 2")
                .IsLowerThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMinutes(-1), nameof(_dummy.dateTimeProp), "Date 1 should be lower than Date 2");

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(3, wrong.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .IsLowerThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMilliseconds(1),nameof(_dummy.dateTimeProp), "Date 1 is not lower than Date 2")
                .IsLowerThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddSeconds(1), nameof(_dummy.dateTimeProp), "Date 1 is not lower than Date 2")
                .IsLowerThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMinutes(1), nameof(_dummy.dateTimeProp), "Date 1 is not lower than Date 2");

            Assert.AreEqual(true, right.IsValid);
        }

        [TestMethod]
        [TestCategory("DateTimeValidation")]
        public void IsLowerOrEqualsThan()
        {
            _dummy = new Dummy();
            _dummy.dateTimeProp = new DateTime(2005, 5, 15, 16, 0, 0);

            var wrong = new ValidationContract()
                .Requires()
                .IsLowerOrEqualsThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMilliseconds(-1), nameof(_dummy.dateTimeProp), "Date 1 should be lower or equals than Date 2")
                .IsLowerOrEqualsThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddSeconds(-1), nameof(_dummy.dateTimeProp), "Date 1 should be lower or equals than Date 2")
                .IsLowerOrEqualsThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMinutes(-1), nameof(_dummy.dateTimeProp), "Date 1 should be lower or equals than Date 2");

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(3, wrong.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .IsLowerOrEqualsThan(_dummy.dateTimeProp, _dummy.dateTimeProp, nameof(_dummy.dateTimeProp), "Date 1 is not lower or equals than Date 2")
                .IsLowerOrEqualsThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMilliseconds(1), nameof(_dummy.dateTimeProp), "Date 1 is not lower or equals than Date 2")
                .IsLowerOrEqualsThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddSeconds(1), nameof(_dummy.dateTimeProp), "Date 1 is not lower or equals than Date 2")
                .IsLowerOrEqualsThan(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMinutes(1), nameof(_dummy.dateTimeProp), "Date 1 is not lower or equals than Date 2");

            Assert.AreEqual(true, right.IsValid);
        }

        [TestMethod]
        [TestCategory("DateTimeValidation")]
        public void AreEquals()
        {
            _dummy = new Dummy();
            _dummy.dateTimeProp = new DateTime(2017, 9, 26, 18, 0, 0);

            var wrong = new ValidationContract()
                .Requires()
                .AreEquals(_dummy.dateTimeProp, _dummy.dateTimeProp.AddMilliseconds(-1), nameof(_dummy.dateTimeProp), "Date 1 should be equal to Date 2");               

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(1, wrong.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .AreEquals(_dummy.dateTimeProp, _dummy.dateTimeProp, nameof(_dummy.dateTimeProp), "Date 1 is not equals to Date 2");

            Assert.AreEqual(true, right.IsValid);
        }
    }
}
