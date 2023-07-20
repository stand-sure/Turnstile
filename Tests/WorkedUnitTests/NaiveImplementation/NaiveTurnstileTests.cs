namespace WorkedUnitTests.NaiveImplementation;

using JetBrains.Annotations;

using NaiveTurnstile;

using Xunit.Categories;

[UsedImplicitly]
[UnitTest(nameof(NaiveImplementation))]
public class NaiveTurnstileTests : TurnstileTestsBase<Turnstile>
{
    public NaiveTurnstileTests()
    {
        this.Target = this.MakeTurnstile();
    }

    private protected override Turnstile Target { get; }

    private Turnstile MakeTurnstile()
    {
        return new Turnstile(this.CoinReceiver, this.Alarm);
    }
}