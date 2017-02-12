using System;
using FluentValidator.Tests.Notifiables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidator.Tests
{
    [TestClass]
    public class ValidationContractHasMaxLengthTests
    {
        [TestMethod]
        [TestCategory("ValidationContract.HasMinLength")]
        public void ShouldNotReturnNotificationsWhenStringPropertyLengthIsLessThanOrEqualToTheMaximumAllowed()
        {
            var customer = new Customer { Name = "12", UserName = "1234" };

            new ValidationContract<Customer>(customer)
                .HasMaxLength(x => x.Name, 4)
                .HasMaxLength(x => x.UserName, 4);

            Assert.IsTrue(customer.IsValid());
            Assert.AreEqual(0, customer.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("ValidationContract.HasMinLength")]
        public void ShouldNotReturnNotificationsWhenStringPropertyLengthIsGreaterThanTheMaximumAllowed()
        {
            var customer = new Customer { Name = "123456" };

            new ValidationContract<Customer>(customer)
                .HasMaxLength(x => x.Name, 4);

            foreach (var notification in customer.Notifications)
                Console.WriteLine($"{notification.Property} -> {notification.Message}");

            Assert.IsFalse(customer.IsValid());
            Assert.AreEqual(1, customer.Notifications.Count);
        }
    }
}