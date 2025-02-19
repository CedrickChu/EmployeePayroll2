public class ModalService
{
    public event Action? OnShow;
    public event Action? OnClose;

    public void Show()
    {
        OnShow?.Invoke();
    }

    public void Close()
    {
        OnClose?.Invoke();
    }
}
