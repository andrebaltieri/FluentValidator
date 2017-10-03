using FluentValidator.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidator.Tests
{
    public class Person
    {
        public Person(string name, string lastname, int age)
        {
            Name = name;
            Lastname = lastname;
            Age = age;
        }

        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
    }

    [TestClass]
    public class FunctionValidationContracTests
    {
        [TestMethod]
        [TestCategory("FunctionValidation")]
        public void MustIsValid()
        {
            var isValidCnpj = new ValidationContract()
                .Must(ValidateCnpj, "09495792000197", "Valid Cnpj", "ValidateCreditCard");

            var isValidCpf = new ValidationContract()
                .Must(ValidateCpf, "02661341579", "Valid Cpf");

            var isValidPerson = new ValidationContract()
                .Must(IsValidPerson, new Person("Milton", "Camara", 20), "This person can buy tickets");

            Assert.IsTrue(isValidCnpj.IsValid);
            Assert.IsTrue(isValidCpf.IsValid);
            Assert.IsTrue(isValidCpf.IsValid);
        }

        [TestMethod]
        [TestCategory("FunctionValidation")]
        public void MustIsInvalid()
        {
            var isValidCnpj = new ValidationContract()
                .Must(ValidateCnpj, "09495792000199", "Invalid Cnpj", "ValidateCnpj");

            var isValidCpf = new ValidationContract()
                .Must(ValidateCpf, "02661341575", "Invalid Cpf");

            var isValidPerson = new ValidationContract()
                .Must(IsValidPerson, new Person("Milton", "Camara", 15), "This person cannot buy tickets");

            Assert.IsFalse(isValidCnpj.IsValid);
            Assert.IsFalse(isValidCpf.IsValid);
            Assert.IsFalse(isValidCpf.IsValid);
        }

        private bool ValidateCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        private bool ValidateCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        private bool IsValidPerson(Person p)
        {
            if (!string.IsNullOrEmpty(p.Name) && !string.IsNullOrEmpty(p.Lastname) && p.Age >= 18)
            {
                return true;
            }

            return false;
        }
    }
}