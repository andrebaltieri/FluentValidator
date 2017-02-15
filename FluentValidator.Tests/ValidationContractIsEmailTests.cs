using FluentValidator.Tests.Notifiables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidator.Tests
{
    [TestClass]
    public class ValidationContractIsEmailTests
    {
        [TestMethod]
        [TestCategory("ValidationContract.IsEmail")]
        public void ShouldNotReturnNotificationsWhenEmailAddressIsValid()
        {
            var email = new Email("a@a.b");

            Assert.IsTrue(email.IsValid());
            Assert.AreEqual(0, email.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("ValidationContract.IsEmail")]
        public void ShouldReturnNotificationsWhenEmailAddressIsInvalid()
        {
            var email = new Email("a.a.b");

            Assert.IsFalse(email.IsValid());
            Assert.AreEqual(1, email.Notifications.Count);
        }
    }
}