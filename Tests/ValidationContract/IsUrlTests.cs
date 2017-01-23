using Xunit;
using FluentValidator.Validation;

namespace Tests.ValidationContract
{
    public class IsUrlTests
    {
        private readonly FakeEntity _fake;

        public IsUrlTests()
        {
            _fake = new FakeEntity();
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenNullString()
        {
            new ValidationContract<FakeEntity>(_fake)
                .IsUrl(x => x.SomeString);

            Assert.True(_fake.Notifications.Count == 0);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenEmptyString()
        {
            _fake.SomeString = "";
            new ValidationContract<FakeEntity>(_fake)
                .IsUrl(x => x.SomeString);

            Assert.True(_fake.Notifications.Count == 0);
        }

        [Fact]
        public void ShouldReturnNotificationWhenFilledString()
        {
            _fake.SomeString = "This is not an URL";
            new ValidationContract<FakeEntity>(_fake)
                .IsUrl(x => x.SomeString);

            Assert.True(_fake.Notifications.Count == 1);
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenStringIsValid()
        {
            _fake.SomeString = "http://andrebaltieri.net/";
            new ValidationContract<FakeEntity>(_fake)
                .IsUrl(x => x.SomeString);

            Assert.True(_fake.Notifications.Count == 0);
        }
    }
}