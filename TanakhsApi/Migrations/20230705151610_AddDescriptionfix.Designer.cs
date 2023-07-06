﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TanakhsApi.Entities;

#nullable disable

namespace TanakhsApi.Migrations
{
    [DbContext(typeof(TanakhsContext))]
    [Migration("20230705151610_AddDescriptionfix")]
    partial class AddDescriptionfix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TanakhsApi.Entities.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("BlogPosts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BlogPost");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TanakhsApi.Entities.ChapterRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Historical")
                        .HasColumnType("int");

                    b.Property<int>("Moral")
                        .HasColumnType("int");

                    b.Property<int>("Scientific")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ChapterRating");
                });

            modelBuilder.Entity("TanakhsApi.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("BlogPostId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BlogPostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("TanakhsApi.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BlogPostId")
                        .HasColumnType("int");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("TanakhsApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("GivenName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Religion")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("SignInDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TanakhsApi.Entities.Verse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ChapterId")
                        .HasColumnType("int");

                    b.Property<string>("Char")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Verses");
                });

            modelBuilder.Entity("TanakhsApi.Entities.Chapter", b =>
                {
                    b.HasBaseType("TanakhsApi.Entities.BlogPost");

                    b.Property<string>("ChapterChar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChapterNumber")
                        .HasColumnType("int");

                    b.Property<int?>("ChapterRatingId")
                        .HasColumnType("int");

                    b.Property<int>("HolyBook")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("ChapterRatingId");

                    b.HasDiscriminator().HasValue("Chapter");
                });

            modelBuilder.Entity("TanakhsApi.Entities.BlogPost", b =>
                {
                    b.HasOne("TanakhsApi.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("TanakhsApi.Entities.Comment", b =>
                {
                    b.HasOne("TanakhsApi.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TanakhsApi.Entities.BlogPost", null)
                        .WithMany("Comments")
                        .HasForeignKey("BlogPostId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("TanakhsApi.Entities.Tag", b =>
                {
                    b.HasOne("TanakhsApi.Entities.BlogPost", null)
                        .WithMany("Tags")
                        .HasForeignKey("BlogPostId");
                });

            modelBuilder.Entity("TanakhsApi.Entities.Verse", b =>
                {
                    b.HasOne("TanakhsApi.Entities.Chapter", null)
                        .WithMany("Verses")
                        .HasForeignKey("ChapterId");
                });

            modelBuilder.Entity("TanakhsApi.Entities.Chapter", b =>
                {
                    b.HasOne("TanakhsApi.Entities.ChapterRating", "ChapterRating")
                        .WithMany()
                        .HasForeignKey("ChapterRatingId");

                    b.Navigation("ChapterRating");
                });

            modelBuilder.Entity("TanakhsApi.Entities.BlogPost", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("TanakhsApi.Entities.Chapter", b =>
                {
                    b.Navigation("Verses");
                });
#pragma warning restore 612, 618
        }
    }
}
