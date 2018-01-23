using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace MonsterWebApp.Models
{
    public partial class WeaponsResult

    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("parent")]
        public WeaponsResult Parent { get; set; }

        [JsonProperty("hasChild")]
        public bool HasChild { get; set; }

        [JsonProperty("weaponClass")]
        public string WeaponClass { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("rawDamage")]
        public long RawDamage { get; set; }

        [JsonProperty("elementType")]
        public object ElementType { get; set; }

        [JsonProperty("elementDamage")]
        public long ElementDamage { get; set; }

        [JsonProperty("sharpness")]
        public string Sharpness { get; set; }

        [JsonProperty("rarity")]
        public long Rarity { get; set; }

        [JsonProperty("affinity")]
        public long Affinity { get; set; }

        [JsonProperty("slots")]
        public long Slots { get; set; }

        [JsonProperty("defense")]
        public long Defense { get; set; }
    }

    public partial class WeaponsResult
    {
        public static WeaponsResult[] FromJson(string json) => JsonConvert.DeserializeObject<WeaponsResult[]>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this WeaponsResult[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
