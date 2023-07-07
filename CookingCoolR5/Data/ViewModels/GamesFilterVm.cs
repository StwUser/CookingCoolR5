namespace CookingCoolR5.Data.ViewModels
{
    public class GamesFilterVm
    {
        public int? Discount { get; set; } 
        public double? PriceFrom { get; set; } 
        public double? PriceTo { get; set; } 
        public bool ShowGamesFromGog { get; set; } 
        public bool ShowGamesFromSteam { get; set; } 
        public bool ShowGamesFromEpicGames { get; set; }  
        public bool GetDuplicates { get; set; }
        public string SearchWord { get; set; }
    }
}
