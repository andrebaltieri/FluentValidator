using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation;

namespace Tests.ValidationContract
{
    [TestClass]
    public class IsRequiredTests
    {
        private readonly FakeEntity _fake;

        public IsRequiredTests()
        {
            _fake = new FakeEntity();
        }

        [TestMethod]
        [TestCategory("IsRequired - String")]
        public void ShouldReturnNotificationWhenNullString()
        {
            new ValidationContract<FakeEntity>(_fake)
                .IsRequired(x => x.SomeString);

            Assert.AreEqual(1, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsRequired - String")]
        public void ShouldReturnNotificationWhenEmptyString()
        {
            _fake.SomeString = "";
            new ValidationContract<FakeEntity>(_fake)
                .IsRequired(x => x.SomeString);

            Assert.AreEqual(1, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsRequired - String")]
        public void ShouldNotReturnNotificationWhenFilledString()
        {
            _fake.SomeString = "Some Name Here";
            new ValidationContract<FakeEntity>(_fake)
                .IsRequired(x => x.SomeString);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }
    }
}