﻿using System;
using System.Linq.Expressions;

using LinqSpecs.ExpressionCombining;

namespace LinqSpecs
{
    /// <summary>
    /// Combines two specifications by using logical AND operation.
    /// </summary>
	class AndSpecification<T> : Specification<T>
	{
		readonly Specification<T> spec1;
		readonly Specification<T> spec2;

		public AndSpecification(Specification<T> spec1, Specification<T> spec2)
		{
            this.spec1 = spec1 ?? throw new ArgumentNullException("spec1");
			this.spec2 = spec2 ?? throw new ArgumentNullException("spec2");
		}

        public override Expression<Func<T, bool>> ToExpression()
		{
			var expr1 = spec1.ToExpression();
			var expr2 = spec2.ToExpression();
		    return expr1.AndAlso(expr2);
		}

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (GetType() != other.GetType())
                return false;

            var otherSpec = other as AndSpecification<T>;
            return spec1.Equals(otherSpec.spec1) && spec2.Equals(otherSpec.spec2);
        }

        public override int GetHashCode()
        {
            return spec1.GetHashCode() ^ spec2.GetHashCode() ^ GetType().GetHashCode();
        }
    }
}