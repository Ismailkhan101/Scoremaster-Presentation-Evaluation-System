﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using scoremaster_Presentation.Data;

#nullable disable

namespace scoremaster_Presentation.Migrations
{
    [DbContext(typeof(ScoreMasterDbContext))]
    [Migration("20231030044855_DropUserper")]
    partial class DropUserper
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("scoremaster_Presentation.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupIndividual")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("NoOfExaminers")
                        .HasColumnType("int");

                    b.Property<int>("NoOfGroups")
                        .HasColumnType("int");

                    b.Property<string>("Organizer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.ExternalUserscs", b =>
                {
                    b.Property<int>("ExternalUserscsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExternalUserscsId"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ROleId")
                        .HasColumnType("int");

                    b.HasKey("ExternalUserscsId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EventId");

                    b.HasIndex("ROleId");

                    b.ToTable("ExternalUserscs");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"), 1L, 1);

                    b.Property<string>("CoSupervisor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Supervisor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsersRegistrationId")
                        .HasColumnType("int");

                    b.HasKey("GroupId");

                    b.HasIndex("EventId");

                    b.HasIndex("UsersRegistrationId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Marks", b =>
                {
                    b.Property<int>("MarksId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarksId"), 1L, 1);

                    b.Property<int?>("ExternalUserscsId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int?>("MemberDataId")
                        .HasColumnType("int");

                    b.Property<string>("TotalMarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsersRegistrationId")
                        .HasColumnType("int");

                    b.HasKey("MarksId");

                    b.HasIndex("ExternalUserscsId");

                    b.HasIndex("MemberDataId");

                    b.HasIndex("UsersRegistrationId");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.MemberData", b =>
                {
                    b.Property<int>("MemberDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberDataId"), 1L, 1);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MemberCMSID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberDataId");

                    b.HasIndex("GroupId");

                    b.ToTable("MemberDatas");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PesmissionDbName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PesmissionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Role", b =>
                {
                    b.Property<int>("ROleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ROleId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ROleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.UserPermision", b =>
                {
                    b.Property<int>("UserPermisionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserPermisionId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserPermisionId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserPermisions");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.UsersRegistration", b =>
                {
                    b.Property<int>("UsersRegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsersRegistrationId"), 1L, 1);

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ROleId")
                        .HasColumnType("int");

                    b.HasKey("UsersRegistrationId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ROleId");

                    b.ToTable("UsersRegistrations");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Event", b =>
                {
                    b.HasOne("scoremaster_Presentation.Models.Department", "Department")
                        .WithMany("Events")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.ExternalUserscs", b =>
                {
                    b.HasOne("scoremaster_Presentation.Models.Department", "Department")
                        .WithMany("ExternalUsers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("scoremaster_Presentation.Models.Event", "Event")
                        .WithMany("ExternalUsers")
                        .HasForeignKey("EventId");

                    b.HasOne("scoremaster_Presentation.Models.Role", null)
                        .WithMany("ExternalUserscs")
                        .HasForeignKey("ROleId");

                    b.Navigation("Department");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Group", b =>
                {
                    b.HasOne("scoremaster_Presentation.Models.Event", "Events")
                        .WithMany("Groups")
                        .HasForeignKey("EventId");

                    b.HasOne("scoremaster_Presentation.Models.UsersRegistration", "UsersRegistration")
                        .WithMany("Groups")
                        .HasForeignKey("UsersRegistrationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Events");

                    b.Navigation("UsersRegistration");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Marks", b =>
                {
                    b.HasOne("scoremaster_Presentation.Models.ExternalUserscs", "ExternalUserscs")
                        .WithMany("Marks")
                        .HasForeignKey("ExternalUserscsId");

                    b.HasOne("scoremaster_Presentation.Models.MemberData", "MemberData")
                        .WithMany("Marks")
                        .HasForeignKey("MemberDataId");

                    b.HasOne("scoremaster_Presentation.Models.UsersRegistration", "UsersRegistration")
                        .WithMany("Marks")
                        .HasForeignKey("UsersRegistrationId");

                    b.Navigation("ExternalUserscs");

                    b.Navigation("MemberData");

                    b.Navigation("UsersRegistration");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.MemberData", b =>
                {
                    b.HasOne("scoremaster_Presentation.Models.Group", "Groups")
                        .WithMany("MemberDatas")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Groups");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.UserPermision", b =>
                {
                    b.HasOne("scoremaster_Presentation.Models.Permission", "Permission")
                        .WithMany("UserPermisions")
                        .HasForeignKey("PermissionId");

                    b.HasOne("scoremaster_Presentation.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.UsersRegistration", b =>
                {
                    b.HasOne("scoremaster_Presentation.Models.Department", "Department")
                        .WithMany("UsersRegistrations")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("scoremaster_Presentation.Models.Role", "Role")
                        .WithMany("UsersRegistrations")
                        .HasForeignKey("ROleId");

                    b.Navigation("Department");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Department", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("ExternalUsers");

                    b.Navigation("UsersRegistrations");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Event", b =>
                {
                    b.Navigation("ExternalUsers");

                    b.Navigation("Groups");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.ExternalUserscs", b =>
                {
                    b.Navigation("Marks");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Group", b =>
                {
                    b.Navigation("MemberDatas");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.MemberData", b =>
                {
                    b.Navigation("Marks");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Permission", b =>
                {
                    b.Navigation("UserPermisions");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Role", b =>
                {
                    b.Navigation("ExternalUserscs");

                    b.Navigation("UsersRegistrations");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.UsersRegistration", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Marks");
                });
#pragma warning restore 612, 618
        }
    }
}