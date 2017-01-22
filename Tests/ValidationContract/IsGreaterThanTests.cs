using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation;

namespace Tests.ValidationContract
{
    [TestClass]
    public class IsGreaterThanTests
    {
        private readonly FakeEntity _fake;

        public IsGreaterThanTests()
        {
            _fake = new FakeEntity();
        }

        #region Integer
        [TestMethod]
        [TestCategory("IsGreaterThan - Integer")]
        public void ShouldReturnNotificationWhenIntegerIsNotGreaterThan()
        {
            _fake.SomeInteger = 3;
            new ValidationContract<FakeEntity>(_fake)
                .IsGreaterThan(x => x.SomeInteger, 5);

            Assert.AreEqual(1, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsGreaterThan - Integer")]
        public void ShouldNotReturnNotificationWhenIntegerIsGreaterThan()
        {
            _fake.SomeInteger = 7;
            new ValidationContract<FakeEntity>(_fake)
                .IsGreaterThan(x => x.SomeInteger, 5);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }
        #endregion

        #region Decimal
        [TestMethod]
        [TestCategory("IsGreaterThan - Decimal")]
        public void ShouldReturnNotificationWhenDecimalIsNotGreaterThan()
        {
            _fake.SomeDecimal = 3;
            new ValidationContract<FakeEntity>(_fake)
                .IsGreaterThan(x => x.SomeDecimal, 5);

            Assert.AreEqual(1, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsGreaterThan - Decimal")]
        public void ShouldNotReturnNotificationWhenDecimalIsGreaterThan()
        {
            _fake.SomeDecimal = 7;
            new ValidationContract<FakeEntity>(_fake)
                .IsGreaterThan(x => x.SomeDecimal, 5);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }
        #endregion

        #region Double
        [TestMethod]
        [TestCategory("IsGreaterThan - Double")]
        public void ShouldReturnNotificationWhenDoubleIsNotGreaterThan()
        {
            _fake.SomeDouble = 3;
            new ValidationContract<FakeEntity>(_fake)
                .IsGreaterThan(x => x.SomeDouble, 5);

            Assert.AreEqual(1, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsGreaterThan - Double")]
        public void ShouldNotReturnNotificationWhenDoubleIsGreaterThan()
        {
            _fake.SomeDouble = 7;
            new ValidationContract<FakeEntity>(_fake)
                .IsGreaterThan(x => x.SomeDouble, 5);

            Assert.AreEqual(0, _fake.Notifications.Count);
        }
        #endregion

        #region Date
        [TestMethod]
        [TestCategory("IsGreaterThan - Date")]
        public void ShouldReturnNotificationWhenDateIsNotGreaterThan()
        {
            _fake.SomeDate = DateTime.Now;
            new ValidationContract<FakeEntity>(_fake)
                .IsGreaterThan(x => x.SomeDate, DateTime.Now.AddDays(3));

            Assert.AreEqual(1, _fake.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("IsGreaterThan - Date")]
        public void ShouldNotReturnNotificationWhenDateIsGreaterThan()
        {
            _fake.SomeDate = DateTime.Now;
            new ValidationContract<FakeEntity>(_fake)
                .IsGreaterThan(x => x.SomeDate, DateTime.Now.AddDays(-5));

            Assert.AreEqual(0, _fake.Notifications.Count);
        }
        #endregion
    }
}