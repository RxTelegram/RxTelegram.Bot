using System;
using System.Linq.Expressions;

namespace RxTelegram.Bot.Validation
{
    public static class ValidationResultExtension
    {
        /// <summary>
        /// Basic Method to add a new ValidationError to ValidationErrors
        /// </summary>
        /// <param name="res"></param>
        /// <param name="property">Property which is involved in the error</param>
        /// <param name="error">Errormessage as String</param>
        public static void AddNewValidationError(ValidationResult res, string property, string error) =>
            res.ValidationErrors.Add(new ValidationError(property, error));

        /// <summary>
        /// Basic Method to add a new ValidationError to ValidationErrors
        /// </summary>
        /// <param name="res"></param>
        /// <param name="property">Property which is involved in the error</param>
        /// <param name="error">Errormessage as Enum</param>
        public static void AddNewValidationError(ValidationResult res, string property, ValidationErrors error) =>
            res.ValidationErrors.Add(new ValidationError(property, error));

        /// <summary>
        /// Test whether the condition evaluates to false. If so, we add a new error to the ValidationErrors
        /// </summary>
        /// <param name="res"></param>
        /// <param name="condition">Condition to test for</param>
        /// <param name="validationErrors">Enum error for Errormessage</param>
        /// <param name="property">Property which is involved in the error</param>
        public static ValidationResult ValidateCondition(this ValidationResult res, bool condition, ValidationErrors validationErrors, params string[] property)
        {
            if (condition == false)
            {
                AddNewValidationError(res, string.Join(", ", property), validationErrors);
            }

            return res;
        }

        #region Required Properties

        /// <summary>
        /// Checks if all properties given by selectors are unequal to default. If not a ValidationError is created.
        /// </summary>
        /// <param name="selectors">List of Required Properties</param>
        /// <param name="res">Objects that keeps track of all Validation Errors</param>
        /// <param name="obj">use this</param>
        /// <typeparam name="T">Type of Class which has the properties</typeparam>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static ValidationResult ValidateRequired<T>(this ValidationResult res, object obj, Expression<Func<T, object>> selector)
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
            var value = property?.GetValue(obj);
            if (value == null ||
                value != GetDefault(value.GetType(), obj))
            {
                AddNewValidationError(res, string.IsNullOrEmpty(property?.Name) ? "Property name not found!" : property.Name,
                                      ValidationErrors.FieldRequired);
            }

            return res;
        }

        /// <summary>
        /// Get the default of any type. Unlike "default" keyword-
        /// </summary>
        /// <param name="t">Type where to get the default Value of</param>
        /// <param name="obj"></param>
        /// <returns>The default Value</returns>
        private static object GetDefault(Type t, object obj) => typeof(ValidationResultExtension).GetMethod(nameof(GetDefaultGeneric))
                                                                                                 ?.MakeGenericMethod(t)
                                                                                                 .Invoke(obj, null);

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
    }
}
