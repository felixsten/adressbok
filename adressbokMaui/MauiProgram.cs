using adressbokMaui.Services;
using adressbokMaui.ViewModels;
using adressbokMaui.Views;
using Microsoft.Extensions.Logging;



namespace adressbokMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<CustomerService>();
            builder.Services.AddSingleton<FileService>();
            builder.Services.AddSingleton<SearchPage>();
            builder.Services.AddSingleton<SearchViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
