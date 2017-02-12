using FluentValidator.Tests.Notifiables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidator.Tests
{
    [TestClass]
    public class ValidationContractIsFixedLengthTests
    {
        [TestMethod]
        [TestCategory("ValidationContract.IsFixedLength")]
        public void ShouldNotReturnNotificationsWhenStringPropertyContainsTheFixedSize()
        {
            var customer = new Customer { Name = "1234567890" };

            new ValidationContract<Customer>(customer)
                .IsFixedLength(x => x.Name, 10);

            Assert.IsTrue(customer.IsValid());
            Assert.AreEqual(0, customer.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("ValidationContract.IsFixedLength")]
        public void ShouldReturnNotificationsWhenStringPropertyNotContainsTheFixedSize()
        {
            var customer = new Customer { Name = "12345678" };

            new ValidationContract<Customer>(customer)
                .IsFixedLength(x => x.Name, 10);

            Assert.IsFalse(customer.IsValid());
            Assert.AreEqual(1, customer.Notifications.Count);
        }
    }
}