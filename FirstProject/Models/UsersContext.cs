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
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Qazaqstan"},
                new Country { Id = 2, Name = "Russia"}
            );
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Nur-Sultan", CountryId = 1},
                new City { Id = 2, Name = "Almaty", CountryId = 1},
                new City { Id = 3, Name = "Moscow", CountryId = 2},
                new City { Id = 4, Name = "St-Petersburg", CountryId = 2}
            );
            modelBuilder.Entity<Center>().HasData(
                new Center { Id = 1, Name = "Alma-Center №1", CountryId = 1, CityId = 2},
                new Center { Id = 2, Name = "Alma-Center №2", CountryId = 1, CityId = 2},
                new Center { Id = 3, Name = "Nur-Center №1", CountryId = 1, CityId = 1 },
                new Center { Id = 4, Name = "Nur-Center №2", CountryId = 1, CityId = 1 },
                new Center { Id = 5, Name = "Moscow-Center №1", CountryId = 2, CityId = 3 },
                new Center { Id = 6, Name = "Moscow-Center №2", CountryId = 2, CityId = 3 },
                new Center { Id = 7, Name = "Petersburg-Center №1", CountryId = 2, CityId = 4 },
                new Center { Id = 8, Name = "Petersburg-Center №2", CountryId = 2, CityId = 4 }
            );
            modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     Id = 1,
                     FirstName = "Давид",
                     MiddleName = "Низамиевич",
                     LastName = "Мехтиев",
                     Email = "mekthiev.1995@bk.ru",
                     Password = BCrypt.Net.BCrypt.HashPassword("password"),
                     RoleId = 3,
                     IIN = "11111111111"
                 },
                 new User
                 {
                     Id = 2,
                     FirstName = "Даяна",
                     MiddleName = "Жолдасбековна",
                     LastName = "Шагирова",
                     Email = "shagirovaDayana@gmail.com",
                     Password = BCrypt.Net.BCrypt.HashPassword("shagirova"),
                     RoleId = 1,
                     IIN = "123123154345"
                 },
                  new User
                  {
                      Id = 3,
                      FirstName = "Никита",
                      MiddleName = "Сергеевич",
                      LastName = "Литвинов",
                      Email = "litvinov.2004@mail.ru",
                      Password = BCrypt.Net.BCrypt.HashPassword("litvinov"),
                      RoleId = 2,
                      IIN = "24523452341"
                  },
                   new User
                   {
                       Id = 4,
                       FirstName = "Максим",
                       MiddleName = "Иванович",
                       LastName = "Дворянкин",
                       Email = "maksim12313@mail.ru",
                       Password = null,
                       RoleId = 4,
                       IIN = "112624511111"
                   }
            );
        }
    }
}
