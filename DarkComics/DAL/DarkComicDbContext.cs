﻿using DarkComics.Helpers.Enums;
using DarkComics.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.DAL
{
    public class DarkComicDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public DarkComicDbContext(DbContextOptions<DarkComicDbContext> options):base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Character> Characters{ get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ComicDetail> ComicDetails { get; set; }
        public DbSet<ProductCharacter> ProductCharacters { get; set; }
        public DbSet<Toy> Toys{ get; set; }
        public DbSet<Power> Powers{ get; set; }
        public DbSet<ToyCharacter> ToyCharacters { get; set; }
        public DbSet<CharacterPower> CharacterPowers { get; set; }
        public DbSet<ReadingComic> ReadingComics { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<CharacterNews> CharacterNews { get; set; }
        public DbSet<TagNews> TagNews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().
             Property(p => p.CreatedDate).HasColumnType("Date");
            modelBuilder.Entity<Toy>().
             Property(c => c.CreatedDate).HasColumnType("Date");
            modelBuilder.Entity<Character>().
             Property(c => c.CreatedDate).HasColumnType("Date");
            modelBuilder.Entity<Character>().
           Property(c => c.AboutCharacter).HasColumnType("Text");
            modelBuilder.Entity<News>().
                 Property(c => c.Text).HasColumnType("Text");
            modelBuilder.Entity<Serie>().
             Property(s => s.CreatedDate).HasColumnType("Date");
            modelBuilder.Entity<ReadingComic>().
             Property(rc => rc.CreatedDate).HasColumnType("Date");
            modelBuilder.Entity<Product>().
              Property(p => p.DeActivatedDate).HasColumnType("Date");
            modelBuilder.Entity<City>().
             Property(c => c.CreatedDate).HasColumnType("Date");
            modelBuilder.Entity<News>().
            Property(n => n.CreatedDate).HasColumnType("Date");

            modelBuilder.Entity<Toy>().
             Property(c => c.DeactivatedDate).HasColumnType("Date");


            modelBuilder.Entity<Product>().
                Property(p => p.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");
            modelBuilder.Entity<News>().
                Property(n => n.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");
            modelBuilder.Entity<Toy>().
                Property(p => p.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");
            modelBuilder.Entity<ReadingComic>().
                Property(rc => rc.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");
            modelBuilder.Entity<Character>().
               Property(c => c.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");
            modelBuilder.Entity<Serie>().
                Property(s => s.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");
            modelBuilder.Entity<City>().
                Property(c => c.CreatedDate).HasDefaultValueSql("dateadd(hour,4,getutcdate())");

           
            modelBuilder.Entity<Serie>(c => c.HasData(
               new Serie
               {
                   Id = 1,
                   Name = "Nightwing Rebirth",
                   Cover = "cover.png",
                   Backface = "backface.png",
                   IsTeam = false                   
               },
               new Serie
               {
                   Id = 2,
                   Name = "Batman Rebirth",
                   Cover = "cover.png",
                   Backface = "backface.png",
                   IsTeam = false
               },
               new Serie
               {
                   Id = 3,
                   Name = "Justice League Rebirth",
                   Cover = "cover.png",
                   Backface = "backface.png",
                   IsTeam = true
               }
               ));

            modelBuilder.Entity<ComicDetail>(c => c.HasData(
              new ComicDetail
              {
                  Id = 1,
                  Backface = "backface.png",
                  IsCover = true,
                  SerieId = 1,                 
                  PageCount = 12                  
                  
              },
              new ComicDetail
              {
                  Id = 2,
                  Backface = "backface.png",
                  IsCover = true,
                  SerieId = 2,
                  PageCount = 7
              },
              new ComicDetail
              {
                  Id = 3,
                  Backface = "backface.png",
                  IsCover = true,
                  SerieId = 3,
                  PageCount = 10
              }
              ));
            modelBuilder.Entity<Product>(c => c.HasData(
               new Product
               {
                   Id = 1,
                   Name = "Nightwing Rebirth #1",
                   Quantity = 3,
                   Price = 6.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,                   
                   ComicDetailId = 1
               },
               new Product
               {
                   Id = 2,
                   Name = "Batman Rebirth #1",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 3,
                   Name = "Justice League Rebirth #1",
                   Quantity = 12,
                   Price = 10,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 3
               },
               new Product
               {
                   Id = 4,
                   Name = "Batman Rebirth #7",
                   Quantity = 23,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 5,
                   Name = "Batman New 52 #2",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 6,
                   Name = "Dedective Comics #1",
                   Quantity = 12,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 7,
                   Name = "justice League #15",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 8,
                   Name = "Dedective Comics #78",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 9,
                   Name = "Batman Rebirth #29",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 10,
                   Name = "Batman Rebirth #13",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 11,
                   Name = "Batman Rebirth #7",
                   Quantity = 23,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 12,
                   Name = "Batman New 52 #2",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 13,
                   Name = "Dedective Comics #1",
                   Quantity = 12,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 14,
                   Name = "justice League #15",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 15,
                   Name = "Dedective Comics #78",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 16,
                   Name = "Batman Rebirth #29",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 17,
                   Name = "Batman Rebirth #13",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 18,
                   Name = "Batman Rebirth #7",
                   Quantity = 23,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 19,
                   Name = "Batman New 52 #2",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 20,
                   Name = "Dedective Comics #1",
                   Quantity = 12,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 21,
                   Name = "justice League #15",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 22,
                   Name = "Dedective Comics #78",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 23,
                   Name = "Batman Rebirth #29",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 24,
                   Name = "Batman Rebirth #13",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 25,
                   Name = "Batman Rebirth #7",
                   Quantity = 23,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 26,
                   Name = "Batman New 52 #2",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 27,
                   Name = "Dedective Comics #1",
                   Quantity = 12,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 28,
                   Name = "Batman Rebirth #13",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 29,
                   Name = "Batman Rebirth #7",
                   Quantity = 23,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 30,
                   Name = "Batman New 52 #2",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 31,
                   Name = "Dedective Comics #1",
                   Quantity = 12,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 32,
                   Name = "justice League #15",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 33,
                   Name = "Dedective Comics #78",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 34,
                   Name = "Batman Rebirth #29",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
               },
               new Product
               {
                   Id = 35,
                   Name = "Batman Rebirth #13",
                   Quantity = 8,
                   Price = 7.50,
                   Category = Category.Comic,
                   Description = "This is Detail",
                   Image = "cover.jpg",
                   IsActive = true,
                   ComicDetailId = 2
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
                    Durability = 5,
                    Education = "Gotham City School",
                    Energy = 8,
                    EyeColor = "Blue",
                    HairStyle = "Black",
                    Weight = 70,
                    Fighting = 9,
                    Intelligence = 7,
                    Height = "1.89",
                    Speed = 6,
                    Strength = 7,
                    LayoutImage = "layout.png",
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
                    Durability = 5,
                    Education = "Gotham City School",
                    Energy = 8,
                    EyeColor = "Blue",
                    HairStyle = "Black",
                    Weight = 70,
                    Fighting = 9,
                    Intelligence = 7,
                    Height = "1.89",
                    Speed = 6,
                    Strength = 7,
                    LayoutImage = "layout.png",
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
                    Durability = 5,
                    Education = "Gotham City School",
                    Energy = 8,
                    EyeColor = "Blue",
                    HairStyle = "Black",
                    Weight = 70,
                    Fighting = 9,
                    Intelligence = 7,
                    Height = "1.89",
                    Speed = 6,
                    Strength = 7,
                    LayoutImage = "layout.png",
                    IsActive = true
                }
                ));

            modelBuilder.Entity<ProductCharacter>(c => c.HasData(
               new ProductCharacter
               {
                   Id = 1,
                   CharacterId = 2,
                   ProductId = 1,
               },
               new ProductCharacter
               {
                   Id = 2,
                   CharacterId = 1,
                   ProductId = 2,
               },

               new ProductCharacter
               {
                   Id = 3,
                   CharacterId = 3,
                   ProductId = 3,
               },
                new ProductCharacter
                {
                    Id = 4,
                    CharacterId = 1,
                    ProductId = 4,
                },
                 new ProductCharacter
                 {
                     Id = 5,
                     CharacterId = 1,
                     ProductId = 5,
                 },
                  new ProductCharacter
                  {
                      Id = 6,
                      CharacterId = 1,
                      ProductId = 6,
                  },
                   new ProductCharacter
                   {
                       Id = 7,
                       CharacterId = 1,
                       ProductId = 7,
                   },
                    new ProductCharacter
                    {
                        Id = 8,
                        CharacterId = 1,
                        ProductId = 8,
                    },
                     new ProductCharacter
                     {
                         Id = 9,
                         CharacterId = 1,
                         ProductId = 9,
                     },
                     new ProductCharacter
                     {
                         Id = 10,
                         CharacterId = 1,
                         ProductId = 10,
                     },
                     new ProductCharacter
                     {
                         Id = 11,
                         CharacterId = 1,
                         ProductId = 11,
                     },
                     new ProductCharacter
                     {
                         Id = 12,
                         CharacterId = 1,
                         ProductId = 12,
                     },
                     new ProductCharacter
                     {
                         Id = 13,
                         CharacterId = 1,
                         ProductId = 13,
                     },
                     new ProductCharacter
                     {
                         Id = 14,
                         CharacterId = 1,
                         ProductId = 14,
                     },
                     new ProductCharacter
                     {
                         Id = 15,
                         CharacterId = 1,
                         ProductId = 15,
                     },
                      new ProductCharacter
                      {
                          Id = 16,
                          CharacterId = 1,
                          ProductId = 16,
                      },
                     new ProductCharacter
                     {
                         Id = 17,
                         CharacterId = 1,
                         ProductId = 17,
                     },
                     new ProductCharacter
                     {
                         Id = 18,
                         CharacterId = 1,
                         ProductId = 18,
                     },
                     new ProductCharacter
                     {
                         Id = 19,
                         CharacterId = 1,
                         ProductId = 19,
                     },
                     new ProductCharacter
                     {
                         Id = 20,
                         CharacterId = 1,
                         ProductId = 20,
                     },
                       new ProductCharacter
                     {
                         Id = 21,
                         CharacterId = 1,
                         ProductId = 21,
                     },
                     new ProductCharacter
                     {
                         Id = 22,
                         CharacterId = 1,
                         ProductId = 22,
                     },
                     new ProductCharacter
                     {
                         Id = 23,
                         CharacterId = 1,
                         ProductId = 23,
                     },
                     new ProductCharacter
                     {
                         Id = 24,
                         CharacterId = 1,
                         ProductId = 24,
                     },
                     new ProductCharacter
                     {
                         Id = 25,
                         CharacterId = 1,
                         ProductId = 25,
                     },
                     new ProductCharacter
                     {
                         Id = 26,
                         CharacterId = 1,
                         ProductId = 26,
                     },
                      new ProductCharacter
                      {
                          Id = 27,
                          CharacterId = 1,
                          ProductId = 27,
                      },
                     new ProductCharacter
                     {
                         Id = 28,
                         CharacterId = 1,
                         ProductId = 17,
                     },
                   
                     new ProductCharacter
                     {
                         Id = 29,
                         CharacterId = 1,
                         ProductId = 29,
                     },
                     new ProductCharacter
                     {
                         Id = 30,
                         CharacterId = 1,
                         ProductId = 30,
                     },
                      new ProductCharacter
                      {
                          Id = 31,
                          CharacterId = 1,
                          ProductId = 31,
                      },
                     new ProductCharacter
                     {
                         Id = 32,
                         CharacterId = 1,
                         ProductId = 32,
                     },
                     new ProductCharacter
                     {
                         Id = 33,
                         CharacterId = 1,
                         ProductId = 33,
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

            modelBuilder.Entity<News>(c => c.HasData(
              new News
              {
                  Id = 1,
                  Title = "Batman and Superman Return to Animation with Two Thrilling New Series",
                  Image = "cover.jpg",
                  Blogger = "Tim Beedle",
                  CreatedDate = DateTime.Now,
                  ShortDescription = "From the iconic, beloved Fleischer shorts of the 1940s to the groundbreaking shared animated universe that introduced DC’s Super...",
                  Text = "<div class='body-insertable'><p>From the iconic, beloved Fleischer shorts of the 1940s to the groundbreaking shared animated universe that introduced DC’s Super Heroes to legions of fans, Superman and Batman have a long legacy in animation.</p><p> A legacy that will soon enter a thrilling new chapter.</p><p> HBO Max and Cartoon Network announced a pair of new animated series this morning featuring DC’s two biggest heroes—Batman and Superman. <strong><em> Batman: Caped Crusader </em></strong> stems from the creative minds of Bruce Timm,J.J.Abrams and Matt Reeves and promises a fresh take on the Dark Knight and his popular rogues’ gallery.In contrast, <strong><em> My Adventures with Superman </em></strong> will bring youthful energy to the world of the Man of Steel in a new animated series aimed at kids and families.</p><p> Produced by Warner Bros.Animation,                  Bad Robot Productions and 6 <sup> th </sup>&amp; Idaho, and executive produced by Timm, Abrams and Reeves, <em> Batman: Caped Crusader</em> notably marks Timm’s return to Batman in animated episodic television after his iconic work on the Emmy-winning < a href = 'https://www.dccomics.com/tv/batman-the-animated-series-1992-1995' target = '_blank' ><em> Batman: The Animated Series,</ em ></ a > which ran from 1992 through 1995 and spawned an interconnected animated universe that’s still growing to this day.Critically acclaimed and viewed by many as the gold standard of animated superhero storytelling, < em > Batman: The Animated Series </ em > is considered one of the best depictions of the Dark Knight in any medium.</ p >"
              },
              new News
              {
                  Id = 2,
                  Title = "Batman and Superman Return to Animation with Two Thrilling New Series",
                  Image = "cover.jpg",
                  Blogger = "Tim Beedle",
                  ShortDescription = "From the iconic, beloved Fleischer shorts of the 1940s to the groundbreaking shared animated universe that introduced DC’s Super...",
                  Text = "<div class='body-insertable'><p>From the iconic, beloved Fleischer shorts of the 1940s to the groundbreaking shared animated universe that introduced DC’s Super Heroes to legions of fans, Superman and Batman have a long legacy in animation.</p><p> A legacy that will soon enter a thrilling new chapter.</p><p> HBO Max and Cartoon Network announced a pair of new animated series this morning featuring DC’s two biggest heroes—Batman and Superman. <strong><em> Batman: Caped Crusader </em></strong> stems from the creative minds of Bruce Timm,J.J.Abrams and Matt Reeves and promises a fresh take on the Dark Knight and his popular rogues’ gallery.In contrast, <strong><em> My Adventures with Superman </em></strong> will bring youthful energy to the world of the Man of Steel in a new animated series aimed at kids and families.</p><p> Produced by Warner Bros.Animation,                  Bad Robot Productions and 6 <sup> th </sup>&amp; Idaho, and executive produced by Timm, Abrams and Reeves, <em> Batman: Caped Crusader</em> notably marks Timm’s return to Batman in animated episodic television after his iconic work on the Emmy-winning < a href = 'https://www.dccomics.com/tv/batman-the-animated-series-1992-1995' target = '_blank' ><em> Batman: The Animated Series,</ em ></ a > which ran from 1992 through 1995 and spawned an interconnected animated universe that’s still growing to this day.Critically acclaimed and viewed by many as the gold standard of animated superhero storytelling, < em > Batman: The Animated Series </ em > is considered one of the best depictions of the Dark Knight in any medium.</ p >"
              },
               new News
               {
                   Id = 3,
                   Title = "Batman and Superman Return to Animation with Two Thrilling New Series",
                   Image = "cover.jpg",
                   Blogger = "Tim Beedle",
                   ShortDescription = "From the iconic, beloved Fleischer shorts of the 1940s to the groundbreaking shared animated universe that introduced DC’s Super...",
                   Text = "<div class='body-insertable'><p>From the iconic, beloved Fleischer shorts of the 1940s to the groundbreaking shared animated universe that introduced DC’s Super Heroes to legions of fans, Superman and Batman have a long legacy in animation.</p><p> A legacy that will soon enter a thrilling new chapter.</p><p> HBO Max and Cartoon Network announced a pair of new animated series this morning featuring DC’s two biggest heroes—Batman and Superman. <strong><em> Batman: Caped Crusader </em></strong> stems from the creative minds of Bruce Timm,J.J.Abrams and Matt Reeves and promises a fresh take on the Dark Knight and his popular rogues’ gallery.In contrast, <strong><em> My Adventures with Superman </em></strong> will bring youthful energy to the world of the Man of Steel in a new animated series aimed at kids and families.</p><p> Produced by Warner Bros.Animation,                  Bad Robot Productions and 6 <sup> th </sup>&amp; Idaho, and executive produced by Timm, Abrams and Reeves, <em> Batman: Caped Crusader</em> notably marks Timm’s return to Batman in animated episodic television after his iconic work on the Emmy-winning < a href = 'https://www.dccomics.com/tv/batman-the-animated-series-1992-1995' target = '_blank' ><em> Batman: The Animated Series,</ em ></ a > which ran from 1992 through 1995 and spawned an interconnected animated universe that’s still growing to this day.Critically acclaimed and viewed by many as the gold standard of animated superhero storytelling, < em > Batman: The Animated Series </ em > is considered one of the best depictions of the Dark Knight in any medium.</ p >"
               }
              )) ; 
            modelBuilder.Entity<Tag>(c => c.HasData(
             new Tag
             {
                 Id = 1,
                 Title = "Batman"                
             },
             new Tag
             {
                 Id = 2,
                 Title = "Nightwing"
             },
             new Tag
             {
                 Id = 3,
                 Title = "Spider-man"
             }
             ));
            modelBuilder.Entity<CharacterNews>(c => c.HasData(
             new CharacterNews
             {
                 Id = 1,
                 CharacterId = 1,
                 NewsId = 1
             },
            new CharacterNews
            {
                Id = 2,
                CharacterId = 2,
                NewsId = 2
            },
             new CharacterNews
             {
                 Id = 3,
                 CharacterId = 3,
                 NewsId = 3
             }
             ));
            modelBuilder.Entity<TagNews>(c => c.HasData(
            new TagNews
            {
                Id = 1,
                TagId = 1,
                NewsId = 1
            },
           new TagNews
           {
               Id = 2,
               TagId = 2,
               NewsId = 2
           },
            new TagNews
            {
                Id = 3,
                TagId = 3,
                NewsId = 3
            }
            ));
            modelBuilder.Entity<ReadingComic>(cc => cc.HasData(
             new ReadingComic
             {
                 Id = 1,
                 ComicDetailId = 1,
                Image = "1.jpg"

             },
            new ReadingComic
            {
                Id = 2,
                Image = "2.jpg",
                ComicDetailId = 1

            },
             new ReadingComic
             {
                 Id = 3,
                 ComicDetailId = 1,
                 Image = "3.jpg"

             },
            new ReadingComic
            {
                Id = 4,
                ComicDetailId = 1,
                Image = "4.jpg"

            },
             new ReadingComic
             {
                 Id = 5,
                 ComicDetailId = 1,
                 Image = "5.jpg"

             },
              new ReadingComic
              {
                  Id = 6,
                  ComicDetailId = 1,
                  Image = "6.jpg"

              },
            new ReadingComic
            {
                Id = 7,
                ComicDetailId = 1,
                Image = "7.jpg"

            },
             new ReadingComic
             {
                 Id = 8,
                 ComicDetailId = 1,
                 Image = "8.jpg"

             },
            new ReadingComic
            {
                Id = 9,
                ComicDetailId = 1,
                Image = "9.jpg"

            },
             new ReadingComic
             {
                 Id = 10,
                 ComicDetailId = 1,
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
