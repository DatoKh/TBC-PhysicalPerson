using System;
using System.Linq.Expressions;

namespace Common.Shared.Specifications
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();
    }
}
