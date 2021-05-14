using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TypographyShopBusinessLogic.ViewModels;

namespace TypographyShopStoreApp
{
    public class Program
    {
        public static string Password { get; set; }
        public static bool IsLogged { get; set; } = false;
        public static ClientViewModel Client { get; set; }
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();
        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
    }
}
