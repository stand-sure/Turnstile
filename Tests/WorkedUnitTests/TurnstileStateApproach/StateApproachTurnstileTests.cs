namespace WorkedUnitTests.TurnstileStateApproach;

using global::TurnstileStateApproach;

using Xunit.Categories;

[UnitTest(nameof(TurnstileStateApproach))]
public class StateApproachTurnstileTests : TurnstileTestsBase<Turnstile>
{
    public StateApproachTurnstileTests()
    {
        this.Target = this.MakeTurnstile();
    }

    private protected override Turnstile Target { get; }

    private Turnstile MakeTurnstile()
    {
        return new Turnstile(this.CoinReceiver, this.Alarm);
    }
}