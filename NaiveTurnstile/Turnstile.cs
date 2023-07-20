namespace NaiveTurnstile;

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
        if (TurnstileState == State.Unlocked)
        {
            this.CoinReceiver.RefundCoin();
        }

        (this as ITurnstileControl).Unlock();
    }

    public void Pass()
    {
        if (TurnstileState == State.Locked)
        {
            this.Alarm.SoundAlarm();
        }

        (this as ITurnstileControl).Lock();
    }

    bool ITurnstileState.IsLocked => TurnstileState == State.Locked;
    bool ITurnstileState.IsUnlocked => TurnstileState == State.Unlocked;
    private IAlarm Alarm { get; }
    private ICoinReceiver CoinReceiver { get; }
    private static State TurnstileState { get; set; } = State.Locked;
}