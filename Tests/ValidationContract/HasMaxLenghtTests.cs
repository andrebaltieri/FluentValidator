using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation;

namespace Tests.ValidationContract
{
    [TestClass]
    public class HasMaxLenghtTests
    {
        private readonly FakeEntity _fake;

        public HasMaxLenghtTests()
        {
            _fake = new FakeEntity();
        }

        [TestMethod]
        [TestCategory("HasMaxLenght - String")]
        public void ShouldNotReturnNotificationWhenNullString()
        {
            new ValidationContract<FakeEntity>(_fake)
                .HasMinLenght(x => x.SomeString, 2);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("HasMaxLenght - String")]
        public void ShouldNotReturnNotificationWhenEmptyString()
        {
            _fake.SomeString = "";
            new ValidationContract<FakeEntity>(_fake)
                .HasMinLenght(x => x.SomeString, 2);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("HasMaxLenght - String")]
        public void ShouldReturnNotificationWhenFilledString()
        {
            _fake.SomeString = "André Luis Alves Baltieri";
            new ValidationContract<FakeEntity>(_fake)
                .HasMaxLenght(x => x.SomeString, 5);

            Assert.AreEqual(1, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("HasMaxLenght - String")]
        public void ShouldNotReturnNotificationWhenStringIsValid()
        {
            _fake.SomeString = "André Baltieri";
            new ValidationContract<FakeEntity>(_fake)
                .HasMaxLenght(x => x.SomeString, 40);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }
    }
}