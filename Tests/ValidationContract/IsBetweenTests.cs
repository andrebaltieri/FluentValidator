using System;
using Xunit;
using FluentValidator.Validation;

namespace Tests.ValidationContract
{
    public class IsBetweenTests
    {
        private readonly FakeEntity _fake;

        public IsBetweenTests()
        {
            _fake = new FakeEntity();
        }

        #region Integer
        [Fact]
        public void ShouldReturnNotificationWhenIntegerIsNotBetween()
        {
            _fake.SomeInteger = 3;
            new ValidationContract<FakeEntity>(_fake)
                .IsBetween(x => x.SomeInteger, 5, 7);

            Assert.True(_fake.Notifications.Count == 1);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenIntegerIsBetween()
        {
            _fake.SomeInteger = 3;
            new ValidationContract<FakeEntity>(_fake)
                .IsBetween(x => x.SomeInteger, 2, 5);

            Assert.True(_fake.Notifications.Count == 0);
        }
        #endregion

        #region Decimal
        [Fact]
        public void ShouldReturnNotificationWhenDecimalIsNotBetween()
        {
            _fake.SomeDecimal = 3;
            new ValidationContract<FakeEntity>(_fake)
                .IsBetween(x => x.SomeDecimal, 5, 7);

            Assert.True(_fake.Notifications.Count == 1);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenDecimalIsBetween()
        {
            _fake.SomeDecimal = 3;
            new ValidationContract<FakeEntity>(_fake)
                .IsBetween(x => x.SomeDecimal, 2, 5);

            Assert.True(_fake.Notifications.Count == 0);
        }
        #endregion

        #region Double
        [Fact]
        public void ShouldReturnNotificationWhenDoubleIsNotBetween()
        {
            _fake.SomeDouble = 3;
            new ValidationContract<FakeEntity>(_fake)
                .IsBetween(x => x.SomeDouble, 5, 7);

            Assert.True(_fake.Notifications.Count == 1);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenDoubleIsBetween()
        {
            _fake.SomeDouble = 3;
            new ValidationContract<FakeEntity>(_fake)
                .IsBetween(x => x.SomeDouble, 2, 5);

            Assert.True(_fake.Notifications.Count == 0);
        }
        #endregion

        #region Date
        [Fact]
        public void ShouldReturnNotificationWhenDateIsNotBetween()
        {
            _fake.SomeDate = DateTime.Now;
            new ValidationContract<FakeEntity>(_fake)
                .IsBetween(x => x.SomeDate, DateTime.Now.AddDays(5), DateTime.Now.AddDays(7));

            Assert.True(_fake.Notifications.Count == 1);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenDateIsBetween()
        {
            _fake.SomeDate = DateTime.Now;            
            new ValidationContract<FakeEntity>(_fake)
                .IsBetween(x => x.SomeDate, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(3));

            Assert.True(_fake.Notifications.Count == 0);
        }
        #endregion
    }
}