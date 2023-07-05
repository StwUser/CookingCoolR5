using System.IO;
using System;
using System.Threading.Tasks;

namespace CookingCoolR5.Helpers.LogWriter
{
    public static class LogWriter
    {
        public static async Task<bool> WrireAsync(string path, Exception ex)
        {
            try
            {
                using StreamWriter file = new(path, append: true);
                await file.WriteLineAsync($"Time: {DateTime.Now}{Environment.NewLine}Message: {ex.Message}{Environment.NewLine}Source: {ex.Source}{Environment.NewLine}InnerExeception {ex.InnerException}{Environment.NewLine}BaseException {ex.GetBaseException()}");
                await file.FlushAsync();
                return true;
            }
            catch 
            { 
                return false;
            }
            
        }
    }
}
