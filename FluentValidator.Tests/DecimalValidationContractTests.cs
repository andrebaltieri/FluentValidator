﻿using System.Linq;
using FluentValidator.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidator.Tests
{
    [TestClass]
    public class DecimalValidationContractTests
    {
        [TestMethod]
        [TestCategory("DecimalValidation")]
        public void IsGreaterThanDecimal()
        {
            decimal v1 = 5;
            decimal v2 = 10;
            var wrong = new ValidationContract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2")
                .IsGreaterThan(1, 1M, "decimal", "V1 is not greater than v2"); // 1 is not greater than 1 :)

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(2, wrong.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .IsGreaterThan(v2, v1, "decimal", "V1 is not greater than v2");

            Assert.AreEqual(true, right.IsValid);
        }

        [TestMethod]
        [TestCategory("DecimalValidation")]
        public void IsGreaterThanDecimalWithParameters()
        {
            decimal v1 = 5;
            decimal v2 = 10;
            var message = new ValidationContract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "{0} is not greater than {1}")
                .Notifications
                .First()
                .Message;

            Assert.AreEqual($"{v1} is not greater than {v2}", message);
        }

        [TestMethod]
        [TestCategory("DecimalValidation")]
        public void IsGreaterThanDouble()
        {
            double v1 = 5;
            decimal v2 = 10;
            var wrong = new ValidationContract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2");

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(1, wrong.Notifications.Count);

            v1 = 10;
            v2 = 5;
            var right = new ValidationContract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2");

            Assert.AreEqual(true, right.IsValid);
        }

        [TestMethod]
        [TestCategory("DecimalValidation")]
        public void IsGreaterThanDoubleWithParameters()
        {
            double v1 = 5;
            decimal v2 = 10;
            var message = new ValidationContract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "{0} is not greater than {1}")
                .Notifications
                .First()
                .Message;

            Assert.AreEqual(message, $"{v1} is not greater than {v2}");
        }

        [TestMethod]
        [TestCategory("DecimalValidation")]
        public void IsGreaterThanFloat()
        {
            float v1 = 5;
            decimal v2 = 10;
            var wrong = new ValidationContract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2");

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(1, wrong.Notifications.Count);

            v1 = 10;
            v2 = 5;
            var right = new ValidationContract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2");

            Assert.AreEqual(true, right.IsValid);
        }

        [TestMethod]
        [TestCategory("DecimalValidation")]
        public void IsGreaterThanFloatWithParameters()
        {
            float v1 = 5;
            decimal v2 = 10;
            var message = new ValidationContract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "{0} is not greater than {1}")
                .Notifications
                .First()
                .Message;

           Assert.AreEqual($"{v1} is not greater than {v2}", message);
        }

        [TestMethod]
        [TestCategory("DecimalValidation")]
        public void IsGreaterThanInt()
        {
            int v1 = 5;
            decimal v2 = 10;
            var wrong = new ValidationContract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2");

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(1, wrong.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .IsGreaterThan(v2, v1, "decimal", "V1 is not greater than v2");

            Assert.AreEqual(true, right.IsValid);
        }

        [TestMethod]
        [TestCategory("DecimalValidation")]
        public void IsGreaterThanIntWithParameters()
        {
            int v1 = 5;
            decimal v2 = 10;

            var message = new ValidationContract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "{0:C} is not greater than {1}")
                .Notifications
                .First()
                .Message;

            Assert.AreEqual($"{v1:C} is not greater than {v2}", message);
            
        }
    }
}
