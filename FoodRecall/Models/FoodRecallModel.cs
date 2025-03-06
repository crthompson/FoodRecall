using System.Text.Json;
using System.Text.Json.Serialization;
using FoodRecall.Service;

namespace FoodRecall.Models;

public class FoodRecallModel
{
    public FoodRecallModel()
    {
        Results = [];
    }

    public FoodRecallModel(FoodRecallResults results)
    {
        Results = [];
        foreach (var result in results.Results)
        {
            Results.Add(new Result
            {
                Classification = result.Classification,
                Country = result.Country,
                ClassificationDate = result.ClassificationDate,
                ProductDescription = result.ProductDescription,
                ReasonForRecall = result.ReasonForRecall
            });
        }
    }

    public List<Result> Results { get; set; }
}

public class Result
{
    public string? Classification { get; set; }
    public string? Country { get; set; }
    public string? ClassificationDate { get; set; }
    public string? ProductDescription { get; set; }
    public string? ReasonForRecall { get; set; }
}