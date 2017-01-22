using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation;

namespace Tests.ValidationContract
{
    [TestClass]
    public class IsUrlTests
    {
        private readonly FakeEntity _fake;

        public IsUrlTests()
        {
            _fake = new FakeEntity();
        }

        [TestMethod]
        [TestCategory("IsUrl - String")]
        public void ShouldNotReturnNotificationWhenNullString()
        {
            new ValidationContract<FakeEntity>(_fake)
                .IsUrl(x => x.SomeString);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsUrl - String")]
        public void ShouldNotReturnNotificationWhenEmptyString()
        {
            _fake.SomeString = "";
            new ValidationContract<FakeEntity>(_fake)
                .IsUrl(x => x.SomeString);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsUrl - String")]
        public void ShouldReturnNotificationWhenFilledString()
        {
            _fake.SomeString = "This is not an URL";
            new ValidationContract<FakeEntity>(_fake)
                .IsUrl(x => x.SomeString);

            Assert.AreEqual(1, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsUrl - String")]
        public void ShouldNotReturnNotificationWhenStringIsValid()
        {
            _fake.SomeString = "http://andrebaltieri.net/";
            new ValidationContract<FakeEntity>(_fake)
                .IsUrl(x => x.SomeString);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }
    }
}