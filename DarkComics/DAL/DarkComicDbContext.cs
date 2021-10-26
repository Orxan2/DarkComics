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
            modelBuilder.Entity<Character>(c => c.HasData(
                new Character
                {
                    Id = 1,
                    Name = "Batman"
                },
                new Character
                 {
                     Id = 2,
                     Name = "Nightwing"
                 },
                new Character
                  {
                      Id = 3,
                      Name = "Spiderman"
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
                   Image = "nightwing.png"
                },
                new Category
                {
                    Id = 2,
                    Name = "Dedective Comics",
                    CharacterId = 1,
                    Image = "nightwing.png"
                },
                new Category
                {
                    Id = 3,
                    Name = "New 52",
                    CharacterId = 2,
                    Image = "nightwing-3.png"
                }
                ));
            modelBuilder.Entity<Comic>(c => c.HasData(
                new Comic
                {
                    Id = 1,
                    Name = "Night",
                    CategoryId = 1,
                    ComicType = ComicType.Cover,
                    Episode = 2,
                    Quantity = 23,
                    Price = 9.50,
                    IsTeam = false
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
                    IsTeam = false
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
                    IsTeam = false
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
        }
    }
}
