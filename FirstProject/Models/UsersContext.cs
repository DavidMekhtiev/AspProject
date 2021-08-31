using Microsoft.EntityFrameworkCore;


namespace FirstProject.Models
{
    public class UsersContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<CenterUser> CenterUsers { get; set; }
        public DbSet<Center> Center { get; set; }

        public UsersContext(DbContextOptions<UsersContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CenterUser>()
                .HasKey(bc => new { bc.UserId, bc.CenterId });
            modelBuilder.Entity<CenterUser>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.CenterUsers)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<CenterUser>()
               .HasOne(bc => bc.Center)
               .WithMany(b => b.CenterUsers)
               .HasForeignKey(bc => bc.CenterId);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" , Description = "Админ"},
                new Role { Id = 2, Name = "Teacher", Description = "Преподаватель" },
                new Role { Id = 3, Name = "Owner", Description = "Владелец" },
                new Role { Id = 4, Name = "Student", Description = "Студент" }
            );
        }
    }
}
