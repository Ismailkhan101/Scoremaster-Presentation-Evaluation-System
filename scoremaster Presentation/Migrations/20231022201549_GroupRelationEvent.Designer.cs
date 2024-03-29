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
    [Migration("20231022201549_GroupRelationEvent")]
    partial class GroupRelationEvent
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

            modelBuilder.Entity("scoremaster_Presentation.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"), 1L, 1);

                    b.Property<int>("CMSID")
                        .HasColumnType("int");

                    b.Property<string>("CoSupervisor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsersRegistrationId");

                    b.HasIndex("DepartmentId");

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

            modelBuilder.Entity("scoremaster_Presentation.Models.UsersRegistration", b =>
                {
                    b.HasOne("scoremaster_Presentation.Models.Department", "Department")
                        .WithMany("UsersRegistrations")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Department", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("UsersRegistrations");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.Event", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("scoremaster_Presentation.Models.UsersRegistration", b =>
                {
                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}
