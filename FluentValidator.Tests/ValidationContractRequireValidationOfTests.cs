using FluentValidator.Tests.Notifiables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidator.Tests
{
    [TestClass]
    public class ValidationContractRequireValidationOfTests
    {
        [TestMethod]
        [TestCategory("ValidationContract.RequireValidationOf")]
        public void ShouldNotReturnNotifiablePropertyNotificationsWhenIsValid()
        {
            var customer = new Customer { Email = new Email("a@a.com") };

            new ValidationContract<Customer>(customer)
                .RequireValidationOf(x => x.Email);

            Assert.IsTrue(customer.IsValid());
            Assert.AreEqual(0, customer.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("ValidationContract.RequireValidationOf")]
        public void ShouldReturnNotifiablePropertyNotificationsWhenIsInvalid()
        {
            var customer = new Customer { Email = new Email("a.a.com") };

            new ValidationContract<Customer>(customer)
                .RequireValidationOf(x => x.Email);

            Assert.IsFalse(customer.IsValid());
            Assert.AreEqual(1, customer.Notifications.Count);
        }
    }
}