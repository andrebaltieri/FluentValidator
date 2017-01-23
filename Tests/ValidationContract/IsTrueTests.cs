using Xunit;
using FluentValidator.Validation;

namespace Tests.ValidationContract
{
    public class IsTrueTests
    {
        private readonly FakeEntity _fake;

        public IsTrueTests()
        {
            _fake = new FakeEntity();
        }            
    }
}