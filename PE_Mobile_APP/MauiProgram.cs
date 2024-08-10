using PE_Mobile_APP.Services;
using PE_Mobile_APP.Services.Interface;

namespace PE_Mobile_APP;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<AanmeldenViewModel>();

		builder.Services.AddSingleton<AanmeldenPage>();
        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<IFavorietenRepository, FavorietenRepository>();
        builder.Services.AddSingleton<FavorietenViewModel>();

        return builder.Build();
	}
}
