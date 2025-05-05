using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Schedule.Model.Data;
using Schedule.Model.Helper;
using Schedule.Model.Repositories;
using Schedule.Model.Services;
using Schedule.View;

namespace Schedule
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp(serviceProvider => new App(serviceProvider))
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "meubanco.db");

            builder.Services.AddSingleton < DatabaseContext>();

            //builder.Services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlite($"Filename={dbPath}")
            //);

            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
            builder.Services.AddSingleton<IScheduleService, ScheduleService>();
            builder.Services.AddSingleton<IClienteService, ClienteService>();

            builder.Services.AddScoped<CadastraClientePage>();
            builder.Services.AddScoped<HomePage>();
            builder.Services.AddScoped<CadastraHorario>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            ServicesHelper.Initialize(app.Services);

            return app;
        }

    }
}
