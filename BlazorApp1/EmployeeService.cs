using System.Net.Http.Json;
using BlazorApp1.Models;

public class EmployeeService
{
    private readonly HttpClient _httpClient;

    public EmployeeService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("MyApi");
    }

    public async Task<List<EmployeeList>> SearchEmployees(string name)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<EmployeeList>>($"api/my/SearchEmployee/{name}");
            return response ?? new List<EmployeeList>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching employees: {ex.Message}");
            return new List<EmployeeList>();
        }
    }
}
