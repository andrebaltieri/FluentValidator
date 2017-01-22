using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation;

namespace Tests.ValidationContract
{
    [TestClass]
    public class IsEmailTests
    {
        private readonly FakeEntity _fake;

        public IsEmailTests()
        {
            _fake = new FakeEntity();
        }

        [TestMethod]
        [TestCategory("IsEmail - String")]
        public void ShouldNotReturnNotificationWhenNullString()
        {
            new ValidationContract<FakeEntity>(_fake)
                .IsEmail(x => x.SomeString);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsEmail - String")]
        public void ShouldNotReturnNotificationWhenEmptyString()
        {
            _fake.SomeString = "";
            new ValidationContract<FakeEntity>(_fake)
                .IsEmail(x => x.SomeString);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsEmail - String")]
        public void ShouldReturnNotificationWhenFilledString()
        {
            _fake.SomeString = "This is not an E-mail";
            new ValidationContract<FakeEntity>(_fake)
                .IsEmail(x => x.SomeString);

            Assert.AreEqual(1, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsEmail - String")]
        public void ShouldNotReturnNotificationWhenStringIsValid()
        {
            _fake.SomeString = "contato@andrebaltieri.net";
            new ValidationContract<FakeEntity>(_fake)
                .IsEmail(x => x.SomeString);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }
    }
}