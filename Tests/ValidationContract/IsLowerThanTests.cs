using System;
using Xunit;
using FluentValidator.Validation;

namespace Tests.ValidationContract
{
    public class IsLowerThanTests
    {
        private readonly FakeEntity _fake;

        public IsLowerThanTests()
        {
            _fake = new FakeEntity();
        }

        #region Integer
        [Fact]
        public void ShouldReturnNotificationWhenIntegerIsNotLowerThan()
        {
            _fake.SomeInteger = 5;
            new ValidationContract<FakeEntity>(_fake)
                .IsLowerThan(x => x.SomeInteger, 3);

            Assert.True(_fake.Notifications.Count == 1);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenIntegerIsLowerThan()
        {
            _fake.SomeInteger = 5;
            new ValidationContract<FakeEntity>(_fake)
                .IsLowerThan(x => x.SomeInteger, 7);

            Assert.True(_fake.Notifications.Count == 0);
        }
        #endregion

        #region Decimal
        [Fact]
        public void ShouldReturnNotificationWhenDecimalIsNotLowerThan()
        {
            _fake.SomeDecimal = 5;
            new ValidationContract<FakeEntity>(_fake)
                .IsLowerThan(x => x.SomeDecimal, 3);

            Assert.True(_fake.Notifications.Count == 1);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenDecimalIsLowerThan()
        {
            _fake.SomeDecimal = 5;
            new ValidationContract<FakeEntity>(_fake)
                .IsLowerThan(x => x.SomeDecimal, 7);

            Assert.True(_fake.Notifications.Count == 0);
        }
        #endregion

        #region Double
        [Fact]
        public void ShouldReturnNotificationWhenDoubleIsNotLowerThan()
        {
            _fake.SomeDouble = 5;
            new ValidationContract<FakeEntity>(_fake)
                .IsLowerThan(x => x.SomeDouble, 3);

            Assert.True(_fake.Notifications.Count == 1);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenDoubleIsLowerThan()
        {
            _fake.SomeDouble = 5;
            new ValidationContract<FakeEntity>(_fake)
                .IsLowerThan(x => x.SomeDouble, 7);

            Assert.True(_fake.Notifications.Count == 0);
        }
        #endregion

        #region Date
        [Fact]
        public void ShouldReturnNotificationWhenDateIsNotLowerThan()
        {
            _fake.SomeDate = DateTime.Now;
            new ValidationContract<FakeEntity>(_fake)
                .IsLowerThan(x => x.SomeDate, DateTime.Now.AddDays(-3));

            Assert.True(_fake.Notifications.Count == 1);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenDateIsLowerThan()
        {
            _fake.SomeDate = DateTime.Now;
            new ValidationContract<FakeEntity>(_fake)
                .IsLowerThan(x => x.SomeDate, DateTime.Now.AddDays(3));

            Assert.True(_fake.Notifications.Count == 0);
        }
        #endregion
    }
}