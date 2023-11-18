using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SteamApi
{
    public class SteamGameInfo
    {
        [JsonProperty("success")]
        [JsonPropertyName("success")]
        public bool? Success;

        [JsonProperty("data")]
        [JsonPropertyName("data")]
        public Data Data;
    }

    public class Category
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int? Id;

        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string Description;
    }

    public class ContentDescriptors
    {
        [JsonProperty("ids")]
        [JsonPropertyName("ids")]
        public List<int?> Ids;

        [JsonProperty("notes")]
        [JsonPropertyName("notes")]
        public string Notes;
    }

    public class Data
    {
        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type;

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name;

        [JsonProperty("steam_appid")]
        [JsonPropertyName("steam_appid")]
        public int? SteamAppid;

        [JsonProperty("required_age")]
        [JsonPropertyName("required_age")]
        public int? RequiredAge;

        [JsonProperty("is_free")]
        [JsonPropertyName("is_free")]
        public bool? IsFree;

        [JsonProperty("detailed_description")]
        [JsonPropertyName("detailed_description")]
        public string DetailedDescription;

        [JsonProperty("about_the_game")]
        [JsonPropertyName("about_the_game")]
        public string AboutTheGame;

        [JsonProperty("short_description")]
        [JsonPropertyName("short_description")]
        public string ShortDescription;

        [JsonProperty("fullgame")]
        [JsonPropertyName("fullgame")]
        public FullGame FullGame;

        [JsonProperty("supported_languages")]
        [JsonPropertyName("supported_languages")]
        public string SupportedLanguages;

        [JsonProperty("header_image")]
        [JsonPropertyName("header_image")]
        public string HeaderImage;

        [JsonProperty("capsule_image")]
        [JsonPropertyName("capsule_image")]
        public string CapsuleImage;

        [JsonProperty("capsule_imagev5")]
        [JsonPropertyName("capsule_imagev5")]
        public string CapsuleImagev5;

        [JsonProperty("website")]
        [JsonPropertyName("website")]
        public string Website;

        [JsonProperty("pc_requirements")]
        [JsonPropertyName("pc_requirements")]
        [Newtonsoft.Json.JsonConverter(typeof(ObjectToArrayConverter<PcRequirements>))]
        public PcRequirements[] PcRequirements;

        [JsonProperty("mac_requirements")]
        [JsonPropertyName("mac_requirements")]
        [Newtonsoft.Json.JsonConverter(typeof(ObjectToArrayConverter<MacRequirements>))]
        public MacRequirements[] MacRequirements;

        [JsonProperty("linux_requirements")]
        [JsonPropertyName("linux_requirements")]
        [Newtonsoft.Json.JsonConverter(typeof(ObjectToArrayConverter<LinuxRequirements>))]
        public LinuxRequirements[] LinuxRequirements;

        [JsonProperty("legal_notice")]
        [JsonPropertyName("legal_notice")]
        public string LegalNotice;

        [JsonProperty("developers")]
        [JsonPropertyName("developers")]
        public List<string> Developers;

        [JsonProperty("publishers")]
        [JsonPropertyName("publishers")]
        public List<string> Publishers;

        [JsonProperty("price_overview")]
        [JsonPropertyName("price_overview")]
        public PriceOverview PriceOverview;

        [JsonProperty("packages")]
        [JsonPropertyName("packages")]
        public List<int?> Packages;

        [JsonProperty("package_groups")]
        [JsonPropertyName("package_groups")]
        public List<PackageGroup> PackageGroups;

        [JsonProperty("platforms")]
        [JsonPropertyName("platforms")]
        public Platforms Platforms;

        [JsonProperty("categories")]
        [JsonPropertyName("categories")]
        public List<Category> Categories;

        [JsonProperty("genres")]
        [JsonPropertyName("genres")]
        public List<Genre> Genres;

        [JsonProperty("screenshots")]
        [JsonPropertyName("screenshots")]
        public List<Screenshot> Screenshots;

        [JsonProperty("release_date")]
        [JsonPropertyName("release_date")]
        public ReleaseDate ReleaseDate;

        [JsonProperty("support_info")]
        [JsonPropertyName("support_info")]
        public SupportInfo SupportInfo;

        [JsonProperty("background")]
        [JsonPropertyName("background")]
        public string Background;

        [JsonProperty("background_raw")]
        [JsonPropertyName("background_raw")]
        public string BackgroundRaw;

        [JsonProperty("content_descriptors")]
        [JsonPropertyName("content_descriptors")]
        public ContentDescriptors ContentDescriptors;
    }

    public class FullGame
    {
        [JsonProperty("appid")]
        [JsonPropertyName("appid")]
        public string Appid;

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name;
    }

    public class Genre
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public string Id;

        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string Description;
    }

    [JsonObject]
    public class PcRequirements
    {
        [JsonProperty("minimum")]
        [JsonPropertyName("minimum")]
        public string Minimum;

        [JsonProperty("recommended")]
        [JsonPropertyName("recommended")]
        public string Recommended;
    }

    [JsonObject]
    public class MacRequirements
    {
        [JsonProperty("minimum")]
        [JsonPropertyName("minimum")]
        public string Minimum;

        [JsonProperty("recommended")]
        [JsonPropertyName("recommended")]
        public string Recommended;
    }

    [JsonObject]
    public class LinuxRequirements
    {
        [JsonProperty("minimum")]
        [JsonPropertyName("minimum")]
        public string Minimum;

        [JsonProperty("recommended")]
        [JsonPropertyName("recommended")]
        public string Recommended;
    }

    public class PackageGroup
    {
        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name;

        [JsonProperty("title")]
        [JsonPropertyName("title")]
        public string Title;

        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string Description;

        [JsonProperty("selection_text")]
        [JsonPropertyName("selection_text")]
        public string SelectionText;

        [JsonProperty("save_text")]
        [JsonPropertyName("save_text")]
        public string SaveText;

        [JsonProperty("display_type")]
        [JsonPropertyName("display_type")]
        public int? DisplayType;

        [JsonProperty("is_recurring_subscription")]
        [JsonPropertyName("is_recurring_subscription")]
        public string IsRecurringSubscription;

        [JsonProperty("subs")]
        [JsonPropertyName("subs")]
        public List<Sub> Subs;
    }

    public class Platforms
    {
        [JsonProperty("windows")]
        [JsonPropertyName("windows")]
        public bool? Windows;

        [JsonProperty("mac")]
        [JsonPropertyName("mac")]
        public bool? Mac;

        [JsonProperty("linux")]
        [JsonPropertyName("linux")]
        public bool? Linux;
    }

    public class PriceOverview
    {
        [JsonProperty("currency")]
        [JsonPropertyName("currency")]
        public string Currency;

        [JsonProperty("initial")]
        [JsonPropertyName("initial")]
        public int? Initial;

        [JsonProperty("final")]
        [JsonPropertyName("final")]
        public int? Final;

        [JsonProperty("discount_percent")]
        [JsonPropertyName("discount_percent")]
        public int? DiscountPercent;

        [JsonProperty("initial_formatted")]
        [JsonPropertyName("initial_formatted")]
        public string InitialFormatted;

        [JsonProperty("final_formatted")]
        [JsonPropertyName("final_formatted")]
        public string FinalFormatted;
    }

    public class ReleaseDate
    {
        [JsonProperty("coming_soon")]
        [JsonPropertyName("coming_soon")]
        public bool? ComingSoon;

        [JsonProperty("date")]
        [JsonPropertyName("date")]
        public string Date;
    }

    public class Screenshot
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int? Id;

        [JsonProperty("path_thumbnail")]
        [JsonPropertyName("path_thumbnail")]
        public string PathThumbnail;

        [JsonProperty("path_full")]
        [JsonPropertyName("path_full")]
        public string PathFull;
    }

    public class Sub
    {
        [JsonProperty("packageid")]
        [JsonPropertyName("packageid")]
        public int? PackageId;

        [JsonProperty("percent_savings_text")]
        [JsonPropertyName("percent_savings_text")]
        public string PercentSavingsText;

        [JsonProperty("percent_savings")]
        [JsonPropertyName("percent_savings")]
        public int? PercentSavings;

        [JsonProperty("option_text")]
        [JsonPropertyName("option_text")]
        public string OptionText;

        [JsonProperty("option_description")]
        [JsonPropertyName("option_description")]
        public string OptionDescription;

        [JsonProperty("can_get_free_license")]
        [JsonPropertyName("can_get_free_license")]
        public string CanGetFreeLicense;

        [JsonProperty("is_free_license")]
        [JsonPropertyName("is_free_license")]
        public bool? IsFreeLicense;

        [JsonProperty("price_in_cents_with_discount")]
        [JsonPropertyName("price_in_cents_with_discount")]
        public int? PriceInCentsWithDiscount;
    }

    public class SupportInfo
    {
        [JsonProperty("url")]
        [JsonPropertyName("url")]
        public string Url;

        [JsonProperty("email")]
        [JsonPropertyName("email")]
        public string Email;
    }

    public class ObjectToArrayConverter<T> : CustomCreationConverter<T[]>
    {
        public override T[] Create(Type objectType)
        {
            return new T[0];
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                return serializer.Deserialize(reader, objectType);
            }
            else
            {
                return new T[] { serializer.Deserialize<T>(reader) };
            }
        }
    }
}
