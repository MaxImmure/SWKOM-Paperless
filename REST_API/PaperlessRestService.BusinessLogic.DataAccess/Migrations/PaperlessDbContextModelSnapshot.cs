﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PaperlessRestService.BusinessLogic.DataAccess.Database;

#nullable disable

namespace PaperlessRestService.BusinessLogic.DataAccess.Migrations
{
    [DbContext(typeof(PaperlessDbContext))]
    partial class PaperlessDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.Correspondents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsInsensitive")
                        .HasColumnType("boolean");

                    b.Property<int>("LastCorrespondentsId")
                        .HasColumnType("integer");

                    b.Property<string>("Match")
                        .HasColumnType("text");

                    b.Property<int>("MatchingAlgorithm")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Owner")
                        .HasColumnType("integer");

                    b.Property<string>("Slug")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LastCorrespondentsId")
                        .IsUnique();

                    b.HasIndex("Owner");

                    b.ToTable("Correspondents");
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Added")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Archive_Serial_Number")
                        .HasColumnType("text");

                    b.Property<string>("Archived_File_Name")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CorrespondentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte[]>("Data")
                        .HasColumnType("bytea");

                    b.Property<int?>("DocumentTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Original_File_Name")
                        .HasColumnType("text");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<int?>("Storage_Path")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("User_Can_Change")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("CorrespondentId");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.DocumentTagMapping", b =>
                {
                    b.Property<int>("DocumentId")
                        .HasColumnType("integer");

                    b.Property<int>("TagId")
                        .HasColumnType("integer");

                    b.HasKey("DocumentId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("DocumentTagMapping");
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Document_Count")
                        .HasColumnType("integer");

                    b.Property<bool?>("IsInsensitive")
                        .HasColumnType("boolean");

                    b.Property<string>("Match")
                        .HasColumnType("text");

                    b.Property<int?>("MatchingAlgorithm")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Owner")
                        .HasColumnType("integer");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Owner");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.Group", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.GroupUserMapping", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("GroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupUserMappings");
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.Notes", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("DocumentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id", "DocumentId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.PermissionGroupMapping", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<string>("PermissionName")
                        .HasColumnType("text");

                    b.Property<int?>("GroupId1")
                        .HasColumnType("integer");

                    b.HasKey("GroupId", "PermissionName");

                    b.HasIndex("GroupId1");

                    b.HasIndex("PermissionName");

                    b.ToTable("PermissionGroupMappings");
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.PermissionName", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("PermissionNames");
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsInboxTag")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsInsensitive")
                        .HasColumnType("boolean");

                    b.Property<string>("Match")
                        .HasColumnType("text");

                    b.Property<int?>("MatchingAlgorithm")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<int[]>("Groups")
                        .HasColumnType("integer[]");

                    b.Property<string[]>("InheritedPermissions")
                        .HasColumnType("text[]");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsStaff")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSuperuser")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string[]>("UserPermissions")
                        .HasColumnType("text[]");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.Correspondents", b =>
                {
                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.Correspondents", "LastCorrespondents")
                        .WithOne()
                        .HasForeignKey("PaperlessRestService.BusinessLogic.Entities.Correspondents", "LastCorrespondentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("Owner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LastCorrespondents");
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.Document", b =>
                {
                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.Correspondents", "Correspondent")
                        .WithMany()
                        .HasForeignKey("CorrespondentId");

                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.DocumentType", "Document_Type")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId");

                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Correspondent");

                    b.Navigation("Document_Type");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.DocumentTagMapping", b =>
                {
                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.Document", null)
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.DocumentType", b =>
                {
                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("Owner");
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.GroupUserMapping", b =>
                {
                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.Notes", b =>
                {
                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.Document", null)
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.Document", null)
                        .WithMany("notes")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.PermissionGroupMapping", b =>
                {
                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.Group", null)
                        .WithMany("Permissions")
                        .HasForeignKey("GroupId1");

                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.PermissionName", null)
                        .WithMany()
                        .HasForeignKey("PermissionName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.Tag", b =>
                {
                    b.HasOne("PaperlessRestService.BusinessLogic.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.Document", b =>
                {
                    b.Navigation("notes");
                });

            modelBuilder.Entity("PaperlessRestService.BusinessLogic.Entities.Group", b =>
                {
                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
