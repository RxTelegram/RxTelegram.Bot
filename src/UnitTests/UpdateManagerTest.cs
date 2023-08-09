using System;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using RxTelegram.Bot.Api;
using RxTelegram.Bot.Interface.BaseTypes;
using RxTelegram.Bot.Interface.BaseTypes.Enums;
using RxTelegram.Bot.Interface.Setup;

namespace RxTelegram.Bot.UnitTests;

[TestFixture]
public class UpdateManagerTest
{
    private ITelegramBot _telegramBotMock = Substitute.For<ITelegramBot>();

    [SetUp]
    public void TestInitialize()
    {
        _telegramBotMock = Substitute.For<ITelegramBot>();
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
        var updateManager = new UpdateManager(_telegramBotMock);

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
        var updateObserverMock = Substitute.For<IObserver<Update>>();

        // Act
        var updateManager = new UpdateManager(_telegramBotMock);
        updateManager.Subscribe(updateType, updateObserverMock);

        // Assert
        Assert.Contains(updateObserverMock, updateManager.GetObservers(updateType));
    }

    [Test]
    [TestCaseSource(nameof(GetUpdateTypes))]
    public async Task Remove_Should_Remove_Observer_From_Observers_List(UpdateType updateType)
    {
        // Arrange
        var updateObserverMock = Substitute.For<IObserver<Update>>();
        var updateManager = new UpdateManager(_telegramBotMock);

        // Act
        await updateManager.RunUpdateSafe();
        updateManager.Subscribe(updateType, updateObserverMock);
        updateManager.Remove(updateType, updateObserverMock);

        // Assert
        CollectionAssert.DoesNotContain(updateManager.GetObservers(updateType), updateObserverMock);
    }

    [Test]
    public void Given_TelegramBotException_On_RunUpdateSafe_Should_Handle_Exception()
    {
        // Arrange
        _telegramBotMock.GetUpdate(default, default)
                        .ThrowsForAnyArgs(new Exception());

        // Assert
        Assert.DoesNotThrowAsync(async () =>
                                 {
                                     var updateManager = new UpdateManager(_telegramBotMock);
                                     await updateManager.RunUpdateSafe();
                                 });
    }

    [Test]
    public void Given_NoObserver_On_RunUpdate_Should_Return()
    {
        // Arrange
        var updateManager = new UpdateManager(_telegramBotMock);

        // Assert
        Assert.DoesNotThrowAsync(async () => { await updateManager.RunUpdate(); });
    }

    [Test]
    public void Given_ValidUpdate_On_DistributeUpdates_Should_PushUpdatesTo_Observers()
    {
        // Arrange
        var observer = Substitute.For<IObserver<Update>>();
        var updateManager = new UpdateManager(_telegramBotMock);
        var disposable = updateManager.Update.Subscribe(observer);
        var updates = new[] { new Update { Message = new Message() } };

        // Act
        updateManager.DistributeUpdates(updates);

        // Assert
        observer.Received().OnNext(updates.Single());
        disposable.Dispose();
    }

    [Test]
    [TestCaseSource(nameof(GetUpdateTypes))]
    public void OnException_WhenCalled_DistributesExceptionToObservers(UpdateType updateType)
    {
        // Arrange
        var telegramBotMock = Substitute.For<ITelegramBot>();
        var updateManager = new UpdateManager(telegramBotMock);
        var observer1Mock = Substitute.For<IObserver<Update>>();
        var observer2Mock = Substitute.For<IObserver<Update>>();
        // Assuming that Subscribe method works as expected and adds observers correctly
        updateManager.Subscribe(updateType, observer1Mock);
        updateManager.Subscribe(updateType, observer2Mock);

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
        observer1Mock.Received().OnError(exception);
        observer2Mock.Received().OnError(exception);
    }

    public static Array GetUpdateTypes() => Enum.GetValues(typeof(UpdateType));
}
