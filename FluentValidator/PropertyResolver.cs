using System;
using System.Linq.Expressions;

namespace FluentValidator
{
    internal class PropertyResolver<TObject, TValue>
    {
        public PropertyResolver(TObject instance, Expression<Func<TObject, TValue>> selector)
        {
            Value = selector.Compile().Invoke(instance);
            Name = ((MemberExpression)selector.Body).Member.Name;
        }

        public string Name { get; private set; } 
        public TValue Value { get; private set; }
    }
}