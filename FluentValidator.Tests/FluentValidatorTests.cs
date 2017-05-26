using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidator.Tests
{
    [TestClass]
    public class FluentValidatorTests
    {
        private Customer _customer = new Customer();

        [TestMethod]
        public void IsRequired()
        {
            new ValidationContract<Customer>(_customer).IsRequired(x => x.Name);
            Assert.AreEqual(false, _customer.IsValid());
        }

        [TestMethod]
        public void HasMinLength()
        {
            _customer.Name = "A";
            new ValidationContract<Customer>(_customer).HasMinLenght(x => x.Name, 10);
            Assert.AreEqual(false, _customer.IsValid());
        }

        [TestMethod]
        public void HasMaxLength()
        {
            _customer.Name = "André Baltieri";
            new ValidationContract<Customer>(_customer).HasMaxLenght(x => x.Name, 1);
            Assert.AreEqual(false, _customer.IsValid());
        }

        [TestMethod]
        public void IsFixedLenght()
        {
            _customer.Name = "André Baltieri";
            new ValidationContract<Customer>(_customer).IsFixedLenght(x => x.Name, 5);
            Assert.AreEqual(false, _customer.IsValid());
        }

        [TestMethod]
        public void IsValidEmail()
        {
            _customer.Email = "miltomcamara@gmail.com";
            new ValidationContract<Customer>(_customer).IsEmail(x => x.Email);
            Assert.AreEqual(true, _customer.IsValid());
        }

        [TestMethod]
        public void IsInvalidEmail()
        {
            _customer.Email = "miltomcamara@";
            new ValidationContract<Customer>(_customer).IsEmail(x => x.Email);
            Assert.AreEqual(false, _customer.IsValid());
        }

        [TestMethod]
        public void IsValidUrl()
        {
            Customer customerUrlWithHttp = new Customer();
            customerUrlWithHttp.Url = "http://www.google.com.br";

            Customer customerUrlWithHttps = new Customer();
            customerUrlWithHttps.Url = "https://www.google.com.br";

            new ValidationContract<Customer>(customerUrlWithHttp).IsUrl(x => x.Url);
            new ValidationContract<Customer>(customerUrlWithHttps).IsUrl(x => x.Url);

            Assert.AreEqual(true, customerUrlWithHttp.IsValid());
            Assert.AreEqual(true, customerUrlWithHttps.IsValid());
        }

        [TestMethod]
        public void IsInvalidUrl()
        {
            _customer.Url = "teste";
            new ValidationContract<Customer>(_customer).IsUrl(x => x.Url);
            Assert.AreEqual(false, _customer.IsValid());
        }

        [TestMethod]
        public void IsGreaterThan()
        {
            _customer = new Customer();
            _customer.Age = 19;
            _customer.Height = 1.66;
            _customer.Birthdate = DateTime.Now.AddYears(-29);

            new ValidationContract<Customer>(_customer).IsGreaterThan(x => x.Age, 18);
            new ValidationContract<Customer>(_customer).IsGreaterThan(x => x.Height, 1.65);
            new ValidationContract<Customer>(_customer).IsGreaterThan(x => x.Birthdate, DateTime.Now.AddYears(-30));
            Assert.AreEqual(true, _customer.IsValid());

            _customer = new Customer();
            _customer.Age = 17;
            _customer.Height = 1.66;
            _customer.Birthdate = DateTime.Now.AddYears(-29);
            new ValidationContract<Customer>(_customer).IsGreaterThan(x => x.Age, 18);
            new ValidationContract<Customer>(_customer).IsGreaterThan(x => x.Height, 1.66);
            new ValidationContract<Customer>(_customer).IsGreaterThan(x => x.Birthdate, DateTime.Now.AddYears(-30));
            Assert.AreEqual(false, _customer.IsValid());
        }

        [TestMethod]
        public void IsGreaterOrEqualsThan()
        {
            _customer = new Customer();
            _customer.Age = 18;
            _customer.Height = 1.66;
            _customer.Birthdate = DateTime.Now.AddYears(-29);
            new ValidationContract<Customer>(_customer).IsGreaterOrEqualsThan(x => x.Age, 18);
            new ValidationContract<Customer>(_customer).IsGreaterOrEqualsThan(x => x.Height, 1.66);
            new ValidationContract<Customer>(_customer).IsGreaterOrEqualsThan(x => x.Birthdate, DateTime.Now.AddYears(-29));
            Assert.AreEqual(true, _customer.IsValid());
            
            _customer = new Customer();
            _customer.Age = 19;
            _customer.Height = 1.67;
            _customer.Birthdate = DateTime.Now.AddYears(-29);
            new ValidationContract<Customer>(_customer).IsGreaterOrEqualsThan(x => x.Age, 18);
            new ValidationContract<Customer>(_customer).IsGreaterOrEqualsThan(x => x.Height, 1.66);
            new ValidationContract<Customer>(_customer).IsGreaterOrEqualsThan(x => x.Birthdate, DateTime.Now.AddYears(-30));
            Assert.AreEqual(true, _customer.IsValid());

            _customer = new Customer();
            _customer.Age = 17;
            _customer.Height = 1.65;
            _customer.Birthdate = DateTime.Now.AddYears(-29);
            new ValidationContract<Customer>(_customer).IsGreaterOrEqualsThan(x => x.Age, 18);
            new ValidationContract<Customer>(_customer).IsGreaterOrEqualsThan(x => x.Height, 1.66);
            new ValidationContract<Customer>(_customer).IsGreaterOrEqualsThan(x => x.Birthdate, DateTime.Now.AddYears(-28));
            Assert.AreEqual(false, _customer.IsValid());
        }

        [TestMethod]
        public void IsLowerThan()
        {
            _customer = new Customer();
            _customer.Age = 19;
            _customer.Height = 1.66;
            _customer.Birthdate = DateTime.Now.AddYears(-29);

            new ValidationContract<Customer>(_customer).IsLowerThan(x => x.Age, 18);
            new ValidationContract<Customer>(_customer).IsLowerThan(x => x.Height, 1.65);
            new ValidationContract<Customer>(_customer).IsLowerThan(x => x.Birthdate, DateTime.Now.AddYears(-30));
            Assert.AreEqual(false, _customer.IsValid());

            _customer = new Customer();
            _customer.Age = 17;
            _customer.Height = 1.65;
            _customer.Birthdate = Convert.ToDateTime("26/11/1985");
            new ValidationContract<Customer>(_customer).IsLowerThan(x => x.Age, 18);
            new ValidationContract<Customer>(_customer).IsLowerThan(x => x.Height, 1.66);
            new ValidationContract<Customer>(_customer).IsLowerThan(x => x.Birthdate, DateTime.Now.AddYears(-30));
            Assert.AreEqual(true, _customer.IsValid());
        }

        [TestMethod]
        public void IsLowerOrEqualsThan()
        {
            _customer = new Customer();
            _customer.Age = 18;
            _customer.Height = 1.66;
            _customer.Birthdate = DateTime.Now.AddYears(-29);
            new ValidationContract<Customer>(_customer).IsLowerOrEqualsThan(x => x.Age, 18);
            new ValidationContract<Customer>(_customer).IsLowerOrEqualsThan(x => x.Height, 1.66);
            new ValidationContract<Customer>(_customer).IsLowerOrEqualsThan(x => x.Birthdate, DateTime.Now.AddYears(-29));
            Assert.AreEqual(true, _customer.IsValid());
            
            _customer = new Customer();
            _customer.Age = 19;
            _customer.Height = 1.67;
            _customer.Birthdate = DateTime.Now.AddYears(-29);
            new ValidationContract<Customer>(_customer).IsLowerOrEqualsThan(x => x.Age, 18);
            new ValidationContract<Customer>(_customer).IsLowerOrEqualsThan(x => x.Height, 1.66);
            new ValidationContract<Customer>(_customer).IsLowerOrEqualsThan(x => x.Birthdate, DateTime.Now.AddYears(-30));
            Assert.AreEqual(false, _customer.IsValid());

            _customer = new Customer();
            _customer.Age = 17;
            _customer.Height = 1.65;
            _customer.Birthdate = DateTime.Now.AddYears(-29);
            new ValidationContract<Customer>(_customer).IsLowerOrEqualsThan(x => x.Age, 18);
            new ValidationContract<Customer>(_customer).IsLowerOrEqualsThan(x => x.Height, 1.66);
            new ValidationContract<Customer>(_customer).IsLowerOrEqualsThan(x => x.Birthdate, DateTime.Now.AddYears(-28));
            Assert.AreEqual(true, _customer.IsValid());
        }  

        public void IsBetween()
        {
            _customer = new Customer();
            _customer.Age = 18;
            _customer.Height = 1.67;
            _customer.Birthdate = DateTime.Now.AddYears(-29);
            new ValidationContract<Customer>(_customer).IsBetween(x => x.Age, 17, 20);
            new ValidationContract<Customer>(_customer).IsBetween(x => x.Height, 1.66, 1.68);
            new ValidationContract<Customer>(_customer).IsBetween(x => x.Birthdate, DateTime.Now.AddYears(-30), DateTime.Now.AddYears(-28));
            Assert.AreEqual(true, _customer.IsValid());
            
            _customer = new Customer();
            _customer.Age = 21;
            _customer.Height = 1.69;
            _customer.Birthdate = Convert.ToDateTime("26/11/1989");
            new ValidationContract<Customer>(_customer).IsBetween(x => x.Age, 19, 20);
            new ValidationContract<Customer>(_customer).IsBetween(x => x.Height, 1.67, 1.68);
            new ValidationContract<Customer>(_customer).IsBetween(x => x.Birthdate, DateTime.Now.AddYears(-29), DateTime.Now.AddYears(-28));
            Assert.AreEqual(false, _customer.IsValid());

            _customer = new Customer();
            _customer.Age = 18;
            _customer.Height = 1.66;
            _customer.Birthdate = Convert.ToDateTime("26/11/1985");
            new ValidationContract<Customer>(_customer).IsBetween(x => x.Age, 19, 20);
            new ValidationContract<Customer>(_customer).IsBetween(x => x.Height, 1.67, 1.68);
            new ValidationContract<Customer>(_customer).IsBetween(x => x.Birthdate, DateTime.Now.AddYears(-30), DateTime.Now.AddYears(-28));
            Assert.AreEqual(false, _customer.IsValid());            
        }

        [TestMethod]
        public void Contains()
        {
            _customer.Name = "Milton";
            Assert.IsTrue(_customer.Name.Contains("Mil"));

            _customer.Name = "Milton";
            Assert.IsFalse(_customer.Name.Contains("Tes"));            
        }        

        [TestMethod]
        public void IsNotNull()
        {
            Assert.IsNotNull(_customer);
        }

        [TestMethod]
        public void IsNull()
        {
            Customer customer = null;
            Assert.IsNull(customer);
        }                         
    }

    public class Customer : Notifiable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public DateTime Birthdate { get; set; }        
    }
}
