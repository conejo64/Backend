using Backend.Domain.Entities;

namespace Backend.Infrastructure.SeedData.SeederConfigurations;

public class ProfilePermissionSeeder
{
    public static void SeedData(BackendDbContext context)
    {
        if (context.ProfilePermissions.Any())
            return;

        context.Set<ProfilePermission>().AddRange(
            new ProfilePermission(Guid.Parse("AFF7F513-DDAF-4F0A-82FE-525973EFA60E"), Guid.Parse("83e67812-50e1-4a35-939d-362cc77b560a"))  // Backend:Users:FullAccess
        );

        context.SaveChangesAsync().Wait();
    }
}