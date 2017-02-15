using System;
using FluentValidator.Tests.Notifiables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidator.Tests
{
    [TestClass]
    public class ValidationContractHasMinLengthTests
    {
        [TestMethod]
        [TestCategory("ValidationContract.HasMinLength")]
        public void ShouldNotReturnNotificationsWhenStringPropertyHasRequiredMinimumLength()
        {
            var customer = new Customer { Name = "1234", UserName = "123456"};

            new ValidationContract<Customer>(customer)
                .HasMinLength(x => x.Name, 4)
                .HasMinLength(x => x.UserName, 4);

            Assert.IsTrue(customer.IsValid());
            Assert.AreEqual(0, customer.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("ValidationContract.HasMinLength")]
        public void ShouldReturnNotificationsWhenStringPropertyDoesNotHaveRequiredMinimumLength()
        {
            var customer = new Customer { Name = "123" };

            new ValidationContract<Customer>(customer)
                .HasMinLength(x => x.Name, 4);

            foreach (var notification in customer.Notifications)
                Console.WriteLine($"{notification.Property} -> {notification.Message}");

            Assert.IsFalse(customer.IsValid());
            Assert.AreEqual(1, customer.Notifications.Count);
        }
    }
}
