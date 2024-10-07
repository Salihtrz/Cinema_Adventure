﻿// <auto-generated />
using System;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(CinemaDb))]
    [Migration("20240613125852_Review_News added state and visibility")]
    partial class Review_Newsaddedstateandvisibility
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Class.AboutUs", b =>
                {
                    b.Property<int>("AboutUsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AboutUsId"));

                    b.Property<string>("AboutUsContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutUsPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutUsTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AboutUsId");

                    b.ToTable("AboutUss");
                });

            modelBuilder.Entity("EntityLayer.Class.Cast", b =>
                {
                    b.Property<int>("CastId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CastId"));

                    b.Property<string>("CastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CastPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CastSurname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CastId");

                    b.ToTable("Casts");
                });

            modelBuilder.Entity("EntityLayer.Class.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("EntityLayer.Class.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"));

                    b.Property<string>("ContactAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("EntityLayer.Class.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("MovieContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoviePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MovieRunTime")
                        .HasColumnType("int");

                    b.Property<string>("ReleaseCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VideoLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("EntityLayer.Class.MovieCast", b =>
                {
                    b.Property<int>("MovieCastId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieCastId"));

                    b.Property<int?>("CastId")
                        .HasColumnType("int");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("MovieCastId");

                    b.HasIndex("CastId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCasts");
                });

            modelBuilder.Entity("EntityLayer.Class.MovieCategory", b =>
                {
                    b.Property<int>("MovieCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieCategoryId"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("MovieCategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCategory");
                });

            modelBuilder.Entity("EntityLayer.Class.News", b =>
                {
                    b.Property<int>("NewsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NewsId"));

                    b.Property<string>("NewsContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewsPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewsTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SendingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("NewsId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("EntityLayer.Class.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("ReviewContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SendingDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<bool>("Visibility")
                        .HasColumnType("bit");

                    b.Property<int?>("VoteGiven")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("EntityLayer.Class.Review_News", b =>
                {
                    b.Property<int>("Review_NewsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Review_NewsId"));

                    b.Property<int?>("NewsId")
                        .HasColumnType("int");

                    b.Property<string>("ReviewContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SendingDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("State")
                        .HasColumnType("bit");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<bool?>("Visibility")
                        .HasColumnType("bit");

                    b.HasKey("Review_NewsId");

                    b.HasIndex("NewsId");

                    b.HasIndex("UserID");

                    b.ToTable("Reviews_News");
                });

            modelBuilder.Entity("EntityLayer.Class.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCategoryReadAccess")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCategoryWriteAccess")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMovieReadAccess")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMovieWriteAccess")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUser")
                        .HasColumnType("bit");

                    b.Property<string>("RoleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EntityLayer.Class.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserSurname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EntityLayer.Class.MovieCast", b =>
                {
                    b.HasOne("EntityLayer.Class.Cast", "casts")
                        .WithMany()
                        .HasForeignKey("CastId");

                    b.HasOne("EntityLayer.Class.Movie", "movies")
                        .WithMany("MovieCasts")
                        .HasForeignKey("MovieId");

                    b.Navigation("casts");

                    b.Navigation("movies");
                });

            modelBuilder.Entity("EntityLayer.Class.MovieCategory", b =>
                {
                    b.HasOne("EntityLayer.Class.Category", "categorys")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("EntityLayer.Class.Movie", "movies")
                        .WithMany("MovieCategories")
                        .HasForeignKey("MovieId");

                    b.Navigation("categorys");

                    b.Navigation("movies");
                });

            modelBuilder.Entity("EntityLayer.Class.Review", b =>
                {
                    b.HasOne("EntityLayer.Class.Movie", null)
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId");

                    b.HasOne("EntityLayer.Class.User", "users")
                        .WithMany("reviews")
                        .HasForeignKey("UserID");

                    b.Navigation("users");
                });

            modelBuilder.Entity("EntityLayer.Class.Review_News", b =>
                {
                    b.HasOne("EntityLayer.Class.News", null)
                        .WithMany("reviews_News")
                        .HasForeignKey("NewsId");

                    b.HasOne("EntityLayer.Class.User", "users")
                        .WithMany("reviews_News")
                        .HasForeignKey("UserID");

                    b.Navigation("users");
                });

            modelBuilder.Entity("EntityLayer.Class.User", b =>
                {
                    b.HasOne("EntityLayer.Class.Role", "roles")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("roles");
                });

            modelBuilder.Entity("EntityLayer.Class.Movie", b =>
                {
                    b.Navigation("MovieCasts");

                    b.Navigation("MovieCategories");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("EntityLayer.Class.News", b =>
                {
                    b.Navigation("reviews_News");
                });

            modelBuilder.Entity("EntityLayer.Class.User", b =>
                {
                    b.Navigation("reviews");

                    b.Navigation("reviews_News");
                });
#pragma warning restore 612, 618
        }
    }
}
