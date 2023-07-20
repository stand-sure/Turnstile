namespace TurnstileStateApproach;

using Abstractions;

internal class UnlockedTurnstile : ITurnstileState
{
    public UnlockedTurnstile(ICoinReceiver coinReceiver)
    {
        this.CoinReceiver = coinReceiver;
    }

    public void Pass()
    {
        // nothing to do
    }

    public bool IsLocked => false;
    public bool IsUnlocked => true;

    public void Coin()
    {
        this.CoinReceiver.RefundCoin();
    }

    private ICoinReceiver CoinReceiver { get; }
}