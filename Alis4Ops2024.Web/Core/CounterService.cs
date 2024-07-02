using Blazored.SessionStorage;
using System.Threading.Tasks;

public interface ICounterService
{
    Task<int> GetCounterAsync();
    Task IncrementCounterAsync(int value);
}

public class CounterService : ICounterService
{
    private readonly ISessionStorageService _sessionStorage;

    public CounterService(ISessionStorageService sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }

    public async Task<int> GetCounterAsync()
    {
        var storedValue = await _sessionStorage.GetItemAsync<string>("counter");
        if (string.IsNullOrEmpty(storedValue))
        {
            return 0; // Default value when counter is not set
        }

        if (int.TryParse(storedValue, out int result))
        {
            return result; // Successfully parsed value
        }
        else
        {
            // Handle parsing failure (optional)
            // Example: Log or notify about invalid session storage value
            return 0; // Return default value if parsing fails
        }
    }

    public async Task IncrementCounterAsync(int value)
    {
        var counter = await GetCounterAsync();
        counter += value;
        await _sessionStorage.SetItemAsync("counter", counter.ToString());
    }
}
