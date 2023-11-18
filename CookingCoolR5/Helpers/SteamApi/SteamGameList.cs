using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SteamApi
{
    public class SteamGameList
    {
        [JsonProperty("applist")]
        [JsonPropertyName("applist")]
        public Applist Applist;
    }

    public class Applist
    {
        [JsonProperty("apps")]
        [JsonPropertyName("apps")]
        public List<App> Apps;
    }

    public class App
    {
        [JsonProperty("appid")]
        [JsonPropertyName("appid")]
        public int? AppId;
        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name;
    }
}
