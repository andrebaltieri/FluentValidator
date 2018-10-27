using FluentValidator.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidator.Tests
{
    [TestClass]
    public class LongValidationContractTests
    {
        [TestMethod]
        [TestCategory("IntValidation")]
        public void IsBetweenInt()
        {
            long value = 11;
            long from = 1;
            long to = 10;

            var wrong = new ValidationContract()
                .Requires()
                .IsBetween(value, from, to, "long", "The value 11 must be between 1 and 10");

            Assert.AreEqual(false, wrong.Valid);
            Assert.AreEqual(1, wrong.Notifications.Count);

            value = 5;
            from = 1;
            to = 10;

            var right = new ValidationContract()
                .Requires()
                .IsBetween(5, 1, 10, "long", "The value 5 is between 1 and 10");

            Assert.AreEqual(true, right.Valid);
        }
    }
}
