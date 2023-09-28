using System;
using NSubstitute;
using NUnit.Framework;
using Presenters;


public class PomodoroPresenterTest
{
    // A Test behaves as an ordinary method
    IView view;
    PomodoroPresenter presenter;

    [SetUp]
    public void Setup()
    {
        view = Substitute.For<IView>();
        presenter = new PomodoroPresenter();
    }
    [Test]
    public void Initialize_OnStartButtonEventRaise_ShouldInitTime()
    {
        // Arrange
        presenter.Initialize(view);

        // Act
        view.OnStart += Raise.Event<Action>();
       
        // Assert
        view.Received().UpdateTime(Arg.Any<float>());
    }
    [Test]
    public void Initialize_OnInterruptButtonEventRaise_ShouldInterruptTime()
    {
        // Arrange
        presenter.Initialize(view);

        // Act
        view.OnStart += Raise.Event<Action>();      
        view.OnInterrupt += Raise.Event<Action>();

        // Assert
        view.Received().UpdateTime(Arg.Any<float>());
    }
    [Test]
    public void Initialize_OnRestartButtonEventRaise_ShouldRestartTime()
    {
        // Arrange
        presenter.Initialize(view);

        // Act
        view.OnStart += Raise.Event<Action>();
        view.OnInterrupt += Raise.Event<Action>();
        view.OnRestart += Raise.Event<Action>();

        // Assert
        view.Received().UpdateTime(Arg.Any<float>());
    }
}
