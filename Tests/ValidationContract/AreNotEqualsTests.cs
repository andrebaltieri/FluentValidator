using Xunit;
using FluentValidator.Validation;

namespace Tests.ValidationContract
{
    public class AreNotEqualsTests
    {
        private readonly FakeEntity _fake;

        public AreNotEqualsTests()
        {
            _fake = new FakeEntity();
        }            
    }
}