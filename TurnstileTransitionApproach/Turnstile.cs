namespace TurnstileTransitionApproach;

using Abstractions;

public class Turnstile : ITurnstileState, ITurnstileControl
{
    public Turnstile(ICoinReceiver coinReceiver, IAlarm alarm)
    {
        this.CoinReceiver = coinReceiver;
        this.Alarm = alarm;

        TurnstileState = State.Locked;
    }

    void ITurnstileControl.Lock()
    {
        TurnstileState = State.Locked;
    }

    void ITurnstileControl.Unlock()
    {
        TurnstileState = State.Unlocked;
    }

    public void Coin()
    {
        this.Transition(TurnstileAction.Coin);
    }

    public void Pass()
    {
        this.Transition(TurnstileAction.Push);
    }

    bool ITurnstileState.IsLocked => TurnstileState == State.Locked;

    bool ITurnstileState.IsUnlocked => TurnstileState == State.Unlocked;
    private IAlarm Alarm { get; }
    private ICoinReceiver CoinReceiver { get; }

    private static State TurnstileState { get; set; }

    private void Transition(TurnstileAction action)
    {
        Action transition = (action, TurnstileState) switch
        {
            (TurnstileAction.Push, State.Locked) => this.Alarm.SoundAlarm,
            (TurnstileAction.Push, _) => (this as ITurnstileControl).Lock,
            (TurnstileAction.Coin, State.Locked) => (this as ITurnstileControl).Unlock,
            (_, _) => this.CoinReceiver.RefundCoin,
        };

        transition();
    }
}