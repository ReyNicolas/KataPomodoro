using Models;
using NUnit.Framework;


public class PomodoTest
{
    private float initialStandardTime;

    [SetUp]
    public void Setup()
    {
        initialStandardTime = 25;
    }

    [Test]
    public void Pomodoro_ShouldStartWithStandardMinutes()
    {

        //act
        var pomodoro = new Pomodoro();
        //assert
        Assert.AreEqual(initialStandardTime, pomodoro.InitialTime);
    }
    [Test]
    public void Pomodoro_ShouldStarWithDiferentMinutes()
    {
        float otherTime = 30;
        //Act
        var pomodoro = new Pomodoro(otherTime);
        //Assert
        Assert.AreEqual(otherTime, pomodoro.InitialTime);
    }
    [Test]
    public void Pomodoro_ShouldStartStopped()
    {
        //arrange
        //act
        var pomodoro = new Pomodoro();
        //assert
        Assert.IsTrue(pomodoro.IsStopped());
    }
    [Test]
    public void Start_ShouldSetStoppedFalse()
    {
        //arrange
        var pomodoro = new Pomodoro();
        //act        
        pomodoro.Start();
        //assert
        Assert.IsFalse(pomodoro.IsStopped());
    }
    [Test]
    public void IsFinished_ShouldReturnFalse_WhenNotStarted()
    {
        //act
        var pomodoro = new Pomodoro();
        //assert
        Assert.IsFalse(pomodoro.IsFinished());
    }
    [Test]
    public void IsFinished_ShouldReturnTrue_WhenTimeIsZero()
    {
        var pomodoro = new Pomodoro(0);
        //act
        pomodoro.Start();
        //assert
        Assert.IsTrue(pomodoro.IsFinished());
    }
    [Test]
    public void Interrupt_ShouldSetInterrupted_WhenStopped()
    {
        var pomodoro = new Pomodoro();
        //act
        pomodoro.Interrupt();
        //assert
        Assert.IsFalse(pomodoro.IsInterrupted());
    }
    [Test]
    public void Interrupt_ShouldSetInterrupted_WhenNotStopped()
    {
        var pomodoro = new Pomodoro();
        //act
        pomodoro.Start();
        pomodoro.Interrupt();
        //assert
        Assert.IsTrue(pomodoro.IsInterrupted());
    }
    [Test]
    public void Restart_ShouldResetTimeToInitialTime()
    {
        var pomodoro = new Pomodoro();
        //act
        pomodoro.Start();
        pomodoro.SubstractTime(10);
        pomodoro.Interrupt();
        pomodoro.Restart();
        //assert
        Assert.AreEqual(initialStandardTime, pomodoro.Time);
    }
    [Test]
    public void Restart_DoNothing_WhenNotInterrupted()
    {
        var pomodoro = new Pomodoro();
        //act
        pomodoro.Start();
        pomodoro.SubstractTime(10);
        pomodoro.Restart();
        //assert
        Assert.IsFalse(pomodoro.IsInterrupted());
        Assert.IsFalse(initialStandardTime == pomodoro.Time);
    }
}
