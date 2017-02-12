using System;

namespace FluentValidator.Tests.Notifiables
{
    public class Customer : Notifiable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Email Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? ActivationDate { get; set; }
        public string UserName { get; set; }
    }
}