using Xunit;
using FluentValidator.Validation;

namespace Tests.ValidationContract
{
    public class AreEqualsTests
    {
        private readonly FakeEntity _fake;

        public AreEqualsTests()
        {
            _fake = new FakeEntity();
        }            
    }
}