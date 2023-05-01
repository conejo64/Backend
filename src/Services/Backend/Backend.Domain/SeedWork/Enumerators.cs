namespace Backend.Domain.SeedWork;

public static class PermissionTypes
{
    public static string Global => nameof(Global).ToLowerInvariant();
    public static string Scoped => nameof(Scoped).ToLowerInvariant();

    public static List<string> All => new() { Global, Scoped };
}

public static class CatalogsStatus
{
    public static string Active => nameof(Active).ToLowerInvariant();
    public static string Inactive => nameof(Inactive).ToLowerInvariant();
    public static string Deleted => nameof(Deleted).ToLowerInvariant();

    public static List<string> All => new() { Active, Inactive, Deleted };
}

public static class UserState
{
    public static string Active => nameof(Active).ToLowerInvariant();
    public static string Inactive => nameof(Inactive).ToLowerInvariant();
    public static string Deleted => nameof(Deleted).ToLowerInvariant();

    public static List<string> All => new() { Active, Inactive, Deleted };
}

public static class ProfileStatus
{
    public static string Active => nameof(Active).ToLowerInvariant();
    public static string Deleted => nameof(Deleted).ToLowerInvariant();
    public static List<string> All => new() { Active, Deleted };
}

public static class UserTypes
{
    public static string Manager => nameof(Manager).ToLowerInvariant();
    public static string Member => nameof(Member).ToLowerInvariant();
    public static List<string> All => new() { Manager, Member };
}

