namespace Backend.Infrastructure;

public class BackendDbContext : DbContext
{    
    // Entities
    public DbSet<OriginDocument> OriginDocuments=> Set<OriginDocument>();
    public DbSet<Brand> Brands=> Set<Brand>();
    public DbSet<Department> Departments=> Set<Department>();
    public DbSet<Province> Provinces=> Set<Province>();
    public DbSet<Reminder> Reminders=> Set<Reminder>();
    public DbSet<TypeRequirement> TypeRequirements=> Set<TypeRequirement>();
    public DbSet<CaseStatus> CaseStatuses=> Set<CaseStatus>();
    public DbSet<CaseStatusSecretary> CaseStatusSecretaries=> Set<CaseStatusSecretary>();
    public DbSet<CaseEntity> CaseEntities=> Set<CaseEntity>();
    public DbSet<DocumentEntity> DocumentEntities=> Set<DocumentEntity>();  
    // Permissions
    public DbSet<User> Users => Set<User>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<Profile> Profiles => Set<Profile>();
    
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    public DbSet<ProfilePermission> ProfilePermissions => Set<ProfilePermission>();
    
    public DbSet<UserGlobalPermission> UserGlobalPermissions => Set<UserGlobalPermission>();

    public BackendDbContext(DbContextOptions<BackendDbContext> options) : base(options)
    {
    }
    public BackendDbContext()
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserEfConfig());
    }

}