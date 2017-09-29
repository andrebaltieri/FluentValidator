using System;

namespace FluentValidator.Validation
{
    public partial class ValidationContract
    {
        public ValidationContract AreEquals(Guid val, Guid comparer, string property, string message)
        {
            // TODO: StringComparison.OrdinalIgnoreCase not suported yet
            if (val.ToString() != comparer.ToString())
                AddNotification(property, message, val, comparer);

            return this;
        }

        public ValidationContract AreNotEquals(Guid val, Guid comparer, string property, string message)
        {
            // TODO: StringComparison.OrdinalIgnoreCase not suported yet
            if (val.ToString() == comparer.ToString())
                AddNotification(property, message, val, comparer);

            return this;
        }
    }
}