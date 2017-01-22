using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation;

namespace Tests.ValidationContract
{
    [TestClass]
    public class HasMinLenghtTests
    {
        private readonly FakeEntity _fake;

        public HasMinLenghtTests()
        {
            _fake = new FakeEntity();
        }

        [TestMethod]
        [TestCategory("HasMinLenght - String")]
        public void ShouldNotReturnNotificationWhenNullString()
        {
            new ValidationContract<FakeEntity>(_fake)
                .HasMinLenght(x => x.SomeString, 2);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("HasMinLenght - String")]
        public void ShouldNotReturnNotificationWhenEmptyString()
        {
            _fake.SomeString = "";
            new ValidationContract<FakeEntity>(_fake)
                .HasMinLenght(x => x.SomeString, 2);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("HasMinLenght - String")]
        public void ShouldReturnNotificationWhenFilledString()
        {
            _fake.SomeString = "S";
            new ValidationContract<FakeEntity>(_fake)
                .HasMinLenght(x => x.SomeString, 5);

            Assert.AreEqual(1, _fake.Notifications.Count);
        }


        [TestMethod]
        [TestCategory("HasMinLenght - String")]
        public void ShouldNotReturnNotificationWhenStringIsValid()
        {
            _fake.SomeString = "André Baltieri";
            new ValidationContract<FakeEntity>(_fake)
                .HasMinLenght(x => x.SomeString, 5);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }
    }
}