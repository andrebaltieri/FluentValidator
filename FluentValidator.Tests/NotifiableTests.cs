using FluentValidator.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FluentValidator.Tests
{
    [TestClass]
    public class NotifiableTests : Notifiable
    {
        [TestMethod]
        [TestCategory("Notifiable")]
        public void AddNotificationForOneNotifiable()
        {
            var name =new Name();
            var cus = new Customer();

            AddNotifications(name);
            AddNotifications(cus);

            Assert.AreEqual(false, IsValid);
            Assert.AreEqual(2, Notifications.Count);            
        }

        [TestMethod]
        [TestCategory("Notifiable")]
        public void AddNotificationForMultipleNotifiable()
        {
            var name = new Name();
            var customer = new Customer();

            AddNotifications(name, customer);

            Assert.AreEqual(false, IsValid);
            Assert.AreEqual(2, Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Notifiable")]
        public void NotifiableWithNotifications()
        {
            Invoice invoice = new Invoice(0, DateTime.Today, 100, new Address("Name"));

            Assert.IsFalse(invoice.IsValid);
            Assert.AreEqual(1, invoice.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Notifiable")]
        public void CascatedNotifiable()
        {
            Invoice invoice = new Invoice(0, DateTime.Today, 100, new Address(string.Empty));

            Assert.IsFalse(invoice.IsValid);
            Assert.AreEqual(2, invoice.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Notifiable")]
        public void DontConcatNotifications()
        {
            Invoice invoice = new Invoice(0, DateTime.Today, 100, new Address(string.Empty));

            Assert.IsFalse(invoice.IsValid);
            Assert.IsFalse(invoice.IsValid);

            Assert.AreEqual(2, invoice.Notifications.Count);
        }
    }

    public class Customer : Notifiable
    {
        public Customer()
        {
            AddNotification("Test", "Testing");
        }

        public Name Name { get; set; }
    }

    public class Name : Notifiable
    {
        public Name()
        {
            AddNotification("Test", "Testing");
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Invoice : Notifiable
    {
        public int Code { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Value { get; private set; }
        public Address Address { get; private set; }

        public Invoice(int code, DateTime date, decimal value, Address address)
        {
            Code = code;
            Date = date;
            Value = value;
            Address = address;
        }

        protected override IEnumerable<Notification> Validations()
        {
            return new ValidationContract()
                .Requires()
                .Concat(Address)
                .IsGreaterThan(Code, 0, "Code", "Code is required")
                .IsGreaterThan(Date, DateTime.MinValue, "Date", "Date is required")
                .Notifications;
        }
    }

    public class Address : Notifiable
    {
        public string Value { get; private set; }

        public Address(string value)
        {
            Value = value;
        }

        protected override IEnumerable<Notification> Validations()
        {
            return new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(Value, "Address", "Address is required")
                .Notifications;
        }
    }
}
