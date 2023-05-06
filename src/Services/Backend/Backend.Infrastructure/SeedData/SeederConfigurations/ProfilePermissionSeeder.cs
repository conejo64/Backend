using Backend.Domain.Entities;

namespace Backend.Infrastructure.SeedData.SeederConfigurations;

public class ProfilePermissionSeeder
{
    public static void SeedData(BackendDbContext context)
    {
        if (context.ProfilePermissions.Any())
            return;

        context.Set<ProfilePermission>().AddRange(
            new ProfilePermission(Guid.Parse("AFF7F513-DDAF-4F0A-82FE-525973EFA60E"), Guid.Parse("20CBCF7E-5B95-47B2-BFE0-8D7F0E14E0DA")),  // Backend:Users:FullAccess
            new ProfilePermission(Guid.Parse("AFF7F513-DDAF-4F0A-82FE-525973EFA60E"), Guid.Parse("4BCECB40-1B79-48D2-AB09-80499DED70ED")),  // Backend:Users:FullAccess
            new ProfilePermission(Guid.Parse("AFF7F513-DDAF-4F0A-82FE-525973EFA60E"), Guid.Parse("6247FFA8-FBE2-4063-8187-47CE30A28FA3")),  // Backend:Users:FullAccess
            new ProfilePermission(Guid.Parse("AFF7F513-DDAF-4F0A-82FE-525973EFA60E"), Guid.Parse("6AE83A95-6E26-453D-9546-12090AB917E3")),  // Backend:Users:FullAccess
            new ProfilePermission(Guid.Parse("AFF7F513-DDAF-4F0A-82FE-525973EFA60E"), Guid.Parse("83E67812-50E1-4A35-939D-362CC77B560A"))  // Backend:Users:FullAccess
        );
        context.SaveChangesAsync().Wait();
    }
}