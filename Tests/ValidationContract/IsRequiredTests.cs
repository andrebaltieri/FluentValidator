using Xunit;
using Validation;

namespace Tests.ValidationContract
{
    public class IsRequiredTests
    {
        private readonly FakeEntity _fake;

        public IsRequiredTests()
        {
            _fake = new FakeEntity();
        }

        [Fact]
        public void ShouldReturnNotificationWhenNullString()
        {
            new ValidationContract<FakeEntity>(_fake)
                .IsRequired(x => x.SomeString);

            Assert.True(_fake.Notifications.Count == 1);
        }

        [Fact]
        public void ShouldReturnNotificationWhenEmptyString()
        {
            _fake.SomeString = "";
            new ValidationContract<FakeEntity>(_fake)
                .IsRequired(x => x.SomeString);

            Assert.True(_fake.Notifications.Count == 1);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenFilledString()
        {
            _fake.SomeString = "Some Name Here";
            new ValidationContract<FakeEntity>(_fake)
                .IsRequired(x => x.SomeString);

            Assert.True(_fake.Notifications.Count == 0);
        }
    }
}