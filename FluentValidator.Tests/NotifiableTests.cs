using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidator.Tests
{
    [TestClass]
    public class NotifiableTests : Notifiable
    {
        [TestMethod]
        [TestCategory("Notifiable")]
        public void AddNotificationForOneNotifiable()
        {
            var name = new Name();
            var cus = new Customer();

            AddNotifications(name);
            AddNotifications(cus);

            Assert.AreEqual(false, IsValid);
            Assert.AreEqual(2, Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Notifiable")]
        public void AddNotificationForOneNotifiableWithParameters()
        {
            var cus = new Customer(anotherParam: "with message");

            AddNotifications(cus);
            var notification = cus.Notifications.First();

            Assert.AreEqual("Testing with message", notification.Message);
        }

        [TestMethod]
        [TestCategory("Notifiable")]
        public void AddNotificationWithNullParameter()
        {
            var cus = new Customer(anotherParam: null);

            AddNotifications(cus);
            var notification = cus.Notifications.First();

            Assert.AreEqual("Testing ", notification.Message);
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
    }

    public class Customer : Notifiable
    {
        public Customer(string message = "Testing", string anotherParam = null)
        {
            AddNotification("Test", $"{message} {{0}}", anotherParam);
        }

        public Name Name { get; set; }
    }

    public class Name : Notifiable
    {
        public Name()
        {
            AddNotification("Test", "Testing", FirstName, LastName);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
