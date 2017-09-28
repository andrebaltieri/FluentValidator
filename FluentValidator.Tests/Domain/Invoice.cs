using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentValidator.Tests.Domain
{
    public class Invoice: Aggregate
    {
        public int Code { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Value { get; private set; }
        public Customer Customer { get; private set; }

        public Invoice(int code, DateTime date, decimal value, Customer customer)
        {
            Code = code;
            Date = date;
            Value = value;
            Customer = customer;
        }

        protected override IEnumerable<Notification> Validations()
        {
            return new ValidationContract()
                .Requires()
                .Concat(Customer)
                .IsGreaterThan(Code, 0, "Code", "Code is required")
                .IsGreaterThan(Date, DateTime.MinValue, "Date", "Date is required")
                .Notifications;
        }
    }

    public class Customer: Entity
    {
        public string Name { get; private set; }

        public Customer(string name)
        {
            Name = name;
        }

        protected override IEnumerable<Notification> Validations()
        {
            return new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "Name is required")
                .Notifications;
        }
    }
}
