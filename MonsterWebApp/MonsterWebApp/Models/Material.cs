using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace MonsterWebApp.Models
{
    public partial class Material
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rarity")]
        public long Rarity { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("locations")]
        public object Locations { get; set; }
    }

    public partial class Material
    {
        public static Material[] FromJson(string json) => JsonConvert.DeserializeObject<Material[]>(json, ConverterM.Settings);
    }

    public static class SerializeM
    {
        public static string ToJson(this Material[] self) => JsonConvert.SerializeObject(self, ConverterM.Settings);
    }

    public class ConverterM
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}