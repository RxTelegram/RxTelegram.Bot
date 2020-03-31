using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace RxTelegram.Bot.Interface.Validation
{
    public abstract class BaseValidation
    {
        [JsonIgnore]
        public List<ValidationError> ValidationErrors { get; } = new List<ValidationError>();

        /// <summary>
        /// Basic Method to add a new ValidationError to ValidationErrors
        /// </summary>
        /// <param name="property">Property which is involved in the error</param>
        /// <param name="error">Errormessage as String</param>
        protected void AddNewValidationError(string property, string error) => ValidationErrors.Add(new ValidationError(property, error));

        /// <summary>
        /// Basic Method to add a new ValidationError to ValidationErrors
        /// </summary>
        /// <param name="property">Property which is involved in the error</param>
        /// <param name="error">Errormessage as Enum</param>
        protected void AddNewValidationError(string property, ValidationErrors error) =>
            ValidationErrors.Add(new ValidationError(property, error));

        /// <summary>
        /// Test whether the condition evaluates to false. If so, we add a new error to the ValidationErrors
        /// </summary>
        /// <param name="condition">Condition to test for</param>
        /// <param name="validationErrors">Enum error for Errormessage</param>
        /// <param name="property">Property which is involved in the error</param>
        protected void ValidateCondition(bool condition, ValidationErrors validationErrors, params string[] property)
        {
            if (condition == false)
            {
                AddNewValidationError(string.Join(", ", property), validationErrors);
            }
        }

        #region Required Properties
        /// <summary>
        /// Checks if all properties given by selectors are unequal to default. If not a ValidationError is created.
        /// </summary>
        /// <param name="selectors">List of Required Properties</param>
        /// <typeparam name="T">Type of Class which has the properties</typeparam>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        protected void ValidateRequired<T>(params Expression<Func<T, object>>[] selectors)
        {
            foreach (var selector in selectors)
            {
                if (selector.NodeType != ExpressionType.Lambda)
                {
                    throw new ArgumentException("Selector must be lambda expression", nameof(selector));
                }

                var lambda = (LambdaExpression) selector;

                var memberExpression = ExtractMemberExpression(lambda.Body);

                if (memberExpression == null)
                {
                    throw new ArgumentException("Selector must be member access expression", nameof(selector));
                }

                if (memberExpression.Member.DeclaringType == null)
                {
                    throw new InvalidOperationException("Property does not have declaring type");
                }

                var property = memberExpression.Member.DeclaringType.GetProperty(memberExpression.Member.Name);
                var value = property?.GetValue(this);
                if (value == null || value != GetDefault(value.GetType()))
                {
                    AddNewValidationError(string.IsNullOrEmpty(property?.Name) ? "Property name not found!" : property.Name,
                                          Validation.ValidationErrors.FieldRequired);
                }
            }
        }

        /// <summary>
        /// Get the default of any type. Unlike "default" keyword-
        /// </summary>
        /// <param name="t">Type where to get the default Value of</param>
        /// <returns>The default Value</returns>
        private object GetDefault(Type t) => GetType()
                                             .GetMethod(nameof(GetDefaultGeneric))
                                             ?.MakeGenericMethod(t)
                                             .Invoke(this, null);

        /// <summary>
        /// Helper Method for Reflection. DO NOT USE! (Except of Reflection)
        /// </summary>
        /// <typeparam name="TT"></typeparam>
        /// <returns></returns>
        private static TT GetDefaultGeneric<TT>() => default;

        /// <summary>
        /// Gets MemberExpression of any expression
        /// </summary>
        /// <param name="expression">Expression where to get the MemberExpression from</param>
        /// <returns>MemberExpression</returns>
        private static MemberExpression ExtractMemberExpression(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return (MemberExpression) expression;
                case ExpressionType.Convert:
                {
                    var operand = ((UnaryExpression) expression).Operand;
                    return ExtractMemberExpression(operand);
                }
                default:
                    return null;
            }
        }
        #endregion

        protected abstract void Validate();

        public bool IsValid()
        {
             Validate();
             return ValidationErrors.Any();
        }

    }
}
