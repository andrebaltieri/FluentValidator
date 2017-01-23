using Xunit;
using FluentValidator.Validation;

namespace Tests.ValidationContract
{
    public class IsFalseTests
    {
        private readonly FakeEntity _fake;

        public IsFalseTests()
        {
            _fake = new FakeEntity();
        }            
    }
}