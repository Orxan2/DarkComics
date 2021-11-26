using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DarkComics.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Fullname = table.Column<string>(nullable: false),
                    IsAgree = table.Column<bool>(nullable: false),
                    IsSubscriber = table.Column<bool>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Text = table.Column<string>(type: "Text", nullable: false),
                    ShortDescription = table.Column<string>(nullable: false),
                    Blogger = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: true, defaultValueSql: "dateadd(hour,4,getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Powers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    BirthDay = table.Column<DateTime>(type: "Date", nullable: false),
                    Mobile = table.Column<string>(nullable: false),
                    Home = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Cover = table.Column<string>(nullable: true),
                    Backface = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    IsTeam = table.Column<bool>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    DeactivatedDate = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    HeroName = table.Column<string>(nullable: false),
                    FirstAppearance = table.Column<string>(nullable: false),
                    FirstImage = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    SecondImage = table.Column<string>(nullable: true),
                    Profile = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    DeactivatedDate = table.Column<DateTime>(nullable: false),
                    NickName = table.Column<string>(nullable: false),
                    Creator = table.Column<string>(nullable: false),
                    Height = table.Column<string>(maxLength: 20, nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    EyeColor = table.Column<string>(maxLength: 20, nullable: false),
                    HairStyle = table.Column<string>(maxLength: 20, nullable: false),
                    Education = table.Column<string>(maxLength: 30, nullable: false),
                    Fighting = table.Column<int>(nullable: false),
                    Durability = table.Column<int>(nullable: false),
                    Energy = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    LayoutImage = table.Column<string>(nullable: true),
                    AboutCharacter = table.Column<string>(type: "Text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComicDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Backface = table.Column<string>(nullable: true),
                    IsCover = table.Column<bool>(nullable: false),
                    PageCount = table.Column<int>(nullable: true),
                    SerieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComicDetails_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TagNews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(nullable: true),
                    NewsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagNews_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TagNews_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsId = table.Column<int>(nullable: true),
                    CommentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostComments_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterNews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(nullable: true),
                    NewsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterNews_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterNews_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterPowers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PowerId = table.Column<int>(nullable: true),
                    CharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterPowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterPowers_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterPowers_Powers_PowerId",
                        column: x => x.PowerId,
                        principalTable: "Powers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToyCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(nullable: true),
                    ToyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToyCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToyCharacters_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToyCharacters_Toys_ToyId",
                        column: x => x.ToyId,
                        principalTable: "Toys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    Description = table.Column<string>(nullable: true),
                    MailMessage = table.Column<string>(nullable: true),
                    DeActivatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ComicDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ComicDetails_ComicDetailId",
                        column: x => x.ComicDetailId,
                        principalTable: "ComicDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReadingComics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "dateadd(hour,4,getutcdate())"),
                    ComicDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingComics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingComics_ComicDetails_ComicDetailId",
                        column: x => x.ComicDetailId,
                        principalTable: "ComicDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: true),
                    CharacterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCharacters_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCharacters_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    SaleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleItems_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, false, "Gotham" },
                    { 2, false, "Metropolis" },
                    { 3, false, "New-York" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Blogger", "Image", "ShortDescription", "Text", "Title" },
                values: new object[,]
                {
                    { 1, "Tim Beedle", "cover.jpg", "From the iconic, beloved Fleischer shorts of the 1940s to the groundbreaking shared animated universe that introduced DC’s Super...", "<div class='body-insertable'><p>From the iconic, beloved Fleischer shorts of the 1940s to the groundbreaking shared animated universe that introduced DC’s Super Heroes to legions of fans, Superman and Batman have a long legacy in animation.</p><p> A legacy that will soon enter a thrilling new chapter.</p><p> HBO Max and Cartoon Network announced a pair of new animated series this morning featuring DC’s two biggest heroes—Batman and Superman. <strong><em> Batman: Caped Crusader </em></strong> stems from the creative minds of Bruce Timm,J.J.Abrams and Matt Reeves and promises a fresh take on the Dark Knight and his popular rogues’ gallery.In contrast, <strong><em> My Adventures with Superman </em></strong> will bring youthful energy to the world of the Man of Steel in a new animated series aimed at kids and families.</p><p> Produced by Warner Bros.Animation,                  Bad Robot Productions and 6 <sup> th </sup>&amp; Idaho, and executive produced by Timm, Abrams and Reeves, <em> Batman: Caped Crusader</em> notably marks Timm’s return to Batman in animated episodic television after his iconic work on the Emmy-winning < a href = 'https://www.dccomics.com/tv/batman-the-animated-series-1992-1995' target = '_blank' ><em> Batman: The Animated Series,</ em ></ a > which ran from 1992 through 1995 and spawned an interconnected animated universe that’s still growing to this day.Critically acclaimed and viewed by many as the gold standard of animated superhero storytelling, < em > Batman: The Animated Series </ em > is considered one of the best depictions of the Dark Knight in any medium.</ p >", "Batman and Superman Return to Animation with Two Thrilling New Series" },
                    { 2, "Tim Beedle", "cover.jpg", "From the iconic, beloved Fleischer shorts of the 1940s to the groundbreaking shared animated universe that introduced DC’s Super...", "<div class='body-insertable'><p>From the iconic, beloved Fleischer shorts of the 1940s to the groundbreaking shared animated universe that introduced DC’s Super Heroes to legions of fans, Superman and Batman have a long legacy in animation.</p><p> A legacy that will soon enter a thrilling new chapter.</p><p> HBO Max and Cartoon Network announced a pair of new animated series this morning featuring DC’s two biggest heroes—Batman and Superman. <strong><em> Batman: Caped Crusader </em></strong> stems from the creative minds of Bruce Timm,J.J.Abrams and Matt Reeves and promises a fresh take on the Dark Knight and his popular rogues’ gallery.In contrast, <strong><em> My Adventures with Superman </em></strong> will bring youthful energy to the world of the Man of Steel in a new animated series aimed at kids and families.</p><p> Produced by Warner Bros.Animation,                  Bad Robot Productions and 6 <sup> th </sup>&amp; Idaho, and executive produced by Timm, Abrams and Reeves, <em> Batman: Caped Crusader</em> notably marks Timm’s return to Batman in animated episodic television after his iconic work on the Emmy-winning < a href = 'https://www.dccomics.com/tv/batman-the-animated-series-1992-1995' target = '_blank' ><em> Batman: The Animated Series,</ em ></ a > which ran from 1992 through 1995 and spawned an interconnected animated universe that’s still growing to this day.Critically acclaimed and viewed by many as the gold standard of animated superhero storytelling, < em > Batman: The Animated Series </ em > is considered one of the best depictions of the Dark Knight in any medium.</ p >", "Batman and Superman Return to Animation with Two Thrilling New Series" },
                    { 3, "Tim Beedle", "cover.jpg", "From the iconic, beloved Fleischer shorts of the 1940s to the groundbreaking shared animated universe that introduced DC’s Super...", "<div class='body-insertable'><p>From the iconic, beloved Fleischer shorts of the 1940s to the groundbreaking shared animated universe that introduced DC’s Super Heroes to legions of fans, Superman and Batman have a long legacy in animation.</p><p> A legacy that will soon enter a thrilling new chapter.</p><p> HBO Max and Cartoon Network announced a pair of new animated series this morning featuring DC’s two biggest heroes—Batman and Superman. <strong><em> Batman: Caped Crusader </em></strong> stems from the creative minds of Bruce Timm,J.J.Abrams and Matt Reeves and promises a fresh take on the Dark Knight and his popular rogues’ gallery.In contrast, <strong><em> My Adventures with Superman </em></strong> will bring youthful energy to the world of the Man of Steel in a new animated series aimed at kids and families.</p><p> Produced by Warner Bros.Animation,                  Bad Robot Productions and 6 <sup> th </sup>&amp; Idaho, and executive produced by Timm, Abrams and Reeves, <em> Batman: Caped Crusader</em> notably marks Timm’s return to Batman in animated episodic television after his iconic work on the Emmy-winning < a href = 'https://www.dccomics.com/tv/batman-the-animated-series-1992-1995' target = '_blank' ><em> Batman: The Animated Series,</ em ></ a > which ran from 1992 through 1995 and spawned an interconnected animated universe that’s still growing to this day.Critically acclaimed and viewed by many as the gold standard of animated superhero storytelling, < em > Batman: The Animated Series </ em > is considered one of the best depictions of the Dark Knight in any medium.</ p >", "Batman and Superman Return to Animation with Two Thrilling New Series" }
                });

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "super speed" },
                    { 2, "exceptional martial artist" },
                    { 3, "Science" }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Backface", "Cover", "DeletedDate", "Discount", "IsDeleted", "IsTeam", "Name" },
                values: new object[,]
                {
                    { 1, "backface.png", "cover.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, false, "Nightwing Rebirth" },
                    { 2, "backface.png", "cover.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, false, "Batman Rebirth" },
                    { 3, "backface.png", "cover.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, true, "Justice League Rebirth" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Batman" },
                    { 2, "Nightwing" },
                    { 3, "Spider-man" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "AboutCharacter", "CityId", "Creator", "DeactivatedDate", "Durability", "Education", "Energy", "EyeColor", "Fighting", "FirstAppearance", "FirstImage", "HairStyle", "Height", "HeroName", "Intelligence", "IsActive", "LayoutImage", "Logo", "Name", "NickName", "Profile", "SecondImage", "Speed", "Strength", "Weight" },
                values: new object[,]
                {
                    { 1, "Born with a congenital heart condition, Cassie's father, Scott Lang became Ant-man in order to save her. He at first stole the costume, in order to rescue the doctor who could save Cassie's life, but later was given official permission to wear it by Captain America.", 1, "Bob Kane and Bill Finger", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Gotham City School", 8, "Blue", 9, "Dedective Comics #1", "batman.png", "Black", "1.89", "Batman", 7, true, "layout.png", "batman-logo.png", "Bruce Wayne", "Dark Knight", "batman-profile.png", "batman-2.png", 6, 7, 70 },
                    { 2, "Born with a congenital heart condition, Cassie's father, Scott Lang became Ant-man in order to save her. He at first stole the costume, in order to rescue the doctor who could save Cassie's life, but later was given official permission to wear it by Captain America.", 1, "Orxan Ibra", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Gotham City School", 8, "Blue", 9, "Dedective Comics #14", "nightwing.png", "Black", "1.89", "Nightwing", 7, true, "layout.png", "nightwing-logo.png", "Dick  Grayson", "Wonder Boy", "nightwing-profile.png", "nightwing-2.png", 6, 7, 70 },
                    { 3, "Born with a congenital heart condition, Cassie's father, Scott Lang became Ant-man in order to save her. He at first stole the costume, in order to rescue the doctor who could save Cassie's life, but later was given official permission to wear it by Captain America.", 3, "Stan Lee", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Gotham City School", 8, "Blue", 9, "Spiderman #1", "batman.png", "Black", "1.89", "Spiderman", 7, true, "layout.png", "spiderman-logo.png", "Peter Parker", "Spidey", "batman-profile.png", "batman-2.png", 6, 7, 70 }
                });

            migrationBuilder.InsertData(
                table: "ComicDetails",
                columns: new[] { "Id", "Backface", "IsCover", "PageCount", "SerieId" },
                values: new object[,]
                {
                    { 1, "backface.png", true, 12, 1 },
                    { 2, "backface.png", true, 7, 2 },
                    { 3, "backface.png", true, 10, 3 }
                });

            migrationBuilder.InsertData(
                table: "TagNews",
                columns: new[] { "Id", "NewsId", "TagId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "CharacterNews",
                columns: new[] { "Id", "CharacterId", "NewsId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "CharacterPowers",
                columns: new[] { "Id", "CharacterId", "PowerId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 3 },
                    { 3, 2, 2 },
                    { 4, 2, 3 },
                    { 5, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "ComicDetailId", "DeActivatedDate", "Description", "Image", "IsActive", "MailMessage", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 22, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Dedective Comics #78", 7.5, 8 },
                    { 21, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "justice League #15", 7.5, 8 },
                    { 20, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Dedective Comics #1", 7.5, 12 },
                    { 16, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman Rebirth #29", 7.5, 8 },
                    { 18, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman Rebirth #7", 7.5, 23 },
                    { 17, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman Rebirth #13", 7.5, 8 },
                    { 23, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman Rebirth #29", 7.5, 8 },
                    { 19, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman New 52 #2", 7.5, 8 },
                    { 24, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman Rebirth #13", 7.5, 8 },
                    { 28, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman Rebirth #13", 7.5, 8 },
                    { 26, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman New 52 #2", 7.5, 8 },
                    { 27, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Dedective Comics #1", 7.5, 12 },
                    { 15, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Dedective Comics #78", 7.5, 8 },
                    { 29, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman Rebirth #7", 7.5, 23 },
                    { 30, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman New 52 #2", 7.5, 8 },
                    { 31, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Dedective Comics #1", 7.5, 12 },
                    { 32, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "justice League #15", 7.5, 8 },
                    { 33, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Dedective Comics #78", 7.5, 8 },
                    { 34, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman Rebirth #29", 7.5, 8 },
                    { 25, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman Rebirth #7", 7.5, 23 },
                    { 14, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "justice League #15", 7.5, 8 },
                    { 10, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman Rebirth #13", 7.5, 8 },
                    { 12, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman New 52 #2", 7.5, 8 },
                    { 1, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Nightwing Rebirth #1", 6.5, 3 },
                    { 13, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Dedective Comics #1", 7.5, 12 },
                    { 2, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman Rebirth #1", 7.5, 8 },
                    { 4, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman Rebirth #7", 7.5, 23 },
                    { 5, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman New 52 #2", 7.5, 8 },
                    { 3, 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Justice League Rebirth #1", 10.0, 12 },
                    { 7, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "justice League #15", 7.5, 8 },
                    { 8, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Dedective Comics #78", 7.5, 8 },
                    { 9, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman Rebirth #29", 7.5, 8 },
                    { 35, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman Rebirth #13", 7.5, 8 },
                    { 11, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Batman Rebirth #7", 7.5, 23 },
                    { 6, 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is Detail", "cover.jpg", true, null, "Dedective Comics #1", 7.5, 12 }
                });

            migrationBuilder.InsertData(
                table: "ReadingComics",
                columns: new[] { "Id", "ComicDetailId", "Image" },
                values: new object[,]
                {
                    { 10, 1, "10.jpg" },
                    { 8, 1, "8.jpg" },
                    { 7, 1, "7.jpg" },
                    { 6, 1, "6.jpg" },
                    { 5, 1, "5.jpg" },
                    { 4, 1, "4.jpg" },
                    { 3, 1, "3.jpg" },
                    { 2, 1, "2.jpg" },
                    { 1, 1, "1.jpg" },
                    { 9, 1, "9.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ProductCharacters",
                columns: new[] { "Id", "CharacterId", "ProductId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 32, 1, 32 },
                    { 31, 1, 31 },
                    { 30, 1, 30 },
                    { 29, 1, 29 },
                    { 27, 1, 27 },
                    { 26, 1, 26 },
                    { 25, 1, 25 },
                    { 24, 1, 24 },
                    { 23, 1, 23 },
                    { 22, 1, 22 },
                    { 21, 1, 21 },
                    { 20, 1, 20 },
                    { 19, 1, 19 },
                    { 18, 1, 18 },
                    { 33, 1, 33 },
                    { 28, 1, 17 },
                    { 16, 1, 16 },
                    { 15, 1, 15 },
                    { 14, 1, 14 },
                    { 13, 1, 13 },
                    { 12, 1, 12 },
                    { 11, 1, 11 },
                    { 10, 1, 10 },
                    { 9, 1, 9 },
                    { 8, 1, 8 },
                    { 7, 1, 7 },
                    { 6, 1, 6 },
                    { 5, 1, 5 },
                    { 4, 1, 4 },
                    { 2, 1, 2 },
                    { 17, 1, 17 },
                    { 3, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterNews_CharacterId",
                table: "CharacterNews",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterNews_NewsId",
                table: "CharacterNews",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPowers_CharacterId",
                table: "CharacterPowers",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPowers_PowerId",
                table: "CharacterPowers",
                column: "PowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CityId",
                table: "Characters",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicDetails_SerieId",
                table: "ComicDetails",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId1",
                table: "Comments",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_CommentId",
                table: "PostComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_NewsId",
                table: "PostComments",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCharacters_CharacterId",
                table: "ProductCharacters",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCharacters_ProductId",
                table: "ProductCharacters",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ComicDetailId",
                table: "Products",
                column: "ComicDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingComics_ComicDetailId",
                table: "ReadingComics",
                column: "ComicDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_ProductId",
                table: "SaleItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_SaleId",
                table: "SaleItems",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_TagNews_NewsId",
                table: "TagNews",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_TagNews_TagId",
                table: "TagNews",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ToyCharacters_CharacterId",
                table: "ToyCharacters",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ToyCharacters_ToyId",
                table: "ToyCharacters",
                column: "ToyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CharacterNews");

            migrationBuilder.DropTable(
                name: "CharacterPowers");

            migrationBuilder.DropTable(
                name: "PostComments");

            migrationBuilder.DropTable(
                name: "ProductCharacters");

            migrationBuilder.DropTable(
                name: "ReadingComics");

            migrationBuilder.DropTable(
                name: "SaleItems");

            migrationBuilder.DropTable(
                name: "TagNews");

            migrationBuilder.DropTable(
                name: "ToyCharacters");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Powers");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Toys");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ComicDetails");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
