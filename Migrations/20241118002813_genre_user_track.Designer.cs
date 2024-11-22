﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicG.Infrastructure.database;

#nullable disable

namespace MusicG.Migrations
{
    [DbContext(typeof(AppDatabaseContext))]
    [Migration("20241118002813_genre_user_track")]
    partial class genre_user_track
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("MusicG.Infrastructure.database.entity.GenreEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MusicG.Infrastructure.database.entity.TrackEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Track")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("track_link");

                    b.Property<string>("TrackImage")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("image");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("UserId");

                    b.ToTable("Track_table");
                });

            modelBuilder.Entity("MusicG.Infrastructure.database.entity.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users_table");
                });

            modelBuilder.Entity("MusicG.Infrastructure.database.entity.TrackEntity", b =>
                {
                    b.HasOne("MusicG.Infrastructure.database.entity.GenreEntity", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicG.Infrastructure.database.entity.UserEntity", "User")
                        .WithMany("tracks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MusicG.Infrastructure.database.entity.UserEntity", b =>
                {
                    b.Navigation("tracks");
                });
#pragma warning restore 612, 618
        }
    }
}