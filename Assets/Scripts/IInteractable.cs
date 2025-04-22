public interface IInteractable
{
    //the code value decides what object interactable is supposed to be used with 0 = cauldron, 1 = candlesticks
    int code { get; }
    void Interact();
}