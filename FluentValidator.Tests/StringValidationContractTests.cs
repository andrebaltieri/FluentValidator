using System.Linq;
using FluentValidator.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidator.Tests
{
    [TestClass]
    public class StringValidationContractTests
    {
        [TestMethod]
        [TestCategory("StringValidation")]
        public void IsNotNullOrEmpty()
        {
            var wrong = new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(null, "string", "String is Null")
                .IsNotNullOrEmpty("", "string", "String is Empty");

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(2, wrong.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty("Some valid string", "string", "String is Null");
            Assert.AreEqual(true, right.IsValid);
        }

        [TestMethod]
        [TestCategory("StringValidation")]
        public void IsNullOrEmpty()
        {
            var right = new ValidationContract()
                .Requires()
                .IsNullOrEmpty(null, "string", "String is Null")
                .IsNullOrEmpty("", "string", "String is Empty");

            Assert.AreEqual(true, right.IsValid);
            Assert.AreEqual(0, right.Notifications.Count);

            var wrong = new ValidationContract()
                .Requires()
                .IsNullOrEmpty("Some valid string", "string", "String is Null");
            Assert.AreEqual(false, wrong.IsValid);
        }



        [TestMethod]
        [TestCategory("StringValidation")]
        public void MinLen()
        {
            var wrong = new ValidationContract()
                .Requires()
                .HasMinLen("null", 5, "string", "String len is less than permited");

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(1, wrong.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .HasMinLen("Some Valid String", 5, "string", "String len is less than permited");

            Assert.AreEqual(true, right.IsValid);
        }

        [TestMethod]
        [TestCategory("StringValidation")]
        public void MinLenWithParameters()
        {
            var wrong = new ValidationContract()
                .Requires()
                .HasMinLen("null", 5,"string", "String must have at least {1} characters.");

            var notification = wrong.Notifications.First();

            Assert.AreEqual("String must have at least 5 characters.", notification.Message);
        }

        [TestMethod]
        [TestCategory("StringValidation")]
        public void MaxLen()
        {
            var x = new ValidationContract()
                .Requires()
                .HasMaxLen("null", 3, "string", "String len is more than permited");

            Assert.AreEqual(false, x.IsValid);
            Assert.AreEqual(1, x.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .HasMaxLen("Some", 5, "string", "String len is less than permited");

            Assert.AreEqual(true, right.IsValid);
        }

        [TestMethod]
        [TestCategory("StringValidation")]
        public void MaxLenWithParameters()
        {
            var x = new ValidationContract()
                .Requires()
                .HasMaxLen("null", 3, "string", "String len is more than {1}");

            Assert.AreEqual("String len is more than 3", x.Notifications.First().Message);
        }

        [TestMethod]
        [TestCategory("StringValidation")]
        public void Len()
        {
            var x = new ValidationContract()
                .Requires()
                .HasLen("null", 3, "string", "String len is more than permited");

            Assert.AreEqual(false, x.IsValid);
            Assert.AreEqual(1, x.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .HasLen("Some1", 5, "string", "String len is less than permited");

            Assert.AreEqual(true, right.IsValid);
        }

        [TestMethod]
        [TestCategory("StringValidation")]
        public void LenWithParameters()
        {
            var x = new ValidationContract()
                .Requires()
                .HasLen("null", 3, "string", "{0} len is more than {1}")
                .Notifications
                .First();

            Assert.AreEqual("null len is more than 3", x.Message);
        }

        [TestMethod]
        [TestCategory("StringValidation")]
        public void Contains()
        {
            var x = new ValidationContract()
                .Requires()
                .Contains("some text here", "banana", "string", "String does not contains banana");

            Assert.AreEqual(false, x.IsValid);
            Assert.AreEqual(1, x.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .Contains("some banana here", "banana", "string", "String does not contains banana");

            Assert.AreEqual(true, right.IsValid);
        }

        [TestMethod]
        [TestCategory("StringValidation")]
        public void ContainsWithParameters()
        {
            var x = new ValidationContract()
                .Requires()
                .Contains("some text here", "banana", "string", "{0} does not contains {1}");

            Assert.AreEqual("some text here does not contains banana", x.Notifications.First().Message);
        }

        [TestMethod]
        [TestCategory("StringValidation")]
        public void Email()
        {
            var wrong = new ValidationContract()
                .Requires()
                .IsEmail("wrongemail", "string", "Invalid E-mail");

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(1, wrong.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .IsEmail("andrebaltieri@gmail.com", "string", "Invalid E-mail");

            Assert.AreEqual(true, right.IsValid);
        }

        [TestMethod]
        public void EmailWithParameters()
        {
            var wrong = new ValidationContract()
                .Requires()
                .IsEmail("wrongemail", "string", "Email should match the pattern {0}");

            var message = wrong.Notifications.First().Message;
            var pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            Assert.AreEqual($"Email should match the pattern {pattern}", message);
        }

        [TestMethod]
        [TestCategory("StringValidation")]
        public void Url()
        {
            var wrong = new ValidationContract()
                .Requires()
                .IsUrl("wrongurl", "string", "Invalid URL");

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(1, wrong.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .IsUrl("https://gmail.com", "string", "Invalid URL")
                .IsUrl("http://gmail.com", "string", "Invalid URL")
                .IsUrl("http://balta.io/", "string", "Invalid URL");

            Assert.AreEqual(true, right.IsValid);
        }
        

        [TestMethod]
        [TestCategory("StringValidation")]
        public void Match()
        {
            var wrong = new ValidationContract()
                .Requires()
                .Matchs("wrongurl", @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$", "string", "Invalid URL");

            Assert.AreEqual(false, wrong.IsValid);
            Assert.AreEqual(1, wrong.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .Matchs("http://gmail.com", @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$", "string", "Invalid URL");

            Assert.AreEqual(true, right.IsValid);
        }
    }
}
