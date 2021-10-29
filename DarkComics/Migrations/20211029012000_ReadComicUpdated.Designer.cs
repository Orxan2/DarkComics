﻿// <auto-generated />
using System;
using DarkComics.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DarkComics.Migrations
{
    [DbContext(typeof(DarkComicDbContext))]
    [Migration("20211029012000_ReadComicUpdated")]
    partial class ReadComicUpdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DarkComics.Models.Entity.Category", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Backface")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("dateadd(hour,4,getutcdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Backface = "backface.jpg",
                            CharacterId = 2,
                            Cover = "cover.jpg",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Rebirth"
                        },
                        new
                        {
                            Id = 2,
                            Backface = "backface.jpg",
                            CharacterId = 1,
                            Cover = "cover.jpg",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Dedective Comics"
                        },
                        new
                        {
                            Id = 3,
                            Backface = "backface.jpg",
                            CharacterId = 2,
                            Cover = "cover.jpg",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "New 52"
                        },
                        new
                        {
                            Id = 4,
                            Backface = "backface.jpg",
                            Cover = "cover.jpg",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Titans"
                        });
                });

            modelBuilder.Entity("DarkComics.Models.Entity.Character", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutCharacter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("dateadd(hour,4,getutcdate())");

                    b.Property<string>("FirstAppearance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeroName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AboutCharacter = "Born with a congenital heart condition, Cassie's father, Scott Lang became Ant-man in order to save her. He at first stole the costume, in order to rescue the doctor who could save Cassie's life, but later was given official permission to wear it by Captain America.",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstAppearance = "Dedective Comics #1",
                            FirstImage = "batman.png",
                            HeroName = "Batman",
                            IsActive = true,
                            Logo = "batman-logo.png",
                            Name = "Bruce Wayne",
                            NickName = "Dark Knight",
                            Profile = "batman-profile.png",
                            SecondImage = "batman-2.png"
                        },
                        new
                        {
                            Id = 2,
                            AboutCharacter = "Born with a congenital heart condition, Cassie's father, Scott Lang became Ant-man in order to save her. He at first stole the costume, in order to rescue the doctor who could save Cassie's life, but later was given official permission to wear it by Captain America.",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstAppearance = "Dedective Comics #14",
                            FirstImage = "nightwing.png",
                            HeroName = "Nightwing",
                            IsActive = true,
                            Logo = "nightwing-logo.png",
                            Name = "Dick  Grayson",
                            NickName = "Wonder Boy",
                            Profile = "nightwing-profile.png",
                            SecondImage = "nightwing-2.png"
                        },
                        new
                        {
                            Id = 3,
                            AboutCharacter = "Born with a congenital heart condition, Cassie's father, Scott Lang became Ant-man in order to save her. He at first stole the costume, in order to rescue the doctor who could save Cassie's life, but later was given official permission to wear it by Captain America.",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstAppearance = "Spiderman #1",
                            FirstImage = "batman.png",
                            HeroName = "Spiderman",
                            IsActive = true,
                            Logo = "spiderman-logo.png",
                            Name = "Peter Parker",
                            NickName = "Spidey",
                            Profile = "batman-profile.png",
                            SecondImage = "batman-2.png"
                        });
                });

            modelBuilder.Entity("DarkComics.Models.Entity.CharacterPower", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int?>("PowerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("PowerId");

                    b.ToTable("CharacterPowers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CharacterId = 1,
                            PowerId = 2
                        },
                        new
                        {
                            Id = 2,
                            CharacterId = 1,
                            PowerId = 3
                        },
                        new
                        {
                            Id = 3,
                            CharacterId = 2,
                            PowerId = 2
                        },
                        new
                        {
                            Id = 4,
                            CharacterId = 2,
                            PowerId = 3
                        },
                        new
                        {
                            Id = 5,
                            CharacterId = 3,
                            PowerId = 3
                        });
                });

            modelBuilder.Entity("DarkComics.Models.Entity.Comic", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ComicType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("dateadd(hour,4,getutcdate())");

                    b.Property<DateTime?>("DeActivatedDate")
                        .HasColumnType("Date");

                    b.Property<double>("Episode")
                        .HasColumnType("float");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTeam")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SaleQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TeamId");

                    b.ToTable("Comics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            ComicType = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Episode = 1.0,
                            Image = "1.jpg",
                            IsActive = true,
                            IsTeam = false,
                            Name = "Night",
                            Price = 9.5,
                            Quantity = 23,
                            SaleQuantity = 0,
                            Volume = 0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            ComicType = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Episode = 6.0,
                            Image = "1.jpg",
                            IsActive = true,
                            IsTeam = false,
                            Name = "orxan",
                            Price = 4.5,
                            Quantity = 12,
                            SaleQuantity = 0,
                            Volume = 0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            ComicType = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Episode = 9.0,
                            Image = "1.jpg",
                            IsActive = true,
                            IsTeam = false,
                            Name = "bat",
                            Price = 6.0,
                            Quantity = 6,
                            SaleQuantity = 0,
                            Volume = 0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            ComicType = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Episode = 0.0,
                            Image = "1.jpg",
                            IsActive = true,
                            IsTeam = false,
                            Name = "bat",
                            Price = 13.4,
                            Quantity = 3,
                            SaleQuantity = 0,
                            Volume = 1
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            ComicType = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Episode = 0.0,
                            Image = "1.jpg",
                            IsActive = true,
                            IsTeam = false,
                            Name = "dick",
                            Price = 13.4,
                            Quantity = 3,
                            SaleQuantity = 0,
                            Volume = 1
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            ComicType = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Episode = 30.0,
                            Image = "1.jpg",
                            IsActive = true,
                            IsTeam = false,
                            Name = "orxan",
                            Price = 4.5,
                            Quantity = 12,
                            SaleQuantity = 0,
                            Volume = 0
                        });
                });

            modelBuilder.Entity("DarkComics.Models.Entity.ComicCharacter", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int?>("ComicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("ComicId");

                    b.ToTable("ComicCharacters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CharacterId = 1,
                            ComicId = 3
                        },
                        new
                        {
                            Id = 2,
                            CharacterId = 2,
                            ComicId = 2
                        },
                        new
                        {
                            Id = 3,
                            CharacterId = 2,
                            ComicId = 1
                        });
                });

            modelBuilder.Entity("DarkComics.Models.Entity.Power", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Powers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "super speed"
                        },
                        new
                        {
                            Id = 2,
                            Name = "exceptional martial artist"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Science"
                        });
                });

            modelBuilder.Entity("DarkComics.Models.Entity.ReadingComic", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComicId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComicId");

                    b.ToTable("ReadingComic");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ComicId = 1,
                            Image = "1.jpg"
                        },
                        new
                        {
                            Id = 2,
                            ComicId = 1,
                            Image = "2.jpg"
                        },
                        new
                        {
                            Id = 3,
                            ComicId = 1,
                            Image = "3.jpg"
                        },
                        new
                        {
                            Id = 4,
                            ComicId = 1,
                            Image = "4.jpg"
                        },
                        new
                        {
                            Id = 5,
                            ComicId = 1,
                            Image = "5.jpg"
                        },
                        new
                        {
                            Id = 6,
                            ComicId = 1,
                            Image = "6.jpg"
                        },
                        new
                        {
                            Id = 7,
                            ComicId = 1,
                            Image = "7.jpg"
                        },
                        new
                        {
                            Id = 8,
                            ComicId = 1,
                            Image = "8.jpg"
                        },
                        new
                        {
                            Id = 9,
                            ComicId = 1,
                            Image = "9.jpg"
                        },
                        new
                        {
                            Id = 10,
                            ComicId = 1,
                            Image = "10.jpg"
                        });
                });

            modelBuilder.Entity("DarkComics.Models.Entity.Team", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("dateadd(hour,4,getutcdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Titans"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Justice League"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Avengers"
                        });
                });

            modelBuilder.Entity("DarkComics.Models.Entity.TeamCharacter", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamCharacters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CharacterId = 1,
                            TeamId = 2
                        },
                        new
                        {
                            Id = 2,
                            CharacterId = 2,
                            TeamId = 1
                        },
                        new
                        {
                            Id = 3,
                            CharacterId = 3,
                            TeamId = 3
                        });
                });

            modelBuilder.Entity("DarkComics.Models.Entity.Toy", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("dateadd(hour,4,getutcdate())");

                    b.Property<DateTime?>("DeactivatedDate")
                        .HasColumnType("Date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Toys");
                });

            modelBuilder.Entity("DarkComics.Models.Entity.ToyCharacter", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int?>("ToyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("ToyId");

                    b.ToTable("ToyCharacters");
                });

            modelBuilder.Entity("DarkComics.Models.Entity.Category", b =>
                {
                    b.HasOne("DarkComics.Models.Entity.Character", "Character")
                        .WithMany("Categories")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("DarkComics.Models.Entity.CharacterPower", b =>
                {
                    b.HasOne("DarkComics.Models.Entity.Character", "Character")
                        .WithMany("CharacterPowers")
                        .HasForeignKey("CharacterId");

                    b.HasOne("DarkComics.Models.Entity.Power", "Power")
                        .WithMany("CharacterPowers")
                        .HasForeignKey("PowerId");
                });

            modelBuilder.Entity("DarkComics.Models.Entity.Comic", b =>
                {
                    b.HasOne("DarkComics.Models.Entity.Category", "Category")
                        .WithMany("Comics")
                        .HasForeignKey("CategoryId");

                    b.HasOne("DarkComics.Models.Entity.Team", "Team")
                        .WithMany("Comics")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("DarkComics.Models.Entity.ComicCharacter", b =>
                {
                    b.HasOne("DarkComics.Models.Entity.Character", "Character")
                        .WithMany("ComicCharacters")
                        .HasForeignKey("CharacterId");

                    b.HasOne("DarkComics.Models.Entity.Comic", "Comic")
                        .WithMany("ComicCharacters")
                        .HasForeignKey("ComicId");
                });

            modelBuilder.Entity("DarkComics.Models.Entity.ReadingComic", b =>
                {
                    b.HasOne("DarkComics.Models.Entity.Comic", "Comic")
                        .WithMany("ReadingComics")
                        .HasForeignKey("ComicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DarkComics.Models.Entity.TeamCharacter", b =>
                {
                    b.HasOne("DarkComics.Models.Entity.Character", "Character")
                        .WithMany("TeamCharacters")
                        .HasForeignKey("CharacterId");

                    b.HasOne("DarkComics.Models.Entity.Team", "Team")
                        .WithMany("TeamCharacters")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("DarkComics.Models.Entity.ToyCharacter", b =>
                {
                    b.HasOne("DarkComics.Models.Entity.Character", "Character")
                        .WithMany("ToyCharacters")
                        .HasForeignKey("CharacterId");

                    b.HasOne("DarkComics.Models.Entity.Toy", "Toy")
                        .WithMany("ToyCharacters")
                        .HasForeignKey("ToyId");
                });
#pragma warning restore 612, 618
        }
    }
}
