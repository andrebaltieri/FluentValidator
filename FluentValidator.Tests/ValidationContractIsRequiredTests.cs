using System;
using FluentValidator.Tests.Notifiables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidator.Tests
{
    [TestClass]
    public class ValidationContractIsRequiredTests
    {
        [TestMethod]
        [TestCategory("ValidationContract.IsRequired")]
        public void MustNotReturnNotificationsWhenRequeredStringPropertyIsValid()
        {
            var customer = new Customer { Name = "XXXXXX", UserName = "YYYYYY" };

            new ValidationContract<Customer>(customer)
                .IsRequired(x => x.Name)
                .IsRequired(x => x.UserName);

            Assert.IsTrue(customer.IsValid());
            Assert.AreEqual(0, customer.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("ValidationContract.IsRequired")]
        public void ShouldReturnNotificationsWhenRequeredStringPropertyIsNullOrEmpty()
        {
            var customer = new Customer { Name = null, UserName = string.Empty };

            new ValidationContract<Customer>(customer)
                .IsRequired(x => x.Name)
                .IsRequired(x => x.UserName);

            foreach (var notification in customer.Notifications)
                Console.WriteLine($"{notification.Property} -> {notification.Message}");

            Assert.IsFalse(customer.IsValid());
            Assert.AreEqual(2, customer.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("ValidationContract.IsRequired")]
        public void MustNotReturnNotificationsWhenRequiredPropertyIsValid()
        {
            var customer = new Customer { ActivationDate = new DateTime(2017, 02, 11) };

            new ValidationContract<Customer>(customer)
                .IsRequired(x => x.ActivationDate);

            Assert.IsTrue(customer.IsValid());
            Assert.AreEqual(0, customer.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("ValidationContract.IsRequired")]
        public void ShouldReturnNotificationsWhenRequeredPropertyIsNull()
        {
            var customer = new Customer { ActivationDate = null };

            new ValidationContract<Customer>(customer)
                .IsRequired(x => x.ActivationDate);

            foreach (var notification in customer.Notifications)
                Console.WriteLine($"{notification.Property} -> {notification.Message}");

            Assert.IsFalse(customer.IsValid());
            Assert.AreEqual(1, customer.Notifications.Count);
        }
    }
}