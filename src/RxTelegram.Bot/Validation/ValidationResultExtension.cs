using System;
using System.Collections.Generic;
using System.Linq;
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
        public static void AddNewValidationError<T>(ValidationResult<T> res, string property, string error) =>
            res.ValidationErrors.Add(new ValidationError(property, error));

        /// <summary>
        /// Basic Method to add a new ValidationError to ValidationErrors
        /// </summary>
        /// <param name="res"></param>
        /// <param name="property">Property which is involved in the error</param>
        /// <param name="error">Errormessage as Enum</param>
        public static void AddNewValidationError<T>(ValidationResult<T> res, string property, ValidationErrors error) =>
            res.ValidationErrors.Add(new ValidationError(property, error));

        /// <summary>
        /// Test whether the condition evaluates to false. If so, we add a new error to the ValidationErrors
        /// </summary>
        /// <param name="res"></param>
        /// <param name="condition">Condition to test for</param>
        /// <param name="validationErrors">Enum error for Errormessage</param>
        /// <param name="error">Error message string</param>
        public static ValidationResult<T> IsTrue<T>(
            this ValidationResult<T> res, Expression<Func<T, bool>> condition, ValidationErrors? validationErrors = null,
            string error = null) => BoolComparison(res, condition, false, validationErrors, error);

        /// <summary>
        /// Test whether the condition evaluates to true. If so, we add a new error to the ValidationErrors
        /// </summary>
        /// <param name="res"></param>
        /// <param name="condition">Condition to test for</param>
        /// <param name="validationErrors">Enum error for Errormessage</param>
        /// <param name="error">Error message string</param>
        public static ValidationResult<T> IsFalse<T>(
            this ValidationResult<T> res, Expression<Func<T, bool>> condition, ValidationErrors? validationErrors = null,
            string error = null) => BoolComparison(res, condition, true, validationErrors, error);

        private static ValidationResult<T> BoolComparison<T>(
            ValidationResult<T> res, Expression<Func<T, bool>> condition, bool shouldBe, ValidationErrors? validationErrors = null,
            string error = null)
        {
            var memberNames = GetMemberNames(condition);
            var conditionFunc = condition.Compile();
            if (conditionFunc(res.Value) == shouldBe)
                return res;
            if (validationErrors.HasValue)
            {
                AddNewValidationError(res, memberNames, validationErrors.Value);
            }
            else if (!string.IsNullOrEmpty(error))
            {
                AddNewValidationError(res, memberNames, error);
            }
            else
            {
                throw new NotImplementedException(nameof(validationErrors) + " or " + nameof(error) + "need to be set!");
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
        public static ValidationResult<T> ValidateRequired<T>(this ValidationResult<T> res, Expression<Func<T, object>> selector)
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
            var value = property?.GetValue(res.Value);
            if (value == null ||
                value == GetDefault(value.GetType(), res.Value))
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

        private static string GetMemberNames(Expression expression, List<string> result = null)
        {
            if (result == null)
            {
                result = new List<string>();
            }
            if (expression == null)
            {
                return string.Empty;
            }

            if (expression is LambdaExpression lambdaExpression)
            {
                var operation = (BinaryExpression)lambdaExpression.Body;
                if (operation.Left is MemberExpression operationLeft)
                {
                    result.Add(operationLeft.Member.Name);
                }

                if (operation.Right is MemberExpression operationRight)
                {
                    result.Add(operationRight.Member.Name);
                }
                GetMemberNames(operation.Left, result);
                GetMemberNames(operation.Right, result);
            }

            if (expression is BinaryExpression binaryExpression)
            {
                if (binaryExpression.Left is MemberExpression operationLeft)
                {
                    result.Add(operationLeft.Member.Name);
                }

                if (binaryExpression.Right is MemberExpression operationRight)
                {
                    result.Add(operationRight.Member.Name);
                }
            }

            return string.Join(", ", result.Distinct());
        }
    }
}
