﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Playground.API.Core.Infrastructure.SqlDatabase;

#nullable disable

namespace Playground.API.Core.Infrastructure.SqlDatabase.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Playground.API.Core.Application.Models.DataRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DataRooms");
                });

            modelBuilder.Entity("Playground.API.Core.Application.Models.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Base64Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("FolderId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Playground.API.Core.Application.Models.Folder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DataRoomId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentFolderId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DataRoomId");

                    b.HasIndex("ParentFolderId");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("Playground.API.Core.Application.Models.File", b =>
                {
                    b.HasOne("Playground.API.Core.Application.Models.Folder", "Folder")
                        .WithMany("Files")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("Playground.API.Core.Application.Models.Folder", b =>
                {
                    b.HasOne("Playground.API.Core.Application.Models.DataRoom", null)
                        .WithMany("Folders")
                        .HasForeignKey("DataRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Playground.API.Core.Application.Models.Folder", "ParentFolder")
                        .WithMany("ChildrenFolders")
                        .HasForeignKey("ParentFolderId");

                    b.Navigation("ParentFolder");
                });

            modelBuilder.Entity("Playground.API.Core.Application.Models.DataRoom", b =>
                {
                    b.Navigation("Folders");
                });

            modelBuilder.Entity("Playground.API.Core.Application.Models.Folder", b =>
                {
                    b.Navigation("ChildrenFolders");

                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
