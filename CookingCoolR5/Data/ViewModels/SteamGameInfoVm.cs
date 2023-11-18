using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SteamApi
{
    public class SteamGameInfoVm
    {
        public bool? Success { get; set; }
        public DataVm Data { get; set; }
    }

    public class DataVm
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int? SteamAppid { get; set; }
        public int? RequiredAge { get; set; }
        public bool? IsFree { get; set; }
        public string DetailedDescription { get; set; }
        public string AboutTheGame { get; set; }
        public string ShortDescription { get; set; }
        public FullgameVm FullGame { get; set; }
        public string SupportedLanguages { get; set; }
        public string HeaderImage { get; set; }
        public string CapsuleImage { get; set; }
        public string CapsuleImagev5 { get; set; }
        public string Website { get; set; }
        public PcRequirementsVm PcRequirements { get; set; }
        public MacRequirementsVm MacRequirements { get; set; }
        public LinuxRequirementsVm LinuxRequirements { get; set; }
        public string LegalNotice { get; set; }
        public List<string> Developers { get; set; }
        public List<string> Publishers { get; set; }
        public PriceOverviewVm PriceOverview { get; set; }
        public List<int?> Packages { get; set; }
        public List<PackageGroupVm> PackageGroups { get; set; }
        public PlatformsVm Platforms { get; set; }
        public List<CategoryVm> Categories { get; set; }
        public List<GenreVm> Genres { get; set; }
        public List<ScreenshotVm> Screenshots { get; set; }
        public ReleaseDateVm ReleaseDate { get; set; }
        public SupportInfoVm SupportInfo { get; set; }
        public string Background { get; set; }
        public string BackgroundRaw { get; set; }
        public ContentDescriptorsVm ContentDescriptors { get; set; }
    }

    public class FullgameVm
    {
        public string Appid {  get; set; }
        public string Name { get; set; }
    }

    public class PcRequirementsVm
    {
        public string Minimum { get; set; }
        public string Recommended { get; set; }
    }

    public class MacRequirementsVm
    {
        public string Minimum { get; set; }
        public string Recommended { get; set; }
    }
    public class LinuxRequirementsVm
    {
        public string Minimum { get; set; }
        public string Recommended { get; set; }
    }

public class PriceOverviewVm
    {
        public string Currency { get; set; }
        public int? Initial { get; set; }
        public int? Final { get; set; }
        public int? DiscountPercent { get; set; }
        public string InitialFormatted { get; set; }
        public string FinalFormatted { get; set; }
    }

    public class PackageGroupVm
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SelectionText { get; set; }
        public string SaveText { get; set; }
        public int? DisplayType { get; set; }
        public string IsRecurringSubscription { get; set; }
        public List<SubVm> Subs { get; set; }
    }

    public class SubVm
    {
        public int? PackageId { get; set; }
        public string PercentSavingsText { get; set; }
        public int? PercentSavings { get; set; }
        public string OptionText { get; set; }
        public string OptionDescription { get; set; }
        public string CanGetFreeLicense { get; set; }
        public bool? IsFreeLicense { get; set; }
        public int? PriceInCentsWithDiscount { get; set; }
    }

    public class PlatformsVm
    {
        public bool? Windows { get; set; }
        public bool? Mac { get; set; }
        public bool? Linux { get; set; }
    }

    public class CategoryVm
    {
        public int? Id { get; set; }
        public string Description { get; set; }
    }

    public class GenreVm
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }

    public class ScreenshotVm
    {
        public int? Id { get; set; }
        public string PathThumbnail { get; set; }
        public string PathFull { get; set; }
    }

    public class ReleaseDateVm
    {
        public bool? ComingSoon { get; set; }
        public string Date { get; set; }
    }

    public class SupportInfoVm
    {
        public string Url { get; set; }
        public string Email { get; set; }
    }

    public class ContentDescriptorsVm
    {
        public List<int?> Ids { get; set; }
        public string Notes { get; set; }
    }
}
