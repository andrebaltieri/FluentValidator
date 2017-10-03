using System;

namespace FluentValidator.Validation
{
    public partial class ValidationContract
    {
        public ValidationContract Must<T>(Func<T, bool> obj, T value, string message, string methodName = null)
        {
            var objResult = obj.Invoke(value);
            if (!objResult)
                AddNotification(methodName ?? obj.GetType().Name, message);

            return this;
        }
    }
}