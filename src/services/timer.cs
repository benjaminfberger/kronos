namespace kronos.services;

public class timer
{
    public DateTime end { get; private set; }
    private TimeSpan deltaTime;
    public event Action onHalt;

    public timer(TimeSpan time)
    {
        end = new();
        end = DateTime.UtcNow.Add(time);
        deltaTime = new();
    }

    /// <summary>
    /// Add time to timer
    /// </summary>
    /// <param name="time">TimeSpan to add</param>
    public void add(TimeSpan time) =>
        end.Add(time);

    /// <summary>
    /// Remove time from timer
    /// </summary>
    /// <param name="time">TimeSpan to remove</param>
    public void sub(TimeSpan time) =>
        end = (end.Subtract(time) > DateTime.UtcNow) 
            ? end.Subtract(time) 
            : DateTime.UtcNow;


    private async void tick()
    {
        if (DateTime.UtcNow.Subtract(end) < TimeSpan.Zero)
            onHalt?.Invoke();
        
        
        
    }

    private void calculateDeltaTime()
    {
        throw new NotImplementedException();
    }
}