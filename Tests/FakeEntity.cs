using System;
using FluentValidator.Validation;

namespace Tests
{
    public class FakeEntity : Notifiable
    {
        public string SomeString { get; set; }
        public int SomeInteger { get; set; }
        public decimal SomeDecimal { get; set; }
        public double SomeDouble { get; set; }
        public DateTime SomeDate { get; set; }

    }
}