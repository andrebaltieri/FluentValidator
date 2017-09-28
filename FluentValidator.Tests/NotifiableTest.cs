using FluentValidator.Tests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentValidator.Tests
{
    [TestClass]
    public class NotifiableTest
    {
        [TestMethod]
        [TestCategory("Notifiable")]
        public void NotifiableWithNotifications()
        {
            Invoice invoice = new Invoice(0, DateTime.Today, 100, new Customer("Name"));

            Assert.IsFalse(invoice.IsValid);
            Assert.AreEqual(1, invoice.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Notifiable")]
        public void CascatedNotifiable()
        {
            Invoice invoice = new Invoice(0, DateTime.Today, 100, new Customer(string.Empty));

            Assert.IsFalse(invoice.IsValid);
            Assert.AreEqual(2, invoice.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Notifiable")]
        public void DontConcatNotifications()
        {
            Invoice invoice = new Invoice(0, DateTime.Today, 100, new Customer(string.Empty));

            Assert.IsFalse(invoice.IsValid);
            Assert.IsFalse(invoice.IsValid);

            Assert.AreEqual(2, invoice.Notifications.Count);
        }
    }
}
