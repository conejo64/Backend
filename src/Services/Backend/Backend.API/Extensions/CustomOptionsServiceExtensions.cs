namespace Backend.API.Extensions;

public static class CustomOptionsServiceExtensions
{
    public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration config)
    {
        // services.Configure<SmsSettings>(config.GetSection("SmsSettings"));
        // services.Configure<MailSettings>(config.GetSection("MailSettings"));
        return services;
    }
}