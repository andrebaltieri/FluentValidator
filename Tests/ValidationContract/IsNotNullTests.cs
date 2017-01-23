using Xunit;
using FluentValidator.Validation;

namespace Tests.ValidationContract
{
    public class IsNotNullTests
    {
        private readonly FakeEntity _fake;

        public IsNotNullTests()
        {
            _fake = new FakeEntity();
        }
        
        [Fact]
        public void ShouldNotReturnNotificationWhenIsNotNull()
        {
            _fake.SomeString = "André Luis Alves Baltieri";
            new ValidationContract<FakeEntity>(_fake)
                .IsNotNull(1234, "This object should not be null");

            Assert.True(_fake.Notifications.Count == 0);
        }

        [Fact]
        public void ShouldReturnNotificationWhenIsNull()
        {
            _fake.SomeString = "André Luis Alves Baltieri";
            new ValidationContract<FakeEntity>(_fake)
                .IsNotNull(null, "This object should not be null");

            Assert.True(_fake.Notifications.Count == 1);
        }
    }
}