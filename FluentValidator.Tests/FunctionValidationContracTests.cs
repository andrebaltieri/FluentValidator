using FluentValidator.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentValidator.Tests
{
    public class Person
    {
        public Person(string name, string lastname)
        {
            Name = name;
            Lastname = lastname;
        }

        public string Name { get; set; }
        public string Lastname { get; set; }
    }

    [TestClass]
    public class FunctionValidationContracTests
    {
        [TestMethod]
        [TestCategory("FunctionValidation")]
        public void Should()
        {
            var isValidCreditCard = new ValidationContract()
                .Should(ValidateCreditCard, "4532 4555 8888 9999", "Cartão de crédito inválido");

            var isValidCpf = new ValidationContract()
                .Should(ValidateCpf, "02661341579", "CPF inválido");

            var isValidPerson = new ValidationContract()
                .Should(IsValidPerson, new Person("Milton", "Camara"), "Cartão de crédito inválido");

        }

        private bool ValidateCreditCard(string value)
        {
            return false;
        }

        private bool ValidateCpf(string cpf)
        {
            return true;
        }

        private bool IsValidPerson(Person p)
        {
            if (!string.IsNullOrEmpty(p.Name) && !string.IsNullOrEmpty(p.Lastname))
            {
                return true;
            }

            return false;
        }
    }
}
