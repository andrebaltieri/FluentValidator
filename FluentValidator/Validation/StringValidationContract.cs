using System.Text.RegularExpressions;

namespace FluentValidator.Validation
{
    public partial class ValidationContract
    {
        public ValidationContract IsNotNullOrEmpty(string val, string property, string message)
        {
            if (string.IsNullOrEmpty(val))
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsNullOrEmpty(string val, string property, string message)
        {
            if (!string.IsNullOrEmpty(val))
                AddNotification(property, message);

            return this;
        }

        public ValidationContract HasMinLen(string val, int min, string property, string message)
        {
            if (val.Length < min)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract HasMaxLen(string val, int max, string property, string message)
        {
            if (val.Length > max)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract HasLen(string val, int len, string property, string message)
        {
            if (val.Length != len)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract Contains(string val, string text, string property, string message)
        {
            // TODO: StringComparison.OrdinalIgnoreCase not suported yet
            if (!val.Contains(text))
                AddNotification(property, message);

            return this;
        }

        public ValidationContract AreEquals(string val, string text, string property, string message)
        {
            // TODO: StringComparison.OrdinalIgnoreCase not suported yet
            if (val != text)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract AreNotEquals(string val, string text, string property, string message)
        {
            // TODO: StringComparison.OrdinalIgnoreCase not suported yet
            if (val == text)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsEmail(string email, string property, string message)
        {
            if (!Regex.IsMatch(email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsUrl(string url, string property, string message)
        {
            if (!Regex.IsMatch(url, @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$"))
                AddNotification(property, message);

            return this;
        }

        public ValidationContract Matchs(string text, string pattrn, string property, string message)
        {
            if (!Regex.IsMatch(text, pattrn))
                AddNotification(property, message);

            return this;
        }
    }
}