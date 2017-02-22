using Xunit;

namespace FluentValidator.Tests
{
    public class FluentValidatorTests
    {
        private readonly Customer _customer = new Customer();

        [Fact]
        public void IsRequired()
        {
            new ValidationContract<Customer>(_customer).IsRequired(x => x.Name);
            Assert.Equal(false, _customer.IsValid());
        }

        [Fact]
        public void HasMinLength()
        {
            _customer.Name = "A";
            new ValidationContract<Customer>(_customer).HasMinLenght(x => x.Name, 10);
            Assert.Equal(false, _customer.IsValid());
        }

        [Fact]
        public void HasMaxLength()
        {
            _customer.Name = "André Baltieri";
            new ValidationContract<Customer>(_customer).HasMaxLenght(x => x.Name, 1);
            Assert.Equal(false, _customer.IsValid());
        }

        [Fact]
        public void IsFixedLenght()
        {
            _customer.Name = "André Baltieri";
            new ValidationContract<Customer>(_customer).IsFixedLenght(x => x.Name, 5);
            Assert.Equal(false, _customer.IsValid());
        }

        [Fact]
        public void IsEmail()
        {
            _customer.Name = "This is not an e-mail";
            new ValidationContract<Customer>(_customer).IsEmail(x => x.Name);
            Assert.Equal(false, _customer.IsValid());
        }

        [Fact]
        public void IsUrl()
        {
            _customer.Name = "This is not an URL";
            new ValidationContract<Customer>(_customer).IsUrl(x => x.Name);
            Assert.Equal(false, _customer.IsValid());
        }
    }

    public class Customer : Notifiable
    {
        public string Name { get; set; }
    }
}