using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem.Infrastructure.Documents.Models;

public class UsedModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("partitionKey")]
    public string PartitionKey { get; set; }
    [JsonProperty("collection")]
    public IEnumerable<Collection1> collection { get; set; }

}

public class Collection1
{
    public Collection1()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
    public string someValue { get; set; }
    public string someValueTwo { get; set; }
    public string someValueThree { get; set; }
    public string someValueFour { get; set; }
    public string someValueFive { get; set; }
    public IEnumerable<Collection1> collectionInIt { get; set; }
}