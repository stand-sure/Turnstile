namespace TurnstileStateApproach;

using Abstractions;

public class Turnstile : ITurnstileState, ITurnstileControl
{
    public Turnstile(ICoinReceiver coinReceiver, IAlarm alarm)
    {
        this.LockedTurnstile = new LockedTurnstile(alarm);
        this.UnlockedTurnstile = new UnlockedTurnstile(coinReceiver);

        StateTurnstile = this.LockedTurnstile;
    }

    void ITurnstileControl.Lock()
    {
        StateTurnstile = this.LockedTurnstile;
    }

    void ITurnstileControl.Unlock()
    {
        StateTurnstile = this.UnlockedTurnstile;
    }

    public void Coin()
    {
        StateTurnstile.Coin();
        StateTurnstile = this.UnlockedTurnstile;
    }

    public void Pass()
    {
        StateTurnstile.Pass();
        StateTurnstile = this.LockedTurnstile;
    }

    bool ITurnstileState.IsLocked => StateTurnstile.IsLocked;

    bool ITurnstileState.IsUnlocked => StateTurnstile.IsUnlocked;
    private ITurnstileState LockedTurnstile { get; }

    private static ITurnstileState StateTurnstile { get; set; } = null!;
    private ITurnstileState UnlockedTurnstile { get; }
}