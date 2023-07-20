namespace Abstractions;

public interface ICoinReceiver
{
    void ReceiveCoin();
    void RefundCoin();
}