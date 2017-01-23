using System;
using Xunit;
using FluentValidator.Validation;

namespace Tests.ValidationContract
{
    public class IsGreaterThanTests
    {
        private readonly FakeEntity _fake;

        public IsGreaterThanTests()
        {
            _fake = new FakeEntity();
        }

        #region Integer
        [Fact]
        public void ShouldReturnNotificationWhenIntegerIsNotGreaterThan()
        {
            _fake.SomeInteger = 3;
            new ValidationContract<FakeEntity>(_fake)
                .IsGreaterThan(x => x.SomeInteger, 5);

            Assert.True(_fake.Notifications.Count == 1);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenIntegerIsGreaterThan()
        {
            _fake.SomeInteger = 7;
            new ValidationContract<FakeEntity>(_fake)
                .IsGreaterThan(x => x.SomeInteger, 5);

            Assert.True(_fake.Notifications.Count == 0);
        }
        #endregion

        #region Decimal
        [Fact]
        public void ShouldReturnNotificationWhenDecimalIsNotGreaterThan()
        {
            _fake.SomeDecimal = 3;
            new ValidationContract<FakeEntity>(_fake)
                .IsGreaterThan(x => x.SomeDecimal, 5);

            Assert.True(_fake.Notifications.Count == 1);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenDecimalIsGreaterThan()
        {
            _fake.SomeDecimal = 7;
            new ValidationContract<FakeEntity>(_fake)
                .IsGreaterThan(x => x.SomeDecimal, 5);

            Assert.True(_fake.Notifications.Count == 0);
        }
        #endregion

        #region Double
        [Fact]
        public void ShouldReturnNotificationWhenDoubleIsNotGreaterThan()
        {
            _fake.SomeDouble = 3;
            new ValidationContract<FakeEntity>(_fake)
                .IsGreaterThan(x => x.SomeDouble, 5);

            Assert.True(_fake.Notifications.Count == 1);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenDoubleIsGreaterThan()
        {
            _fake.SomeDouble = 7;
            new ValidationContract<FakeEntity>(_fake)
                .IsGreaterThan(x => x.SomeDouble, 5);

            Assert.True(_fake.Notifications.Count == 0);
        }
        #endregion

        #region Date
        [Fact]
        public void ShouldReturnNotificationWhenDateIsNotGreaterThan()
        {
            _fake.SomeDate = DateTime.Now;
            new ValidationContract<FakeEntity>(_fake)
                .IsGreaterThan(x => x.SomeDate, DateTime.Now.AddDays(3));

            Assert.True(_fake.Notifications.Count == 1);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenDateIsGreaterThan()
        {
            _fake.SomeDate = DateTime.Now;
            new ValidationContract<FakeEntity>(_fake)
                .IsGreaterThan(x => x.SomeDate, DateTime.Now.AddDays(-5));

            Assert.True(_fake.Notifications.Count == 0);
        }
        #endregion
    }
}