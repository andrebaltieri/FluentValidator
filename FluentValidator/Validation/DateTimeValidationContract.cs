using System;

namespace FluentValidator.Validation
{
    public partial class ValidationContract
    {
        public ValidationContract IsGreaterThan(DateTime val, DateTime comparer, string property, string message)
        {
            if (val <= comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsGreaterOrEqualsThan(DateTime val, DateTime comparer, string property, string message)
        {
            if (val < comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsLowerThan(DateTime val, DateTime comparer, string property, string message)
        {
            if (val >= comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsLowerOrEqualsThan(DateTime val, DateTime comparer, string property, string message)
        {
            if (val > comparer)
                AddNotification(property, message);

            return this;
        }
    }
}
