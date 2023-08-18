using System.Collections.Generic;
using NUnit.Framework;
using RxTelegram.Bot.Validation;

namespace RxTelegram.Bot.UnitTests;

[TestFixture]
public class ValidationErrorTest
{
    [Test]
    [TestCase("Property", "", "(Property): \"\"")]
    [TestCase("Path1.Property1", "Test Error", "(Path1.Property1): \"Test Error\"")]
    [TestCase("Path1.Path2.Property1", "Test Error", "(Path1.Path2.Property1): \"Test Error\"")]
    public void GetMessage_ShouldGenerateCorrectly_WithPropertyGiven(
        string property,
        string message,
        string expectedResult)
    {
        // Arrange
        var target = new ValidationError(new List<string> { property }, message);

        // Act
        var result = target.GetMessage;

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    [TestCase("Property1", "Property2", "Test Error", "(Property1, Property2): \"Test Error\"")]
    [TestCase("Path1.Path2.Property1", "Path1.Path2.Property2", "Test Error",
              "(Path1.Path2.Property1, Path1.Path2.Property2): \"Test Error\"")]
    public void GetMessage_ShouldGenerateCorrectly_WithPropertiesGiven(
        string prop1,
        string prop2,
        string errorMessage,
        string expectedResult)
    {
        // Arrange
        var target = new ValidationError(new List<string> { prop1, prop2 }, errorMessage);

        // Act
        var result = target.GetMessage;

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void ToString_ShouldGenerateCorrectly_WithValidationErrorGiven()
    {
        // Arrange
        var target = new ValidationError("Property1", ValidationErrors.CommandLimit);

        // Act
        var result = target.ToString();

        // Assert
        Assert.AreEqual("(Property1): \"At most 100 commands can be specified.\"", result);
    }
}
