namespace TurnstileStateApproach;

using Abstractions;

internal class LockedTurnstile : ITurnstileState
{
    private readonly IAlarm alarm;

    public LockedTurnstile(IAlarm alarm)
    {
        this.alarm = alarm;
    }

    public void Coin()
    {
        // nothing to do
    }

    public void Pass()
    {
        this.alarm.SoundAlarm();
    }

    public bool IsLocked => true;
    public bool IsUnlocked => false;
}