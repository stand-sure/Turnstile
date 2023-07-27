namespace WorkedUnitTests.LiveSession;

using global::LiveSession;

public class TurnstileTests
{
    private Turnstile Target { get; }

    public TurnstileTests()
    {
        this.Target = MakeTurnstile();
    }
    
    private static Turnstile MakeTurnstile()
    {
        return new Turnstile();
    }
}