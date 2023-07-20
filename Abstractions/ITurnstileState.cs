namespace Abstractions;

public interface ITurnstileState : ITurnstile
{
    bool IsLocked { get; }
    bool IsUnlocked { get; }
}