namespace CookingCoolR5.Helpers.Email
{
    public class EmailConfigModel
    {
        public string FromName { get; set; } = string.Empty;
        public string FromAddress { get; set; } = string.Empty;
        public string ConnectHost { get; set; } = string.Empty;
        public int ConnectPort { get; set; } = 0;
        public bool ConnectUseSsl { get; set; } = false;
        public string AuthUsername { get; set; } = string.Empty;
        public string AuthPassword { get; set; } = string.Empty;
    }
}
