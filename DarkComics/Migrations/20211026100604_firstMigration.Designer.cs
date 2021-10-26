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
    [Migration("20211026100604_firstMigration")]
    partial class firstMigration
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

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("dateadd(hour,4,getutcdate())");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

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
                            CharacterId = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "nightwing.png",
                            Name = "Rebirth"
                        },
                        new
                        {
                            Id = 2,
                            CharacterId = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "nightwing.png",
                            Name = "Dedective Comics"
                        },
                        new
                        {
                            Id = 3,
                            CharacterId = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "nightwing-3.png",
                            Name = "New 52"
                        });
                });

            modelBuilder.Entity("DarkComics.Models.Entity.Character", b =>
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

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Batman"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Nightwing"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Spiderman"
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
                            Episode = 2.0,
                            IsActive = false,
                            IsTeam = false,
                            Name = "Night",
                            Price = 9.5,
                            Quantity = 23,
                            Volume = 0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            ComicType = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Episode = 6.0,
                            IsActive = false,
                            IsTeam = false,
                            Name = "orxan",
                            Price = 4.5,
                            Quantity = 12,
                            Volume = 0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            ComicType = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Episode = 9.0,
                            IsActive = false,
                            IsTeam = false,
                            Name = "bat",
                            Price = 6.0,
                            Quantity = 6,
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

            modelBuilder.Entity("DarkComics.Models.Entity.Category", b =>
                {
                    b.HasOne("DarkComics.Models.Entity.Character", "Character")
                        .WithMany("Categories")
                        .HasForeignKey("CharacterId");
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

            modelBuilder.Entity("DarkComics.Models.Entity.TeamCharacter", b =>
                {
                    b.HasOne("DarkComics.Models.Entity.Character", "Character")
                        .WithMany("TeamCharacters")
                        .HasForeignKey("CharacterId");

                    b.HasOne("DarkComics.Models.Entity.Team", "Team")
                        .WithMany("TeamCharacters")
                        .HasForeignKey("TeamId");
                });
#pragma warning restore 612, 618
        }
    }
}
