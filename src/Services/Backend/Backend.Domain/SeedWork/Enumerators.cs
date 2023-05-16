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

public static class DocumentSourceEnum
{
    public static string Create => nameof(Create).ToLowerInvariant();
    public static string Reply => nameof(Reply).ToLowerInvariant();
    public static string Close => nameof(Close).ToLowerInvariant();

    public static List<string> All => new() { Create, Reply, Close };
}

public static class StageEnum
{
    public static string Secretary => nameof(Secretary).ToLowerInvariant();
    public static string Others => nameof(Others).ToLowerInvariant();

    public static List<string> All => new() { Secretary, Others };
}
