using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation;

namespace Tests.ValidationContract
{
    [TestClass]
    public class IsBetweenTests
    {
        private readonly FakeEntity _fake;

        public IsBetweenTests()
        {
            _fake = new FakeEntity();
        }

        #region Integer
        [TestMethod]
        [TestCategory("Between - Integer")]
        public void ShouldReturnNotificationWhenIntegerIsNotBetween()
        {
            _fake.SomeInteger = 3;
            new ValidationContract<FakeEntity>(_fake)
                .IsBetween(x => x.SomeInteger, 5, 7);

            Assert.AreEqual(1, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Between - Integer")]
        public void ShouldNotReturnNotificationWhenIntegerIsBetween()
        {
            _fake.SomeInteger = 3;
            new ValidationContract<FakeEntity>(_fake)
                .IsBetween(x => x.SomeInteger, 2, 5);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }
        #endregion
    }
}