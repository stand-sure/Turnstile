namespace WorkedUnitTests.TurnstileTransitionApproach;

using global::TurnstileTransitionApproach;

using Xunit.Categories;

[UnitTest(nameof(TransitionApproachTurnstileTests))]
public class TransitionApproachTurnstileTests : TurnstileTestsBase<Turnstile>
{
    public TransitionApproachTurnstileTests()
    {
        this.Target = this.MakeTurnstile();
    }

    private protected override Turnstile Target { get; }

    private Turnstile MakeTurnstile()
    {
        return new Turnstile(this.CoinReceiver, this.Alarm);
    }
}