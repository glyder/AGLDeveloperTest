
using Newtonsoft.Json;

namespace AGL.DeveloperTest.Models
{
    /// <summary>
    /// Is a Pet and Person Name the same? 
    /// Probably not and we shouldn't build a base heirarchy because it shares Name property
    /// 
    /// I'll leave this as a simple class. 
    /// JSON Serialization would work without property attributes as they match json attributes.
    /// </summary>
    public class Pets
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
