using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation;

namespace Tests.ValidationContract
{
    [TestClass]
    public class IsLowerThanTests
    {
        private readonly FakeEntity _fake;

        public IsLowerThanTests()
        {
            _fake = new FakeEntity();
        }

        #region Integer
        [TestMethod]
        [TestCategory("IsLowerThan - Integer")]
        public void ShouldReturnNotificationWhenIntegerIsNotLowerThan()
        {
            _fake.SomeInteger = 5;
            new ValidationContract<FakeEntity>(_fake)
                .IsLowerThan(x => x.SomeInteger, 3);

            Assert.AreEqual(1, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsLowerThan - Integer")]
        public void ShouldNotReturnNotificationWhenIntegerIsLowerThan()
        {
            _fake.SomeInteger = 5;
            new ValidationContract<FakeEntity>(_fake)
                .IsLowerThan(x => x.SomeInteger, 7);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }
        #endregion

        #region Decimal
        [TestMethod]
        [TestCategory("IsLowerThan - Decimal")]
        public void ShouldReturnNotificationWhenDecimalIsNotLowerThan()
        {
            _fake.SomeDecimal = 5;
            new ValidationContract<FakeEntity>(_fake)
                .IsLowerThan(x => x.SomeDecimal, 3);

            Assert.AreEqual(1, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsLowerThan - Decimal")]
        public void ShouldNotReturnNotificationWhenDecimalIsLowerThan()
        {
            _fake.SomeDecimal = 5;
            new ValidationContract<FakeEntity>(_fake)
                .IsLowerThan(x => x.SomeDecimal, 7);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }
        #endregion

        #region Double
        [TestMethod]
        [TestCategory("IsLowerThan - Double")]
        public void ShouldReturnNotificationWhenDoubleIsNotLowerThan()
        {
            _fake.SomeDouble = 5;
            new ValidationContract<FakeEntity>(_fake)
                .IsLowerThan(x => x.SomeDouble, 3);

            Assert.AreEqual(1, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsLowerThan - Double")]
        public void ShouldNotReturnNotificationWhenDoubleIsLowerThan()
        {
            _fake.SomeDouble = 5;
            new ValidationContract<FakeEntity>(_fake)
                .IsLowerThan(x => x.SomeDouble, 7);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }
        #endregion

        #region Date
        [TestMethod]
        [TestCategory("IsLowerThan - Date")]
        public void ShouldReturnNotificationWhenDateIsNotLowerThan()
        {
            _fake.SomeDate = DateTime.Now;
            new ValidationContract<FakeEntity>(_fake)
                .IsLowerThan(x => x.SomeDate, DateTime.Now.AddDays(-3));

            Assert.AreEqual(1, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsLowerThan - Date")]
        public void ShouldNotReturnNotificationWhenDateIsLowerThan()
        {
            _fake.SomeDate = DateTime.Now;
            new ValidationContract<FakeEntity>(_fake)
                .IsLowerThan(x => x.SomeDate, DateTime.Now.AddDays(3));

            Assert.AreEqual(0, _fake.Notifications.Count);
        }
        #endregion
    }
}