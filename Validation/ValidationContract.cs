using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Validation
{
    public class ValidationContract<T> where T : Notifiable
    {
        private readonly T _validatable;

        public ValidationContract(T validatable)
        {
            _validatable = validatable;
        }

        /// <summary>
        /// Given a string, add a notification if it's null or empty
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsRequired(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(val))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} is required." : message);

            return this;
        }

        /// <summary>
        /// Given a string, add a notification if it's length is less than min parameter
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> HasMinLenght(Expression<Func<T, string>> selector, int min, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty(val) && val.Length < min)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must have at least {min} characters." : message);

            return this;
        }

        /// <summary>
        /// Given a string, add a notification if it's length is greater than max parameter
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="max">Maximum Length</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> HasMaxLenght(Expression<Func<T, string>> selector, int max, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty(val) && val.Length > max)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must have {max} characters." : message);

            return this;
        }

        /// <summary>
        /// Given a string, add a notification if it's length is different from length parameter
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="length">Especific Length</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsFixedLenght(Expression<Func<T, string>> selector, int length, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty(val) && val.Length != length)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must have exactly {length} characters." : message);

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
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty(val) && !Regex.IsMatch(val, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be a valid E-mail address." : message);

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
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty(val) && !Regex.IsMatch(val, @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$"))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be a valid URL." : message);

            return this;
        }

        /// <summary>
        /// Given an int, add a notification if it's not greater than some other value
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsGreaterThan(Expression<Func<T, int>> selector, int number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be greater than {number}." : message);

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
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be greater than {number}." : message);

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
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be greater than {number}." : message);

            return this;
        }

        /// <summary>
        /// Given a Date, add a notification if it's not greater than some other date
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="date">Date to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsGreaterThan(Expression<Func<T, DateTime>> selector, DateTime date, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < date)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be greater than {date.ToShortDateString()}." : message);

            return this;
        }

        /// <summary>
        /// Given an int, add a notification if it's not lower than some other value
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsLowerThan(Expression<Func<T, int>> selector, int number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be lower than {number}." : message);

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
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be lower than {number}." : message);

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
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be lower than {number}." : message);

            return this;
        }

        /// <summary>
        /// Given a Date, add a notification if it's not lower than some other date
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="date">Date to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsLowerThan(Expression<Func<T, DateTime>> selector, DateTime date, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > date)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be lower than {date.ToShortDateString()}." : message);

            return this;
        }

        /// <summary>
        /// Given an int, add a notification if it's not greater than some other value
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public ValidationContract<T> IsBetween(Expression<Func<T, int>> selector, int a, int b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < a || val > b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be between {a} and {b}." : message);

            return this;
        }
        // Between - int, decimal, double, date
        // Contains - String
    }
}
