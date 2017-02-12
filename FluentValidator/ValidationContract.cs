using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace FluentValidator
{
    public class ValidationContract<T> where T : Notifiable
    {
        private readonly T _validatable;

        public ValidationContract(T validatable)
        {
            _validatable = validatable;
        }

        private PropertyResolver<T, V> GetPropertyResolver<V>(Expression<Func<T, V>> selector)
            => new PropertyResolver<T, V>(_validatable, selector);

        /// <summary>
        /// Given a Notifiable, add notifications
        /// </summary>
        /// <param name="selector">Property</param>
        /// <returns></returns>
        public ValidationContract<T> RequireValidationOf(Expression<Func<T, Notifiable>> selector)
        {
            // por este caminho as notificações são processadas duas vezes
            //var notifications = selector.Compile().Invoke(_validatable).Notifications;
            //_validatable.AddNotifications(notifications);
            var name = ((MemberExpression)selector.Body).Member.Name;
            var notifiable = (Notifiable)_validatable.GetType().GetProperty(name).GetValue(_validatable);
            _validatable.AddNotifications(notifiable.Notifications);

            return this;
        }

        /// <summary>
        /// Given a string, add a notification if it's null or empty
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsRequired(Expression<Func<T, string>> selector, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (string.IsNullOrEmpty(prop.Value))
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} is required." : message);

            return this;
        }

        /// <summary>
        /// Given a property, add a notification if it's null
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsRequired<M>(Expression<Func<T, M>> selector, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value == null)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} is required." : message);

            return this;
        }

        /// <summary>
        /// Given a string, add a notification if it's length is less than min parameter
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> HasMinLength(Expression<Func<T, string>> selector, int min, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (!string.IsNullOrEmpty(prop.Value) && prop.Value.Length < min)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must have at least {min} characters." : message);

            return this;
        }

        /// <summary>
        /// Given a string, add a notification if it's length is greater than max parameter
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="max">Maximum Length</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> HasMaxLength(Expression<Func<T, string>> selector, int max, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (!string.IsNullOrEmpty(prop.Value) && prop.Value.Length > max)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must have {max} characters." : message);

            return this;
        }

        /// <summary>
        /// Given a string, add a notification if it's length is different from length parameter
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="length">Especific Length</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsFixedLength(Expression<Func<T, string>> selector, int length, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (!string.IsNullOrEmpty(prop.Value) && prop.Value.Length != length)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must have exactly {length} characters." : message);

            return this;
        }

        /// <summary>
        /// Given a string, add a notification if it's not a valid E-mail address
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsEmail(Expression<Func<T, string>> selector, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (!string.IsNullOrEmpty(prop.Value) && !Regex.IsMatch(prop.Value, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be a valid E-mail address." : message);

            return this;
        }

        /// <summary>
        /// Given a string, add a notification if it's not a valid URL
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsUrl(Expression<Func<T, string>> selector, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (!string.IsNullOrEmpty(prop.Value) && !Regex.IsMatch(prop.Value, @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$"))
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be a valid URL." : message);

            return this;
        }

        /// <summary>
        /// Given an integer, add a notification if it's not greater than some other value
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsGreaterThan(Expression<Func<T, int>> selector, int number, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value < number)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be greater than {number}." : message);

            return this;
        }

        /// <summary>
        /// Given an decimal, add a notification if it's not greater than some other value
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsGreaterThan(Expression<Func<T, decimal>> selector, decimal number, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value < number)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be greater than {number}." : message);

            return this;
        }

        /// <summary>
        /// Given an double, add a notification if it's not greater than some other value
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsGreaterThan(Expression<Func<T, double>> selector, double number, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value < number)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be greater than {number}." : message);

            return this;
        }

        /// <summary>
        /// Given a nullable DateTime, add a notification if it's not greater than some other date
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="date">Date to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsGreaterThan(Expression<Func<T, DateTime>> selector, DateTime date, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value < date)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be greater than {date.ToString("MM/dd/yyyy")}." : message);

            return this;
        }

        /// <summary>
        /// Given a nullable DateTime, add a notification if it's null or not greater than some other date
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="date">Date to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsGreaterThan(Expression<Func<T, DateTime?>> selector, DateTime date, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value == null || prop.Value < date)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be greater than {date.ToString("MM/dd/yyyy")}." : message);

            return this;
        }

        /// <summary>
        /// Given an integer, add a notification if it's not lower than some other value
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsLowerThan(Expression<Func<T, int>> selector, int number, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value > number)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be lower than {number}." : message);

            return this;
        }

        /// <summary>
        /// Given an decimal, add a notification if it's not lower than some other value
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsLowerThan(Expression<Func<T, decimal>> selector, decimal number, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value > number)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be lower than {number}." : message);

            return this;
        }

        /// <summary>
        /// Given an double, add a notification if it's not lower than some other value
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsLowerThan(Expression<Func<T, double>> selector, double number, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value > number)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be lower than {number}." : message);

            return this;
        }

        /// <summary>
        /// Given a DateTime, add a notification if it's not lower than some other date
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="date">Date to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsLowerThan(Expression<Func<T, DateTime>> selector, DateTime date, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value > date)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be lower than {date.ToString("MM/dd/yyyy")}." : message);

            return this;
        }

        /// <summary>
        /// Given a nullabl DateTime, add a notification if it's not lower than some other date
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="date">Date to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsLowerThan(Expression<Func<T, DateTime?>> selector, DateTime date, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value != null && prop.Value > date)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be lower than {date.ToString("MM/dd/yyyy")}." : message);

            return this;
        }

        /// <summary>
        /// Given an integer, add a notification if it's not between some two values
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsBetween(Expression<Func<T, int>> selector, int a, int b, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value < a || prop.Value > b)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be between {a} and {b}." : message);

            return this;
        }

        /// <summary>
        /// Given a decimal, add a notification if it's not between some two values
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsBetween(Expression<Func<T, decimal>> selector, decimal a, decimal b, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value < a || prop.Value > b)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be between {a} and {b}." : message);

            return this;
        }

        /// <summary>
        /// Given a double, add a notification if it's not between some two values
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsBetween(Expression<Func<T, double>> selector, double a, double b, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value < a || prop.Value > b)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be between {a} and {b}." : message);

            return this;
        }

        /// <summary>
        /// Given a DateTime, add a notification if it's not between some two values
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsBetween(Expression<Func<T, DateTime>> selector, DateTime a, DateTime b, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value < a || prop.Value > b)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be between {a.ToString("MM/dd/yyyy")} and {b.ToString("MM/dd/yyyy")}." : message);

            return this;
        }

        /// <summary>
        /// Given a nullable DateTime, add a notification if it's not between some two values
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsBetween(Expression<Func<T, DateTime?>> selector, DateTime a, DateTime b, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value != null && (prop.Value < a || prop.Value > b))
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be between {a:MM/dd/yyyy} and {b:MM/dd/yyyy}." : message);

            return this;
        }

        /// <summary>
        /// Given a string, add a notification if it's not contains a text
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> Contains(Expression<Func<T, string>> selector, string text, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (!prop.Value.Contains(text))
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} must be contains {text}." : message);

            return this;
        }

        /// <summary>
        /// Given an object, add a notification if it's not null
        /// </summary>
        /// <param name="obj">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsNull(object obj, string message)
        {
            if (obj != null)
                _validatable.AddNotification("", message);

            return this;
        }

        /// <summary>
        /// Given an object, add a notification if it's null
        /// </summary>
        /// <param name="obj">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsNotNull(object obj, string message)
        {
            if (obj == null)
                _validatable.AddNotification("", message);

            return this;
        }

        /// <summary>
        /// Given a string, add a notification if it's not equals to other
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="text">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> AreEquals(Expression<Func<T, string>> selector, string text, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (!prop.Value.Equals(text, StringComparison.OrdinalIgnoreCase))
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} should be equals to {text}." : message);

            return this;
        }

        /// <summary>
        /// Given a integer, add a notification if it's not equals to other
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> AreEquals(Expression<Func<T, int>> selector, int val, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value != val)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} should be equals to {val}." : message);

            return this;
        }

        /// <summary>
        /// Given a decimal, add a notification if it's not equals to other
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> AreEquals(Expression<Func<T, decimal>> selector, decimal val, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value != val)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} should be equals to {val}." : message);

            return this;
        }

        /// <summary>
        /// Given a double, add a notification if it's not equals to other
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> AreEquals(Expression<Func<T, double>> selector, double val, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value != val)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} should be equals to {val}." : message);

            return this;
        }

        /// <summary>
        /// Given a boolean, add a notification if it's not equals to other
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> AreEquals(Expression<Func<T, bool>> selector, bool val, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value != val)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} should be equals to {val}." : message);

            return this;
        }

        /// <summary>
        /// Given a DateTime, add a notification if it's not equals to other
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> AreEquals(Expression<Func<T, DateTime>> selector, DateTime val, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value != val)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} should be equals to {val:MM/dd/yyyy}." : message);

            return this;
        }

        /// <summary>
        /// Given a nullable DateTime, add a notification if it's not equals to other
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> AreEquals(Expression<Func<T, DateTime?>> selector, DateTime val, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value != val)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} should be equals to {val:MM/dd/yyyy}." : message);

            return this;
        }

        /// <summary>
        /// Given a string, add a notification if it's equals to other
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="text">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> AreNotEquals(Expression<Func<T, string>> selector, string text, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value.Equals(text, StringComparison.OrdinalIgnoreCase))
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} should be equals to {text}." : message);

            return this;
        }

        /// <summary>
        /// Given a integer, add a notification if it's equals to other
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> AreNotEquals(Expression<Func<T, int>> selector, int val, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value == val)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} should be equals to {val}." : message);

            return this;
        }

        /// <summary>
        /// Given a decimal, add a notification if it's equals to other
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> AreNotEquals(Expression<Func<T, decimal>> selector, decimal val, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value == val)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} should be equals to {val}." : message);

            return this;
        }

        /// <summary>
        /// Given a double, add a notification if it's equals to other
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> AreNotEquals(Expression<Func<T, double>> selector, double val, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value == val)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} should be equals to {val}." : message);

            return this;
        }

        /// <summary>
        /// Given a boolean, add a notification if it's equals to other
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> AreNotEquals(Expression<Func<T, bool>> selector, bool val, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value == val)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} should be equals to {val}." : message);

            return this;
        }

        /// <summary>
        /// Given a DateTime, add a notification if it's equals to other
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> AreNotEquals(Expression<Func<T, DateTime>> selector, DateTime val, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value == val)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} should be equals to {val:MM/dd/yyyy}." : message);

            return this;
        }

        /// <summary>
        /// Given a nullable DateTime, add a notification if it's equals to other
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> AreNotEquals(Expression<Func<T, DateTime?>> selector, DateTime val, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value == val)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} should be equals to {val:MM/dd/yyyy}." : message);

            return this;
        }

        /// <summary>
        /// Given a boolean, add a notification if it's not true
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsTrue(Expression<Func<T, bool>> selector, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value == false)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} should be true." : message);

            return this;
        }

        /// <summary>
        /// Given a boolean, add a notification if it's not false
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsFalse(Expression<Func<T, bool>> selector, string message = "")
        {
            var prop = GetPropertyResolver(selector);

            if (prop.Value == true)
                _validatable.AddNotification(prop.Name, string.IsNullOrEmpty(message) ? $"Field {prop.Name} should be false." : message);

            return this;
        }
    }
}
