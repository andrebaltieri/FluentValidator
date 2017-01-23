using System;
using Xunit;
using FluentValidator.Validation;

namespace Tests.ValidationContract
{
    public class HasMaxLenghtTests
    {
        private readonly FakeEntity _fake;

        public HasMaxLenghtTests()
        {
            _fake = new FakeEntity();
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenNullString()
        {
            new ValidationContract<FakeEntity>(_fake)
                .HasMinLenght(x => x.SomeString, 2);

            Assert.True(_fake.Notifications.Count == 0);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenEmptyString()
        {
            _fake.SomeString = "";
            new ValidationContract<FakeEntity>(_fake)
                .HasMinLenght(x => x.SomeString, 2);

            Assert.True(_fake.Notifications.Count == 0);
        }

        [Fact]
        public void ShouldReturnNotificationWhenFilledString()
        {
            _fake.SomeString = "André Luis Alves Baltieri";
            new ValidationContract<FakeEntity>(_fake)
                .HasMaxLenght(x => x.SomeString, 5);

            Assert.True(_fake.Notifications.Count == 1);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenStringIsValid()
        {
            _fake.SomeString = "André Baltieri";
            new ValidationContract<FakeEntity>(_fake)
                .HasMaxLenght(x => x.SomeString, 40);

            Assert.True(_fake.Notifications.Count == 0);
        }
    }
}