using Newtonsoft.Json;

namespace PotionInventory;

public class Potion
{
    [JsonProperty("name")]
    public string PotionName { get; set; }
    
    [JsonProperty("type")]
    public string PotionType { get; set; }
    
    [JsonProperty("action")]
    public string PotionAction { get; set; }
    
    [JsonProperty("recovery")]
    public int? PotionRecovery { get; set; }
    
    [JsonProperty("damage")]
    public int? PotionDamage { get; set; }
}