using DarkComics.Helpers.Enums;
using DarkComics.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.DAL
{
    public class DarkComicDbContext : DbContext
    {
        public DarkComicDbContext(DbContextOptions<DarkComicDbContext> options):base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Character> Characters{ get; set; }
        public DbSet<TeamCharacter> TeamCharacters{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Comic> Comics{ get; set; }
        public DbSet<ComicCharacter> ComicCharacters{ get; set; }
        public DbSet<Toy> Toys{ get; set; }
        public DbSet<Power> Powers{ get; set; }
        public DbSet<ToyCharacter> ToyCharacters { get; set; }
        public DbSet<CharacterPower> CharacterPowers { get; set; }
        public DbSet<ReadingComic> ReadingComics { get; set; }
        public DbSet<City> Cities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comic>().
             Property(c => c.CreatedDate).HasColumnType("Date");
            modelBuilder.Entity<Toy>().
             Property(c => c.CreatedDate).HasColumnType("Date");
            modelBuilder.Entity<Character>().
             Property(c => c.CreatedDate).HasColumnType("Date");
            modelBuilder.Entity<Team>().
             Property(c => c.CreatedDate).HasColumnType("Date");
            modelBuilder.Entity<Category>().
             Property(c => c.CreatedDate).HasColumnType("Date");
            modelBuilder.Entity<Comic>().
              Property(c => c.DeActivatedDate).HasColumnType("Date");
            modelBuilder.Entity<Toy>().
             Property(c => c.DeactivatedDate).HasColumnType("Date");
           

            modelBuilder.Entity<Comic>().
                Property(p => p.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");
            modelBuilder.Entity<Toy>().
                Property(p => p.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");
            modelBuilder.Entity<Team>().
                Property(p => p.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");
            modelBuilder.Entity<Character>().
               Property(p => p.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");
            modelBuilder.Entity<Category>().
                Property(p => p.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");

            modelBuilder.Entity<Team>(c => c.HasData(
                new Team
                {
                    Id =1,
                    Name = "Titans"
                },
                new Team
                 {
                     Id = 2,
                     Name = "Justice League"
                 }, 
                new Team
                 {
                     Id = 3,
                     Name = "Avengers"
                 }
                ));
            modelBuilder.Entity<City>(c => c.HasData(
                new City
                {
                    Id = 1,
                    Name = "Gotham"                    
                },
                new City
                {
                    Id = 2,
                    Name = "Metropolis"
                },
                new City
                {
                    Id = 3,
                    Name = "New-York"
                }
                ));
            modelBuilder.Entity<Character>(c => c.HasData(
                new Character
                {
                    Id = 1,
                    Name = "Bruce Wayne",
                    NickName = "Dark Knight",
                    AboutCharacter = "Born with a congenital heart condition, Cassie's father, Scott Lang became Ant-man in order to save her. He at first stole the costume, in order to rescue the doctor who could save Cassie's life, but later was given official permission to wear it by Captain America.",
                    HeroName = "Batman",
                    FirstAppearance = "Dedective Comics #1",
                    FirstImage = "batman.png",
                    SecondImage = "batman-2.png",
                    Profile = "batman-profile.png",
                    Logo = "batman-logo.png",
                    Creator = "Bob Kane and Bill Finger",
                    CityId = 1,
                    IsActive = true
                },
                new Character
                 {
                    Id = 2,
                    Name = "Dick  Grayson",
                    NickName = "Wonder Boy",
                    AboutCharacter = "Born with a congenital heart condition, Cassie's father, Scott Lang became Ant-man in order to save her. He at first stole the costume, in order to rescue the doctor who could save Cassie's life, but later was given official permission to wear it by Captain America.",
                    HeroName = "Nightwing",
                    FirstAppearance = "Dedective Comics #14",
                    FirstImage = "nightwing.png",
                    SecondImage = "nightwing-2.png",
                    Profile = "nightwing-profile.png",
                    Logo = "nightwing-logo.png",
                    CityId = 1,
                    Creator = "Orxan Ibra",
                    IsActive = true
                    
                },
                new Character
                  {
                      Id = 3,
                      Name = "Peter Parker",
                    NickName = "Spidey",
                    AboutCharacter = "Born with a congenital heart condition, Cassie's father, Scott Lang became Ant-man in order to save her. He at first stole the costume, in order to rescue the doctor who could save Cassie's life, but later was given official permission to wear it by Captain America.",
                    HeroName = "Spiderman",
                    FirstAppearance = "Spiderman #1",
                    FirstImage = "batman.png",
                    SecondImage = "batman-2.png",
                    Profile = "batman-profile.png",
                    Logo = "spiderman-logo.png",
                    CityId = 3,
                    Creator = "Stan Lee",
                    IsActive = true
                }
                ));
            modelBuilder.Entity<TeamCharacter>(tc=>tc.HasData(
                new TeamCharacter
                {
                   Id = 1,
                   CharacterId = 1,
                   TeamId = 2
                }, 
                new TeamCharacter
                {
                    Id = 2,
                    CharacterId = 2,
                    TeamId = 1
                },
                new TeamCharacter
                 {
                     Id = 3,
                     CharacterId = 3,
                     TeamId = 3
                 }
                ));
            modelBuilder.Entity<Category>(c=>c.HasData(
                new Category
                {
                   Id = 1,
                   Name = "Rebirth",
                   CharacterId = 2,
                    Cover = "cover.jpg",
                    Backface = "backface.jpg"
                },
                new Category
                {
                    Id = 2,
                    Name = "Dedective Comics",
                    CharacterId = 1,
                    Cover = "cover.jpg",
                    Backface = "backface.jpg"
                },
                new Category
                {
                    Id = 3,
                    Name = "New 52",
                    CharacterId = 2,
                    Cover = "cover.jpg",
                    Backface = "backface.jpg"
                },
                 new Category
                 {
                     Id = 4,
                     Name = "Titans",
                     Cover = "cover.jpg",
                     Backface = "backface.jpg"
                 }
                ));
            modelBuilder.Entity<Comic>(c => c.HasData(
                new Comic
                {
                    Id = 1,
                    Name = "Night",
                    CategoryId = 1,
                    ComicType = ComicType.Cover,
                    Episode = 1,
                    Quantity = 23,
                    Price = 9.50,
                    Image = "1.jpg",
                    IsActive = true
                },
                new Comic
                {
                    Id = 2,
                    Name = "orxan",
                    CategoryId = 3,
                    ComicType = ComicType.Cover,
                    Episode = 6,
                    Quantity = 12,
                    Price = 4.50,
                    Image = "1.jpg",
                    IsActive = true
                },                
                new Comic
                {
                    Id = 3,
                    Name = "bat",
                    CategoryId = 2,
                    ComicType = ComicType.Cover,
                    Episode = 9,
                    Quantity = 6,
                    Price = 6,
                    Image = "1.jpg",
                    IsActive = true
                },
                 new Comic
                 {
                     Id = 4,
                     Name = "bat",
                     CategoryId = 2,
                     ComicType = ComicType.Book,
                     Volume = 1,
                     Quantity = 3,
                     Price = 13.40,
                     Image = "1.jpg",
                     IsActive = true
                 },
                  new Comic
                  {
                      Id = 5,
                      Name = "dick",
                      CategoryId = 1,
                      ComicType = ComicType.Book,
                      Volume = 1,
                      Quantity = 3,
                      Price = 13.40,
                      Image = "1.jpg",
                      IsActive = true
                  },
                   new Comic
                   {
                       Id = 6,
                       Name = "orxan",
                       CategoryId = 3,
                       ComicType = ComicType.Cover,
                       Episode = 30,
                       Quantity = 12,
                       Price = 4.50,
                       Image = "1.jpg",
                       IsActive = true
                   }
                ));
            modelBuilder.Entity<ComicCharacter>(cc=>cc.HasData(
                new ComicCharacter
                {
                    Id = 1,
                    CharacterId = 1,
                    ComicId = 3                    
                },
                new ComicCharacter
                 {
                     Id = 2,
                     CharacterId = 2,
                     ComicId = 2
                 },
                new ComicCharacter
                  {
                      Id = 3,
                      CharacterId = 2,
                      ComicId = 1
                  }
                ));
            modelBuilder.Entity<Power>(cc => cc.HasData(
               new Power
               {
                   Id = 1,
                   Name = "super speed"                   
               },
               new Power
               {
                   Id = 2,
                   Name = "exceptional martial artist"
               },
               new Power
               {
                   Id = 3,
                   Name = "Science"
               }
               ));
            modelBuilder.Entity<CharacterPower>(cc => cc.HasData(
              new CharacterPower
              {
                  Id = 1,
                 CharacterId = 1,
                 PowerId = 2
              },
              new CharacterPower
              {
                  Id = 2,
                  CharacterId = 1,
                  PowerId = 3
              },
               new CharacterPower
               {
                   Id = 3,
                   CharacterId = 2,
                   PowerId = 2
               },
              new CharacterPower
              {
                  Id = 4,
                  CharacterId = 2,
                  PowerId = 3
              },
              new CharacterPower
              {
                  Id = 5,
                  CharacterId = 3,
                  PowerId = 3}
              ));
            modelBuilder.Entity<ReadingComic>(cc => cc.HasData(
             new ReadingComic
             {
                 Id = 1,
                ComicId = 1,
                Image = "1.jpg"

             },
            new ReadingComic
            {
                Id = 2,
                ComicId = 1,
                Image = "2.jpg"

            },
             new ReadingComic
             {
                 Id = 3,
                 ComicId = 1,
                 Image = "3.jpg"

             },
            new ReadingComic
            {
                Id = 4,
                ComicId = 1,
                Image = "4.jpg"

            },
             new ReadingComic
             {
                 Id = 5,
                 ComicId = 1,
                 Image = "5.jpg"

             },
              new ReadingComic
              {
                  Id = 6,
                  ComicId = 1,
                  Image = "6.jpg"

              },
            new ReadingComic
            {
                Id = 7,
                ComicId = 1,
                Image = "7.jpg"

            },
             new ReadingComic
             {
                 Id = 8,
                 ComicId = 1,
                 Image = "8.jpg"

             },
            new ReadingComic
            {
                Id = 9,
                ComicId = 1,
                Image = "9.jpg"

            },
             new ReadingComic
             {
                 Id = 10,
                 ComicId = 1,
                 Image = "10.jpg"

             }
             ));
        }

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
