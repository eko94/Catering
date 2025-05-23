using Catering.WebAPI;

namespace Catering
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                    // Add the following line:
                    webBuilder.UseSentry(o =>
                    {
                        o.Dsn = "https://d889dadb450bc7aed9148094eea0de3f@o4509272773885952.ingest.us.sentry.io/4509272783781888";
                        // When configuring for the first time, to see what the SDK is doing:
                        o.Debug = true;
                    });
                });
    }
}