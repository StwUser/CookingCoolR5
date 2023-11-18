using Newtonsoft.Json;
using RestSharp;
using SteamApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CookingCoolR5.Helpers.SteamApi
{
    public class SteamHelper
    {
        private List<App> Apps { get; set; } = new List<App>();
        public SteamHelper()
        {
            FillCollection();
        }

        private void FillCollection()
        {
            try
            {
                var client = new RestClient("https://api.steampowered.com/ISteamApps/GetAppList/v2/");
                var request = new RestRequest();
                var response = client.Execute(request);
                var root = JsonConvert.DeserializeObject<SteamGameList>(response.Content);
                Apps = root.Applist.Apps;

                var test = Apps.SkipWhile(x => x.AppId != 2468750).ToArray();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<SteamGameInfoVm> GetGameByNameAsync(string gameName)
        {
            try
            {
                var steamGameId = Apps.Any(g => g.Name.ToLower() == gameName.ToLower()) ? 
                    Apps.FirstOrDefault(g => g.Name.ToLower() == gameName.ToLower())?.AppId : 
                    Apps.FirstOrDefault(g => g.Name.Contains(gameName, StringComparison.InvariantCultureIgnoreCase))?.AppId;

                if (steamGameId == null)
                {
                    return await Task.FromResult(new SteamGameInfoVm());
                }

                var client = new RestClient("https://store.steampowered.com/api/appdetails?appids=" + steamGameId);
                var request = new RestRequest();
                var response = await client.ExecuteAsync(request);
                var charIndex = response.Content.IndexOf(":") + 1;
                var lenght = response.Content.Length - charIndex - 1;
                var body = response.Content.Substring(charIndex, lenght);
                var root = JsonConvert.DeserializeObject<SteamGameInfo>(body);

                return Convert(root);
            }
            catch (Exception ex) 
            { 
            
            }
            return await Task.FromResult(new SteamGameInfoVm());
        }

        public async Task<SteamGameInfo> GetGameByIdAsync(int gameId)
        {
            try
            {
                var client = new RestClient("https://store.steampowered.com/api/appdetails?appids=" + gameId);
                var request = new RestRequest();
                var response = await client.ExecuteAsync(request);
                var charIndex = response.Content.IndexOf(":") + 1;
                var lenght = response.Content.Length - charIndex - 1;
                var body = response.Content.Substring(charIndex, lenght);
                var root = JsonConvert.DeserializeObject<SteamGameInfo>(body);

                return root;
            }
            catch (Exception ex)
            {

            }
            return await Task.FromResult(new SteamGameInfo());
        }

        public async Task<bool> CheckAllGamesInSteamAsync()
        {
            Thread.Sleep(100);
            var counter = 0;
             foreach(var g in Apps)
            {
                var game = await GetGameByIdAsync(g.AppId ?? 0);
                Debug.WriteLine($"Counter: {counter} Success: {game.Success} GamesId: {game?.Data?.SteamAppid}, name: {game?.Data?.Name}, isFree: {game?.Data?.IsFree}");
            }
            ++counter;
            return true;
        }

        private SteamGameInfoVm Convert(SteamGameInfo i)
        {
            var v = new SteamGameInfoVm
            { 
                Success = i.Success,
                Data = new DataVm 
                                { 
                                    AboutTheGame = i.Data.AboutTheGame, 
                                    Background = i.Data.Background, 
                                    BackgroundRaw = i.Data.BackgroundRaw,
                                    CapsuleImage = i.Data.CapsuleImage,
                                    CapsuleImagev5 = i.Data.CapsuleImagev5,
                                    Categories = i.Data?.Categories != null ? i.Data.Categories.Select(c => new CategoryVm { Id = c.Id, Description = c.Description }).ToList() : null,
                                    ContentDescriptors = i.Data?.ContentDescriptors != null ? new ContentDescriptorsVm { Ids = i.Data.ContentDescriptors.Ids, Notes = i.Data.ContentDescriptors.Notes } : null,
                                    DetailedDescription = i.Data.DetailedDescription,
                                    Developers = i.Data.Developers,
                                    FullGame = i.Data?.FullGame != null ? new FullgameVm { Appid = i.Data.FullGame.Appid, Name = i.Data.FullGame.Name } : null,
                                    Name = i.Data.Name,
                                    HeaderImage = i.Data.HeaderImage,
                                    IsFree = i.Data.IsFree,
                                    LegalNotice = i.Data.LegalNotice,
                                    Website = i.Data.Website,
                                    Genres = i.Data?.Genres != null ? i.Data.Genres.Select(g => new GenreVm { Id = g.Id, Description = g.Description }).ToList() : null,
                                    Platforms = i.Data?.Platforms != null ? new PlatformsVm { Windows = i.Data.Platforms.Windows, Linux = i.Data.Platforms.Linux, Mac = i.Data.Platforms.Mac } : null,
                                    LinuxRequirements = i.Data?.LinuxRequirements.Length > 0 ? new LinuxRequirementsVm { Minimum = i.Data.LinuxRequirements.FirstOrDefault()?.Minimum, Recommended = i.Data.LinuxRequirements?.FirstOrDefault().Recommended } : null,
                                    MacRequirements = i.Data?.MacRequirements.Length > 0 ? new MacRequirementsVm { Minimum = i.Data.MacRequirements.FirstOrDefault()?.Minimum, Recommended = i.Data.MacRequirements?.FirstOrDefault()?.Recommended } : null,
                                    PcRequirements = i.Data?.PcRequirements.Length > 0 ? new PcRequirementsVm { Minimum = i.Data.PcRequirements.FirstOrDefault()?.Minimum, Recommended = i.Data.PcRequirements?.FirstOrDefault()?.Recommended } : null,
                                    PackageGroups = i.Data?.PackageGroups != null ? i.Data.PackageGroups.Select(p => new PackageGroupVm 
                                                                                                       { 
                                                                                                            Description = p.Description, 
                                                                                                            DisplayType = p.DisplayType,
                                                                                                            IsRecurringSubscription = p.IsRecurringSubscription,
                                                                                                            Name = p.Name,
                                                                                                            SaveText = p.SaveText,
                                                                                                            SelectionText = p.SelectionText,
                                                                                                            Subs = p?.Subs != null ? p.Subs.Select(s => new SubVm 
                                                                                                                                               { 
                                                                                                                                                  CanGetFreeLicense = s.CanGetFreeLicense,
                                                                                                                                                  IsFreeLicense = s.IsFreeLicense,
                                                                                                                                                  OptionDescription = s.OptionDescription,
                                                                                                                                                  OptionText = s.OptionText,
                                                                                                                                                  PackageId = s.PackageId,
                                                                                                                                                  PercentSavings = s.PercentSavings,
                                                                                                                                                  PercentSavingsText = s.PercentSavingsText,
                                                                                                                                                  PriceInCentsWithDiscount = s.PriceInCentsWithDiscount
                                                                                                                                                }).ToList() : null,
                                                                                                            Title = p.Title
                                                                                                       }).ToList() : null,
                                    Packages = i.Data.Packages,
                                    PriceOverview = i.Data?.PriceOverview != null ? new PriceOverviewVm { Currency = i.Data.PriceOverview.Currency } : null,
                                    Publishers = i.Data.Publishers ?? null,
                                    ReleaseDate = i.Data?.ReleaseDate != null ? new ReleaseDateVm { Date = i.Data.ReleaseDate.Date, ComingSoon = i.Data.ReleaseDate.ComingSoon } : null,
                                    RequiredAge = i.Data?.RequiredAge ?? 0,
                                    Screenshots = i.Data.Screenshots?.Select(x => new ScreenshotVm { Id = x.Id, PathFull = x.PathFull, PathThumbnail = x.PathThumbnail }).ToList(),
                                    ShortDescription = i.Data?.ShortDescription,
                                    SteamAppid = i.Data?.SteamAppid ?? 0,
                                    Type = i.Data.Type,
                                    SupportedLanguages = i.Data?.SupportedLanguages ?? null,
                                    SupportInfo = i.Data?.SupportInfo != null ? new SupportInfoVm { Url = i.Data.SupportInfo.Url, Email = i.Data.SupportInfo.Email } : null
                }
            };

            return v;
        }
    }
}
