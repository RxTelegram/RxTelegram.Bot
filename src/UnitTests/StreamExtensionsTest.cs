using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using RxTelegram.Bot.Utils;

namespace RxTelegram.Bot.UnitTests;

[TestFixture]
public class StreamExtensionsTests
{
    [Test]
    public async Task Deserialize_ShouldBeSuccessful_WithValidString()
    {
        // Arrange
        var stream = new MemoryStream("{\"Property\": \"Value\"}"u8.ToArray());

        // Act
        var result = await Task.FromResult((Stream)stream)
                               .Deserialize<TestObject>();

        // Assert
        Assert.That(result.Property, Is.EqualTo("Value"));
    }

    [Test]
    public void Deserialize_ShouldFail_WithInvalidJson()
    {
        // Arrange
        var stream = new MemoryStream("Invalid json"u8.ToArray());

        // Act
        var ex = Assert.ThrowsAsync<JsonReaderException>(() => Task.FromResult((Stream)stream)
                                                                   .Deserialize<TestObject>());

        // Assert
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Is.EqualTo("Error parsing Infinity value. Path '', line 1, position 2."));
    }

    [Test]
    public async Task Deserialize_ShouldBeSuccessful_WithNoStringGiven()
    {
        // Arrange
        var stream = new MemoryStream();

        // Assert
        await Task.FromResult((Stream)stream)
                  .Deserialize<TestObject>();
    }

    [Test]
    public void Deserialize_ShouldThrow_WithNullStream()
    {
        // Act
        var ex = Assert.ThrowsAsync<ArgumentNullException>(() => Task.FromResult((Stream)null)
                                                                     .Deserialize<TestObject>());

        // Assert
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'stream')"));
    }

    [Test]
    public void Deserialize_ShouldFail_WithInvalidType()
    {
        // Assert
        var stream = new MemoryStream("{\"Property\": \"Value\"}"u8.ToArray());

        // Act
        var ex = Assert.ThrowsAsync<JsonSerializationException>(() => Task.FromResult((Stream)stream)
                                                                          .Deserialize<Stream>());

        // Assert
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message,
                    Does.StartWith("Could not create an instance of type System.IO.Stream. Type is an interface or abstract class and cannot be instantiated."));
    }

    // ReSharper disable once ClassNeverInstantiated.Local
    private class TestObject
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        // ReSharper disable once NotNullOrRequiredMemberIsNotInitialized
        public string Property { get; set; }
    }
}
