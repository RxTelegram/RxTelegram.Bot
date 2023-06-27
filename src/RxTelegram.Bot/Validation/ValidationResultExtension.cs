using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RxTelegram.Bot.Interface.Validation;

namespace RxTelegram.Bot.Validation;

public static class ValidationResultExtension
{
    /// <summary>
    /// Basic Method to add a new ValidationError to ValidationErrors
    /// </summary>
    /// <param name="res"></param>
    /// <param name="property">Property which is involved in the error</param>
    /// <param name="error">Errormessage as String</param>
    private static void AddNewValidationError<T>(ValidationResult<T> res, List<string> property, string error) =>
        res.ValidationErrors.Add(new ValidationError(property, error));

    /// <summary>
    /// Basic Method to add a new ValidationError to ValidationErrors
    /// </summary>
    /// <param name="res"></param>
    /// <param name="property">Property which is involved in the error</param>
    /// <param name="error">Errormessage as Enum</param>
    private static void AddNewValidationError<T>(ValidationResult<T> res, List<string> property, ValidationErrors error) =>
        res.ValidationErrors.Add(new ValidationError(property, error));

    /// <summary>
    /// Test whether the condition evaluates to false. If so, we add a new error to the ValidationErrors
    /// </summary>
    /// <param name="res"></param>
    /// <param name="condition">Condition to test for</param>
    /// <param name="validationErrors">Enum error for Errormessage</param>
    /// <param name="error">Error message string</param>
    public static ValidationResult<T> IsTrue<T>(
        this ValidationResult<T> res,
        Expression<Func<T, bool>> condition,
        ValidationErrors? validationErrors = null,
        string error = null) => BoolComparison(res, condition, false, validationErrors, error);

    /// <summary>
    /// Test whether the condition evaluates to true. If so, we add a new error to the ValidationErrors
    /// </summary>
    /// <param name="res"></param>
    /// <param name="condition">Condition to test for</param>
    /// <param name="validationErrors">Enum error for Errormessage</param>
    /// <param name="error">Error message string</param>
    public static ValidationResult<T> IsFalse<T>(
        this ValidationResult<T> res,
        Expression<Func<T, bool>> condition,
        ValidationErrors? validationErrors = null,
        string error = null) => BoolComparison(res, condition, true, validationErrors, error);

    private static ValidationResult<T> BoolComparison<T>(
        ValidationResult<T> res,
        Expression<Func<T, bool>> condition,
        bool shouldBe,
        ValidationErrors? validationErrors = null,
        string error = null)
    {
        var memberNames = GetMemberNames(condition)
                          .Distinct()
                          .OrderBy(x => x)
                          .ToList();
        var conditionFunc = condition.Compile();
        if (conditionFunc(res.Value) == shouldBe)
        {
            return res;
        }

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
    /// <param name="selector">List of Required Properties</param>
    /// <param name="res">Objects that keeps track of all Validation Errors</param>
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
            AddNewValidationError(res,
                                  new List<string> {string.IsNullOrEmpty(property?.Name) ? "Property name not found!" : property.Name},
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

    private static IEnumerable<string> GetMemberNames<T>(Expression<Func<T, bool>> expression)
    {
        var stack = new Stack<Expression>(new[] {expression});
        while (stack.Count > 0)
        {
            switch (stack.Pop())
            {
                case null:
                case ConstantExpression _:
                case ParameterExpression _:
                    // ignore
                    break;
                case LambdaExpression lambdaExpression:
                {
                    if (lambdaExpression.Body is BinaryExpression binaryExpression)
                    {
                        stack.Push(binaryExpression.Left);
                        stack.Push(binaryExpression.Right);
                        break;
                    }

                    if (lambdaExpression.Body is MethodCallExpression methodCallExpression)
                    {
                        foreach (var argument in methodCallExpression.Arguments)
                        {
                            stack.Push(argument);
                        }
                        break;
                    }
                    throw new NotImplementedException();
                }
                case BinaryExpression binaryExpression:
                {
                    stack.Push(binaryExpression.Left);
                    stack.Push(binaryExpression.Right);
                    break;
                }
                case MethodCallExpression methodCallExpression:
                    foreach (var argument in methodCallExpression.Arguments)
                    {
                        stack.Push(argument);
                    }
                    stack.Push(methodCallExpression.Object);
                    break;
                case MemberExpression memberExpression:
                    stack.Push(memberExpression.Expression);
                    if (memberExpression.Member.DeclaringType == typeof(T)) {
                        yield return memberExpression.Member.Name;
                    }
                    break;
                case UnaryExpression unaryExpression:
                    stack.Push(unaryExpression.Operand);
                    break;
                case NewExpression newExpression:
                    foreach (var item in newExpression.Arguments)
                    {
                        stack.Push(item);
                    }

                    break;
                case NewArrayExpression newArrayExpression:
                    foreach (var item in newArrayExpression.Expressions)
                    {
                        stack.Push(item);
                    }

                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    internal static void ValidateNested<T>(this ValidationResult<T> res)
    {
        foreach (var propertyInfo in res.Value.GetType().GetProperties())
        {
            // Check if we need to validate this property
            if(propertyInfo.PropertyType.IsClass && typeof(BaseValidation).IsAssignableFrom(propertyInfo.PropertyType))
            {
                // Get the value of the Property
                var value = propertyInfo.GetValue(res.Value, null);
                if (value is BaseValidation baseValidation)
                {
                    res.ValidationErrors.AddRange(baseValidation.Errors);
                    baseValidation.SetPath($"{propertyInfo.Name}");
                    res.Errors
                       .ForEach(x => x.AddPath(baseValidation.GetPath()));
                }
                continue;
            }

            // if the property's type is some kind of collection, we need to validate each item in the list
            if (typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType) &&
                typeof(BaseValidation).IsAssignableFrom(propertyInfo.PropertyType.GetGenericArguments()
                                                                    .FirstOrDefault()))
            {
                // Get the value of the Property
                var value = propertyInfo.GetValue(res.Value, null);
                if (!(value is IEnumerable list))
                {
                    continue;
                }

                var i = 0;
                foreach (var ag in list)
                {
                    if (ag is BaseValidation bv)
                    {
                        res.ValidationErrors.AddRange(bv.Errors);
                        bv.SetPath($"{propertyInfo.Name}[{i}]");
                        res.Errors.ForEach(x => x.AddPath(bv.GetPath()));
                    }
                    i++;
                }

            }
        }
    }
}
