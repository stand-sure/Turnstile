namespace WorkedUnitTests.TurnstileStateApproach;

using global::TurnstileStateApproach;

using JetBrains.Annotations;

using Xunit.Categories;

[UsedImplicitly]
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