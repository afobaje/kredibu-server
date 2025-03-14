using Microsoft.EntityFrameworkCore;
namespace kredibu_server.Data;


public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {

    }

    public DbSet<IndividualUser> users { get; set; }
    public DbSet<BusinessUser> businessUsers { get; set; }
    public DbSet<Rating> ratings { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IndividualUser>(e => e.ToTable("IndividualUser").HasKey(e => e.Id));
        modelBuilder.Entity<IndividualUser>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.Id).HasColumnName("id").HasDefaultValueSql("gen_random_uuid()").HasColumnType("uuid");
            entity.Property(e => e.firstName).HasColumnName("first_name").IsRequired();
            entity.Property(e => e.lastName).HasColumnName("last_name").IsRequired();
            entity.Property(e => e.password).HasColumnName("password").IsRequired();
            entity.Property(e => e.email).HasColumnName("email").IsRequired();
            entity.Property(e => e.phone).HasColumnName("phone").IsRequired();
            entity.Property(e => e.address).HasColumnName("address").IsRequired();
            entity.Property(e => e.gender).HasColumnName("gender").IsRequired();
            entity.Property(e => e.dob).HasColumnName("dob").IsRequired();
            entity.Property(e => e.occupation).HasColumnName("occupation").IsRequired();
            entity.Property(e => e.state).HasColumnName("state").IsRequired();
            entity.Property(e => e.country).HasColumnName("country").IsRequired();
        });
        modelBuilder.Entity<BusinessUser>().HasOne<IndividualUser>().WithMany().HasForeignKey(e => e.ownerId).IsRequired();

        modelBuilder.Entity<Rating>(e =>
        {
            e.ToTable("Rating").HasKey(e => e.Id);
            e.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            e.Property(e => e.comment).HasColumnName("comment");
            e.Property(e => e.score).HasColumnName("score").IsRequired();
            e.Property(e => e.ownerId).HasColumnName("owner_id").IsRequired();

        });
        base.OnModelCreating(modelBuilder);
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseNpgsql(connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=afobaje;Database=kredibu_database;");

    // }
}

// "DefaultConnection":"postgres://postgres:afobaje@localhost:5432/kredibu_database;"
