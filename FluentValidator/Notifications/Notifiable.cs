using System;
using System.Collections.Generic;

namespace FluentValidator
{
    public abstract class Notifiable
    {
        private readonly List<Notification> _notifications;

        protected Notifiable() { _notifications = new List<Notification>(); }

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public void AddNotification(string property, string message)
        {
            _notifications.Add(new Notification(property, message));
        }

        public void AddNotification(string property, string message, params object[] parameters)
        {
            parameters = parameters ?? new object[] { };

            var formattedMessage = string.Format(message, parameters);
            AddNotification(property, formattedMessage);
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(Notifiable item)
        {
            AddNotifications(item.Notifications);
        }

        public void AddNotifications(params Notifiable[] items)
        {
            foreach(var item in items)
                AddNotifications(item);
        }

        public bool IsValid => _notifications.Count == 0;
    }
}