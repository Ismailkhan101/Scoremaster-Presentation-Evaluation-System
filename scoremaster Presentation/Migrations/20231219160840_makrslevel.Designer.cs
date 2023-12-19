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
    [Migration("20231219160840_makrslevel")]
    partial class makrslevel
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

            modelBuilder.Entity("scoremaster_Presentation.Models.EvaluationCriteria", b =>
                {
                    b.Property<int>("EvaluationCriteriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EvaluationCriteriaId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProgramlearingOutcomesId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalMarks")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EvaluationCriteriaId");

                    b.HasIndex("ProgramlearingOutcomesId");

                    b.ToTable("EvaluationCriteria");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.EvaluationLevels", b =>
                {
                    b.Property<int>("EvaluationLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EvaluationLevelId"), 1L, 1);

                    b.Property<string>("AboveAverae")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BelowAverae")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EvaluationCriteriaId")
                        .HasColumnType("int");

                    b.Property<string>("Excellent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Isactive")
                        .HasColumnType("bit");

                    b.Property<string>("Poor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EvaluationLevelId");

                    b.HasIndex("EvaluationCriteriaId");

                    b.ToTable("EvaluationLevels");
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

                    b.Property<int?>("RubricCreateId")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RubricCreateId");

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

                    b.Property<int?>("RubricCreateId")
                        .HasColumnType("int");

                    b.HasKey("ExternalUserscsId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EventId");

                    b.HasIndex("ROleId");

                    b.HasIndex("RubricCreateId");

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

                    b.Property<int?>("EvaluationLevelId")
                        .HasColumnType("int");

                    b.Property<int>("EvaluationLevelsEvaluationLevelId")
                        .HasColumnType("int");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

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

                    b.HasIndex("EvaluationLevelsEvaluationLevelId");

                    b.HasIndex("EventId");

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

            modelBuilder.Entity("scoremaster_Presentation.Models.ProgramlearingOutcome", b =>
                {
                    b.Property<int>("ProgramlearingOutcomesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgramlearingOutcomesId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RubricCreateId")
                        .HasColumnType("int");

                    b.HasKey("ProgramlearingOutcomesId");

                    b.HasIndex("RubricCreateId");

                    b.ToTable("ProgramlearingOutcomes");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Roles", b =>
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

            modelBuilder.Entity("scoremaster_Presentation.Models.RubricCreate", b =>
                {
                    b.Property<int>("RubricCreateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RubricCreateId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Isactive")
                        .HasColumnType("bit");

                    b.Property<string>("RubricName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RubricCreateId");

                    b.ToTable("RubricCreates");
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

            modelBuilder.Entity("scoremaster_Presentation.Models.EvaluationCriteria", b =>
                {
                    b.HasOne("scoremaster_Presentation.Models.ProgramlearingOutcome", "ProgramlearingOutcomes")
                        .WithMany("EvaluationCriterias")
                        .HasForeignKey("ProgramlearingOutcomesId");

                    b.Navigation("ProgramlearingOutcomes");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.EvaluationLevels", b =>
                {
                    b.HasOne("scoremaster_Presentation.Models.EvaluationCriteria", "EvaluationCriterias")
                        .WithMany("EvaluationLevels")
                        .HasForeignKey("EvaluationCriteriaId");

                    b.Navigation("EvaluationCriterias");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Event", b =>
                {
                    b.HasOne("scoremaster_Presentation.Models.Department", "Department")
                        .WithMany("Events")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("scoremaster_Presentation.Models.RubricCreate", "RubricCreate")
                        .WithMany("Events")
                        .HasForeignKey("RubricCreateId");

                    b.Navigation("Department");

                    b.Navigation("RubricCreate");
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

                    b.HasOne("scoremaster_Presentation.Models.Roles", "Role")
                        .WithMany("ExternalUserscs")
                        .HasForeignKey("ROleId");

                    b.HasOne("scoremaster_Presentation.Models.RubricCreate", "RubricCreate")
                        .WithMany("ExternalUserscs")
                        .HasForeignKey("RubricCreateId");

                    b.Navigation("Department");

                    b.Navigation("Event");

                    b.Navigation("Role");

                    b.Navigation("RubricCreate");
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
                    b.HasOne("scoremaster_Presentation.Models.EvaluationLevels", "EvaluationLevels")
                        .WithMany("Marks")
                        .HasForeignKey("EvaluationLevelsEvaluationLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("scoremaster_Presentation.Models.Event", "Event")
                        .WithMany("Marks")
                        .HasForeignKey("EventId");

                    b.HasOne("scoremaster_Presentation.Models.ExternalUserscs", "ExternalUserscs")
                        .WithMany("Marks")
                        .HasForeignKey("ExternalUserscsId");

                    b.HasOne("scoremaster_Presentation.Models.MemberData", "MemberData")
                        .WithMany("Marks")
                        .HasForeignKey("MemberDataId");

                    b.HasOne("scoremaster_Presentation.Models.UsersRegistration", "UsersRegistration")
                        .WithMany("Marks")
                        .HasForeignKey("UsersRegistrationId");

                    b.Navigation("EvaluationLevels");

                    b.Navigation("Event");

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

            modelBuilder.Entity("scoremaster_Presentation.Models.ProgramlearingOutcome", b =>
                {
                    b.HasOne("scoremaster_Presentation.Models.RubricCreate", "RubricCreate")
                        .WithMany("programlearingOutcomes")
                        .HasForeignKey("RubricCreateId");

                    b.Navigation("RubricCreate");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.UserPermision", b =>
                {
                    b.HasOne("scoremaster_Presentation.Models.Permission", "Permission")
                        .WithMany("UserPermisions")
                        .HasForeignKey("PermissionId");

                    b.HasOne("scoremaster_Presentation.Models.Roles", "Role")
                        .WithMany("UserPermisions")
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

                    b.HasOne("scoremaster_Presentation.Models.Roles", "Role")
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

            modelBuilder.Entity("scoremaster_Presentation.Models.EvaluationCriteria", b =>
                {
                    b.Navigation("EvaluationLevels");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.EvaluationLevels", b =>
                {
                    b.Navigation("Marks");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Event", b =>
                {
                    b.Navigation("ExternalUsers");

                    b.Navigation("Groups");

                    b.Navigation("Marks");
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

            modelBuilder.Entity("scoremaster_Presentation.Models.ProgramlearingOutcome", b =>
                {
                    b.Navigation("EvaluationCriterias");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Roles", b =>
                {
                    b.Navigation("ExternalUserscs");

                    b.Navigation("UserPermisions");

                    b.Navigation("UsersRegistrations");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.RubricCreate", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("ExternalUserscs");

                    b.Navigation("programlearingOutcomes");
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
