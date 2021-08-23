﻿// <auto-generated />
using System;
using DasharooAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DasharooAPI.Migrations
{
    [DbContext(typeof(DasharooDbContext))]
    [Migration("20210823074958_AddedImagePathFields")]
    partial class AddedImagePathFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DasharooAPI.Data.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentGenreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentGenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("DasharooAPI.Data.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BackgroundPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("VisibilityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("VisibilityId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("DasharooAPI.Data.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOfficialRemix")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemix")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OriginalPlaylistId")
                        .HasColumnType("int");

                    b.Property<int?>("OriginalRecordId")
                        .HasColumnType("int");

                    b.Property<decimal>("Plays")
                        .HasColumnType("decimal(20,0)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SourcePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VisibilityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OriginalPlaylistId");

                    b.HasIndex("OriginalRecordId");

                    b.HasIndex("VisibilityId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("DasharooAPI.Data.RecordGenre", b =>
                {
                    b.Property<int>("RecordId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("RecordId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("RecordGenres");
                });

            modelBuilder.Entity("DasharooAPI.Data.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("BackgroundPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("Verified")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DasharooAPI.Data.Visibility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Visibility");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Public"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Private"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Unlisted"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Scheduled"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "8d11514c-e5c0-4ade-a049-ed52bdc9ddfb",
                            ConcurrencyStamp = "1d7a3701-fbc9-4001-863b-f75af666c053",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "773c2a6d-a377-44fe-bb6c-23ff424a167e",
                            ConcurrencyStamp = "7b65ec3a-59cc-41de-b885-d9b3bcf700d3",
                            Name = "Premium_User",
                            NormalizedName = "PREMIUM_USER"
                        },
                        new
                        {
                            Id = "fa108de1-dfc4-4277-a777-72110ca4f8d3",
                            ConcurrencyStamp = "fb23a97b-72fd-4eba-b5c9-c7c1b401d4c6",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PlaylistRecord", b =>
                {
                    b.Property<int>("PlaylistsId")
                        .HasColumnType("int");

                    b.Property<int>("RecordsId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistsId", "RecordsId");

                    b.HasIndex("RecordsId");

                    b.ToTable("PlaylistRecord");
                });

            modelBuilder.Entity("RecordUser", b =>
                {
                    b.Property<string>("AuthorsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RecordsId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "RecordsId");

                    b.HasIndex("RecordsId");

                    b.ToTable("RecordUser");
                });

            modelBuilder.Entity("RecordUser1", b =>
                {
                    b.Property<int>("SupportedRecordsId")
                        .HasColumnType("int");

                    b.Property<string>("SupportersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SupportedRecordsId", "SupportersId");

                    b.HasIndex("SupportersId");

                    b.ToTable("RecordUser1");
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.Property<string>("FollowersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FollowingsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FollowersId", "FollowingsId");

                    b.HasIndex("FollowingsId");

                    b.ToTable("UserUser");
                });

            modelBuilder.Entity("DasharooAPI.Data.Genre", b =>
                {
                    b.HasOne("DasharooAPI.Data.Genre", "ParentGenre")
                        .WithMany()
                        .HasForeignKey("ParentGenreId");

                    b.Navigation("ParentGenre");
                });

            modelBuilder.Entity("DasharooAPI.Data.Playlist", b =>
                {
                    b.HasOne("DasharooAPI.Data.User", "Author")
                        .WithMany("Playlists")
                        .HasForeignKey("AuthorId");

                    b.HasOne("DasharooAPI.Data.Visibility", "PlaylistVisibility")
                        .WithMany()
                        .HasForeignKey("VisibilityId");

                    b.Navigation("Author");

                    b.Navigation("PlaylistVisibility");
                });

            modelBuilder.Entity("DasharooAPI.Data.Record", b =>
                {
                    b.HasOne("DasharooAPI.Data.Playlist", "OriginalPlaylist")
                        .WithMany("OriginalRecords")
                        .HasForeignKey("OriginalPlaylistId");

                    b.HasOne("DasharooAPI.Data.Record", "OriginalRecord")
                        .WithMany()
                        .HasForeignKey("OriginalRecordId");

                    b.HasOne("DasharooAPI.Data.Visibility", "RecordVisibility")
                        .WithMany()
                        .HasForeignKey("VisibilityId");

                    b.Navigation("OriginalPlaylist");

                    b.Navigation("OriginalRecord");

                    b.Navigation("RecordVisibility");
                });

            modelBuilder.Entity("DasharooAPI.Data.RecordGenre", b =>
                {
                    b.HasOne("DasharooAPI.Data.Genre", "Genre")
                        .WithMany("RecordGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DasharooAPI.Data.Record", "Record")
                        .WithMany("RecordGenres")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Record");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DasharooAPI.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DasharooAPI.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DasharooAPI.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DasharooAPI.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlaylistRecord", b =>
                {
                    b.HasOne("DasharooAPI.Data.Playlist", null)
                        .WithMany()
                        .HasForeignKey("PlaylistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DasharooAPI.Data.Record", null)
                        .WithMany()
                        .HasForeignKey("RecordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecordUser", b =>
                {
                    b.HasOne("DasharooAPI.Data.User", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DasharooAPI.Data.Record", null)
                        .WithMany()
                        .HasForeignKey("RecordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecordUser1", b =>
                {
                    b.HasOne("DasharooAPI.Data.Record", null)
                        .WithMany()
                        .HasForeignKey("SupportedRecordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DasharooAPI.Data.User", null)
                        .WithMany()
                        .HasForeignKey("SupportersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.HasOne("DasharooAPI.Data.User", null)
                        .WithMany()
                        .HasForeignKey("FollowersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DasharooAPI.Data.User", null)
                        .WithMany()
                        .HasForeignKey("FollowingsId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DasharooAPI.Data.Genre", b =>
                {
                    b.Navigation("RecordGenres");
                });

            modelBuilder.Entity("DasharooAPI.Data.Playlist", b =>
                {
                    b.Navigation("OriginalRecords");
                });

            modelBuilder.Entity("DasharooAPI.Data.Record", b =>
                {
                    b.Navigation("RecordGenres");
                });

            modelBuilder.Entity("DasharooAPI.Data.User", b =>
                {
                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}
