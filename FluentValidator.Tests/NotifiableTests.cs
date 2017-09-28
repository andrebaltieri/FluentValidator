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
}
