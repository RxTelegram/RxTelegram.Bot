using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using RxTelegram.Bot.Api;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.Setup;

namespace RxTelegram.Bot.UnitTests;

[TestFixture]
public class UpdateManagerTest
{
    private Mock<ITelegramBot> _telegramBotMock = new();

    [SetUp]
    public void TestInitialize()
    {
        _telegramBotMock = new Mock<ITelegramBot>();
    }

    [Test]
    public void TestGetUpdateTypes()
    {
        var botInfo = new BotInfo("123456:ABC-DEFG1234ghIkl-zyx57W2v1u123ew11");
        var telegram = new TelegramBot(botInfo);
        var updateManager = new UpdateManager(telegram);
        updateManager.Message.Subscribe();
        updateManager.EditedChannelPost.Subscribe();

        var updateTypes = updateManager.UpdateTypes.ToList();
        Assert.That(updateTypes.Count, Is.EqualTo(2));
        CollectionAssert.Contains(updateTypes, UpdateType.Message);
        CollectionAssert.Contains(updateTypes, UpdateType.EditedChannelPost);
    }

    [Test]
    public void Constructor_InitializesCorrectly()
    {
        // Arrange
        var updateManager = new UpdateManager(_telegramBotMock.Object);

        // Assert
        Assert.IsNotNull(updateManager.Update);
        Assert.IsNotNull(updateManager.Message);
        Assert.IsNotNull(updateManager.EditedMessage);
        Assert.IsNotNull(updateManager.InlineQuery);
        Assert.IsNotNull(updateManager.ChosenInlineResult);
        Assert.IsNotNull(updateManager.CallbackQuery);
        Assert.IsNotNull(updateManager.ChannelPost);
        Assert.IsNotNull(updateManager.EditedChannelPost);
        Assert.IsNotNull(updateManager.ShippingQuery);
        Assert.IsNotNull(updateManager.PreCheckoutQuery);
        Assert.IsNotNull(updateManager.Poll);
        Assert.IsNotNull(updateManager.PollAnswer);
    }

    [Test]
    [TestCaseSource(nameof(GetUpdateTypes))]
    public void Subscribe_Should_Add_Observer_And_Retain_In_Observers_List(UpdateType updateType)
    {
        // Arrange
        var updateObserverMock = new Mock<IObserver<Update>>();

        // Act
        var updateManager = new UpdateManager(_telegramBotMock.Object);
        updateManager.Subscribe(updateType, updateObserverMock.Object);

        // Assert
        Assert.Contains(updateObserverMock.Object, updateManager.GetObservers(updateType));
    }

    [Test]
    [TestCaseSource(nameof(GetUpdateTypes))]
    public async Task Remove_Should_Remove_Observer_From_Observers_List(UpdateType updateType)
    {
        // Arrange
        var updateObserverMock = new Mock<IObserver<Update>>();
        var updateManager = new UpdateManager(_telegramBotMock.Object);

        // Act
        await updateManager.RunUpdateSafe();
        updateManager.Subscribe(updateType, updateObserverMock.Object);
        updateManager.Remove(updateType, updateObserverMock.Object);

        // Assert
        CollectionAssert.DoesNotContain(updateManager.GetObservers(updateType), updateObserverMock.Object);
    }

    [Test]
    public void Given_TelegramBotException_On_RunUpdateSafe_Should_Handle_Exception()
    {
        // Arrange
        _telegramBotMock.Setup(m => m.GetUpdate(It.IsAny<GetUpdate>(), It.IsAny<CancellationToken>()))
                        .Throws(new Exception());

        // Assert
        Assert.DoesNotThrowAsync(async () =>
                                 {
                                     var updateManager = new UpdateManager(_telegramBotMock.Object);
                                     await updateManager.RunUpdateSafe();
                                 });
    }

    [Test]
    public void Given_NoObserver_On_RunUpdate_Should_Return()
    {
        // Arrange
        var updateManager = new UpdateManager(_telegramBotMock.Object);

        // Assert
        Assert.DoesNotThrowAsync(async () => { await updateManager.RunUpdate(); });
    }

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_Observers()
    {
        // Arrange
        var observer = new Mock<IObserver<Update>>();
        var updateManager = new UpdateManager(_telegramBotMock.Object);
        var disposable = updateManager.Update.Subscribe(observer.Object);
        var updates = new[] { new Update { Message = new Message() } };

        // Act
        updateManager.DistributeUpdates(updates);

        // Assert
        observer.Verify(o => o.OnNext(It.IsAny<Update>()), Times.Once);
        disposable.Dispose();
    }

    [Test]
    [TestCaseSource(nameof(GetUpdateTypes))]
    public void OnException_WhenCalled_DistributesExceptionToObservers(UpdateType updateType)
    {
        // Arrange
        var telegramBotMock = new Mock<ITelegramBot>();
        var updateManager = new UpdateManager(telegramBotMock.Object);
        var observer1Mock = new Mock<IObserver<Update>>();
        var observer2Mock = new Mock<IObserver<Update>>();
        // Assuming that Subscribe method works as expected and adds observers correctly
        updateManager.Subscribe(updateType, observer1Mock.Object);
        updateManager.Subscribe(updateType, observer2Mock.Object);

        var exception = new Exception();

        // Act
        try
        {
            updateManager.OnException(exception);
        }
        catch
        {
            // ignored
        }

        // Assert
        observer1Mock.Verify(o => o.OnError(exception), Times.Once);
        observer2Mock.Verify(o => o.OnError(exception), Times.Once);
    }

    public static Array GetUpdateTypes() => Enum.GetValues(typeof(UpdateType));
}
