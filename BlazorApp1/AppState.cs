using System.Threading.Tasks;

public class AppState
{
    public event Func<Task>? OnEventTriggered;

    public async Task TriggerEvent()
    {
        if (OnEventTriggered is not null)
        {
            await OnEventTriggered.Invoke();
        }
        
    }
}
