using Microsoft.AspNetCore.Components.WebView.Maui;
using MAUIGameLauncher.Data;
using Radzen;
using MAUIGameLauncher.Model;
using MAUIGameLauncher.Data;
namespace MAUIGameLauncher;

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
			});

		builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
        builder.Services.AddScoped<DialogService>();
        builder.Services.AddScoped<NotificationService>();
        builder.Services.AddScoped<TooltipService>();
        builder.Services.AddScoped<ContextMenuService>();
		builder.Services.AddScoped<Model.Drive>();
        builder.Services.AddScoped<Model.Game>();
        builder.Services.AddScoped<Model.Launcher>();
		builder.Services.AddScoped<Data.Games>();
		builder.Services.AddScoped<Data.Launchers>();

        return builder.Build();
	}
}
