using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation;

namespace Tests.ValidationContract
{
    [TestClass]
    public class IsFixedLenghtTests
    {
        private readonly FakeEntity _fake;

        public IsFixedLenghtTests()
        {
            _fake = new FakeEntity();
        }

        [TestMethod]
        [TestCategory("IsFixedLenght - String")]
        public void ShouldNotReturnNotificationWhenNullString()
        {
            new ValidationContract<FakeEntity>(_fake)
                .IsFixedLenght(x => x.SomeString, 2);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsFixedLenght - String")]
        public void ShouldNotReturnNotificationWhenEmptyString()
        {
            _fake.SomeString = "";
            new ValidationContract<FakeEntity>(_fake)
                .IsFixedLenght(x => x.SomeString, 2);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsFixedLenght - String")]
        public void ShouldReturnNotificationWhenFilledString()
        {
            _fake.SomeString = "André Luis Alves Baltieri";
            new ValidationContract<FakeEntity>(_fake)
                .IsFixedLenght(x => x.SomeString, 5);

            Assert.AreEqual(1, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsFixedLenght - String")]
        public void ShouldNotReturnNotificationWhenStringIsValid()
        {
            _fake.SomeString = "André";
            new ValidationContract<FakeEntity>(_fake)
                .IsFixedLenght(x => x.SomeString, 5);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }
    }
}