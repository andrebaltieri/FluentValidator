using FluentValidator.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

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
        public void IsGreaterThanWithParameters()
        {
            _dummy = new Dummy { dateTimeProp = new DateTime(2005, 5, 15, 16, 0, 0) };
            var comparer = _dummy.dateTimeProp.AddMilliseconds(1);

            var wrong = new ValidationContract()
                .Requires()
                .IsGreaterThan(_dummy.dateTimeProp, comparer, nameof(_dummy.dateTimeProp), "Date {0:dd/MM/yyyy HH:mm:ss} should be greater than Date {1:D}");

            var message = wrong.Notifications.First().Message;

            Assert.AreEqual($"Date {_dummy.dateTimeProp:dd/MM/yyyy HH:mm:ss} should be greater than Date {comparer:D}", message);
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
        public void IsGreaterOrEqualsThanWithParameters()
        {
            _dummy = new Dummy();
            _dummy.dateTimeProp = new DateTime(2017, 1, 1, 12, 0, 0);
            var comparer = _dummy.dateTimeProp.AddMilliseconds(1);

            var wrong = new ValidationContract()
                .Requires()
                .IsGreaterOrEqualsThan(_dummy.dateTimeProp, comparer, nameof(_dummy.dateTimeProp),
                    "Date {0} is not greater or equals than Date {1}");

            var message = wrong.Notifications.First().Message;

            Assert.AreEqual($"Date {_dummy.dateTimeProp} is not greater or equals than Date {comparer}", message);
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
        public void IsLowerThanWithParameters()
        {
            _dummy = new Dummy();
            _dummy.dateTimeProp = new DateTime(2017, 9, 26, 15, 0, 0);
            var comparer = _dummy.dateTimeProp.AddMilliseconds(-1);

            var wrong = new ValidationContract()
                .Requires()
                .IsLowerThan(_dummy.dateTimeProp, comparer, nameof(_dummy.dateTimeProp),
                    "Date {0} should be lower than Date {1}");



            var message = wrong.Notifications.First().Message;

            Assert.AreEqual($"Date {_dummy.dateTimeProp} should be lower than Date {comparer}", message);
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
        public void IsLowerOrEqualsThanWithParameters()
        {
            _dummy = new Dummy();
            _dummy.dateTimeProp = new DateTime(2005, 5, 15, 16, 0, 0);
            var comparer = _dummy.dateTimeProp.AddMilliseconds(-1);

            var wrong = new ValidationContract()
                .Requires()
                .IsLowerOrEqualsThan(_dummy.dateTimeProp, comparer, nameof(_dummy.dateTimeProp),
                    "Date {0} should be lower than Date {1}");



            var message = wrong.Notifications.First().Message;

            Assert.AreEqual($"Date {_dummy.dateTimeProp} should be lower than Date {comparer}", message);
        }
    }
}
