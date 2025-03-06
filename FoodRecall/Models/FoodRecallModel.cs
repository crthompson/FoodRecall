using System.Text.Json;
using System.Text.Json.Serialization;

namespace FoodRecall.Models;

public class FoodRecallModel
{
    public FoodRecallModel()
    {
    }


    [JsonPropertyName("results")]
    public List<Result> Results { get; set; }
}

public class Result
{

    [JsonPropertyName("classification")]
    public string Classification { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }
    
    [JsonPropertyName("center_classification_date")]
    public string ClassificationDate { get; set; }
    
    [JsonPropertyName("product_description")]
    public string ProductDescription { get; set; }
    

    [JsonPropertyName("reason_for_recall")]
    public string ReasonForRecall { get; set; }
}