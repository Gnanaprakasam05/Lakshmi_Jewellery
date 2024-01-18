using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using LJ.Views;
using LJ.Services;

namespace LJ
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            FormHandler.RemoveBorders();
            builder
                .UseMauiApp<App>()
                  .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<HttpServices>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<MyRelationPage>();
          
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
