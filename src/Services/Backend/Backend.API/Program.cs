using Microsoft.Extensions.FileProviders;

var configuration = GetConfiguration();
ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("es_EC");

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    Log.Information("Configuring web host ({ApplicationContext})...", Backend.API.Program.AppName);
    var builder = WebApplication.CreateBuilder(args);

    builder
        .Host
        .ConfigureAppConfiguration(x => x.AddConfiguration(configuration));
    //builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy",
            builder => builder
                .SetIsOriginAllowed(_ => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
    });
    //builder.Services.Configure<IISServerOptions>(options =>
    //{
    //    options.AutomaticAuthentication = false;
    //});
    //builder.Services.AddAuthentication(IISServerDefaults.AuthenticationScheme);
    builder.WebHost.UseContentRoot(Directory.GetCurrentDirectory());
    //builder.WebHost.UseStaticWebAssets();


    var app = builder
        .ConfigureServices(configuration)
        .ConfigurePipeline(configuration);

    Log.Information("Applying migrations ({ApplicationContext})...", Backend.API.Program.AppName);
    app.MigrateDbContext<BackendDbContext>((context, services) =>
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("Seeding data");

          UserSeeder.SeedData(context);
          ProfileSeeder.SeedData(context);
          PermissionSeeder.SeedData(context);
          ProfilePermissionSeeder.SeedData(context);

        logger.LogInformation("Seeding data DONE");
    });
    Log.Information("Starting web host ({ApplicationContext})...", Backend.API.Program.AppName);

    if (app.Environment.IsDevelopment())
    {
        //app.UseExceptionHandler("/Error");
        app.UseHsts();
    }
   
    //var serilog = new LoggerConfiguration()
    //    .Enrich.FromLogContext()
    //    .WriteTo.Console(
    //        outputTemplate:
    //        "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}",
    //        theme: AnsiConsoleTheme.Code)
    //    .WriteTo.File(
    //        @"logs/cd.txt",
    //        fileSizeLimitBytes: 1_000_000,
    //        rollOnFileSizeLimit: true,
    //        rollingInterval: RollingInterval.Day,
    //        shared: true,
    //        flushToDiskInterval: TimeSpan.FromSeconds(1));
    //        loggerFactory.AddSerilog(serilog.CreateLogger());

    app.UseHttpsRedirection();
    app.UseCors("CorsPolicy"); //"CorsPolicy"
    app.UseSpaStaticFiles(new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(builder.Environment.ContentRootPath, @"wwwroot/dist"))
    });
    DefaultFilesOptions options = new DefaultFilesOptions();
    options.DefaultFileNames.Clear();
    options.DefaultFileNames.Add("dist/index.html");
    app.UseDefaultFiles(options);
    app.MapDefaultControllerRoute();
    
    app.UseSpa(spa =>
    {
        spa.Options.SourcePath = "wwwroot";

        if (app.Environment.IsDevelopment())
        {
        }
    });
    
    app.Run();
}
catch (Exception ex) when
    (ex.GetType().Name is not "StopTheHostException") // https://github.com/dotnet/runtime/issues/60600
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}

namespace Backend.API
{
    public class Program
    {
        public static string Namespace = typeof(Program).Namespace!;

        public static string AppName =
            Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);
    }
}