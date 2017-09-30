using System;
using System.Collections.Generic;
using System.Text;

namespace FluentValidator.Validation
{
    public partial class ValidationContract
    {
        public ValidationContract Should<T>(Func<T, bool> obj, T value, string message)
        {
            var objResult = obj.Invoke(value);
            if (objResult)
                AddNotification(((System.Reflection.RuntimeMethodInfo)obj.Method).Name, message);

            return this;
        }
    }
}
