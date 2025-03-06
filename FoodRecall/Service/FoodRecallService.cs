using System.Text.Json;
using System.Threading.Tasks;
using FoodRecall.Models;

namespace FoodRecall.Service;

public class FoodRecallService
{
    private HttpClient httpClient;

    public FoodRecallService(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient();
    }
    public async Task<FoodRecallResults> GetResults(DateTime startDate, DateTime endDate, int limit)
    {
        var url = $"https://api.fda.gov/food/enforcement.json?search=report_date:[{startDate:yyyyMMdd}+TO+{endDate:yyyyMMdd}]&limit={limit}";
        
        var results = await httpClient.GetAsync(url);
        
        var content = await results.Content.ReadAsStringAsync();
        
        var obj = JsonSerializer.Deserialize<FoodRecallResults>(content);

        if(obj == null || content.ToLower().Contains("error"))
        {
            throw new Exception("No results found");
        }   
        return obj;
    }
}