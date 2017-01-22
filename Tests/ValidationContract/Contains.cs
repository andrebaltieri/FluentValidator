using Xunit;
using Validation;

namespace Tests.ValidationContract
{
    public class ContainsTests
    {
        private readonly FakeEntity _fake;

        public ContainsTests()
        {
            _fake = new FakeEntity();
        }

        [Fact]
        public void ShouldNotReturnNotificationWhenContainsText()
        {
            _fake.SomeString = "André Luis Alves Baltieri";
            new ValidationContract<FakeEntity>(_fake)
                .Contains(x => x.SomeString, "Luis");

            Assert.True(_fake.Notifications.Count == 0);
        }

        [Fact]
        public void ShouldReturnNotificationWhenNotContainsText()
        {
            _fake.SomeString = "André Luis Alves Baltieri";
            new ValidationContract<FakeEntity>(_fake)
                .Contains(x => x.SomeString, "NOTINTEXT");

            Assert.True(_fake.Notifications.Count == 1);
        }
    }
}