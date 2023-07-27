namespace WorkedUnitTests;

using System.Diagnostics.CodeAnalysis;

using Abstractions;

using FluentAssertions;

using Moq;

public abstract partial class TurnstileTestsBase<TTurnstile>
{
    [SuppressMessage("Major Code Smell", "S2743:Static fields should not be used in generic types")]
    public static TheoryData<State, TurnstileAction, State, Action<IAlarm>?, Action<ICoinReceiver>?> TheoryData { get; } =

    new()
        {
            { State.Locked, TurnstileAction.Coin, State.Unlocked, null, null },
            { State.Locked, TurnstileAction.Pass, State.Locked, VerifyAlarm, null },
            { State.Unlocked, TurnstileAction.Coin, State.Unlocked, null, VerifyRefund },
            { State.Unlocked, TurnstileAction.Pass, State.Locked, null, null },
        };

    [Theory]
    [MemberData(nameof(TheoryData))]
    public void GivenWhenThen(
        State initialState,
        TurnstileAction turnstileAction,
        State finalState,
        Action<IAlarm>? alarmAction,
        Action<ICoinReceiver>? receiverAction)
    {
        this.SetState(initialState);
        this.PerformAction(turnstileAction);
        this.VerifyFinalState(finalState);

        alarmAction?.Invoke(this.Alarm);
        receiverAction?.Invoke(this.CoinReceiver);
    }

    private void PerformAction(TurnstileAction turnstileAction)
    {
        switch (turnstileAction)
        {
            case TurnstileAction.Coin:
                this.Target.Coin();
                break;
            case TurnstileAction.Pass:
                this.Target.Pass();
                break;
        }
    }

    private void SetState(State state)
    {
        switch (state)
        {
            case State.Locked:
                this.Target.Lock();
                break;
            case State.Unlocked:
                this.Target.Unlock();
                break;
        }
    }

    private static void VerifyAlarm(IAlarm alarm)
    {
        Mock.Get(alarm).Verify(a => a.SoundAlarm());
    }

    private void VerifyFinalState(State state)
    {
        if (state == State.Locked)
        {
            this.Target.IsLocked.Should().BeTrue();
        }
        else
        {
            this.Target.IsUnlocked.Should().BeTrue();
        }
    }

    private static void VerifyRefund(ICoinReceiver coinReceiver)
    {
        Mock.Get(coinReceiver).Verify(receiver => receiver.RefundCoin());
    }
}