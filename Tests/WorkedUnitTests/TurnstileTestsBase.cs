namespace WorkedUnitTests;

using Abstractions;

using FluentAssertions;

using Moq;

public abstract partial class TurnstileTestsBase<TTurnstile>
    where TTurnstile : ITurnstileState, ITurnstileControl
{
    private protected IAlarm Alarm { get; } = Mock.Of<IAlarm>();

    private protected ICoinReceiver CoinReceiver { get; } = Mock.Of<ICoinReceiver>();

    private protected abstract TTurnstile Target { get; }

    [Fact]
    public void CoinShouldRefundIfUnlocked()
    {
        this.Target.Unlock();

        this.Target.Coin();

        Mock.Get(this.CoinReceiver)
            .Verify(receiver => receiver.RefundCoin());
    }

    [Fact]
    public void CoinShouldUnlockIfLocked()
    {
        this.Target.Lock();

        this.Target.Coin();

        this.Target.IsUnlocked.Should().BeTrue();
    }

    [Fact]
    public void ItShouldDefaultToLocked()
    {
        this.Target.IsLocked.Should().BeTrue();
    }

    [Fact]
    public void LockShouldLock()
    {
        this.Target.Lock();

        this.Target.IsLocked.Should().BeTrue();
    }

    [Fact]
    public void PassShouldAlarmIfLocked()
    {
        this.Target.Lock();

        this.Target.Pass();

        Mock.Get(this.Alarm)
            .Verify(alarm => alarm.SoundAlarm());
    }

    [Fact]
    public void PassShouldLockIfUnlocked()
    {
        this.Target.Unlock();

        this.Target.Pass();

        this.Target.IsLocked.Should().BeTrue();
    }

    [Fact]
    public void UnlockShouldUnlock()
    {
        this.Target.Unlock();

        this.Target.IsUnlocked.Should().BeTrue();
    }

    public enum TurnstileAction
    {
        Coin,
        Pass,
    }
}