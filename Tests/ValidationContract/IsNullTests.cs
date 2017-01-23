using Xunit;
using FluentValidator.Validation;

namespace Tests.ValidationContract
{
    public class IsNullTests
    {
        private readonly FakeEntity _fake;

        public IsNullTests()
        {
            _fake = new FakeEntity();
        }
        
        [Fact]
        public void ShouldNotReturnNotificationWhenIsNull()
        {
            _fake.SomeString = "André Luis Alves Baltieri";
            new ValidationContract<FakeEntity>(_fake)
                .IsNull(null, "This object should be null");

            Assert.True(_fake.Notifications.Count == 0);
        }

        [Fact]
        public void ShouldReturnNotificationWhenIsNotNull()
        {
            _fake.SomeString = "André Luis Alves Baltieri";
            new ValidationContract<FakeEntity>(_fake)
                .IsNull(23, "This object should be null");

            Assert.True(_fake.Notifications.Count == 1);
        }
    }
}