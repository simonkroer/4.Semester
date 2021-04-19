﻿// <auto-generated />
using System;
using BirthClinic.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BirthClinic.Migrations
{
    [DbContext(typeof(BirthClinicContext))]
    partial class BirthClinicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BirthClinic.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FatherPersonId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MotherPersonId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId1")
                        .HasColumnType("int");

                    b.Property<string>("Relation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("FatherPersonId")
                        .IsUnique()
                        .HasFilter("[FatherPersonId] IS NOT NULL");

                    b.HasIndex("MotherPersonId")
                        .IsUnique()
                        .HasFilter("[MotherPersonId] IS NOT NULL");

                    b.HasIndex("PersonId1");

                    b.HasIndex("ReservationId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("BirthClinic.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChildPersonId")
                        .HasColumnType("int");

                    b.Property<int?>("FatherPersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MotherPersonId")
                        .HasColumnType("int");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("ReservationId");

                    b.HasIndex("ChildPersonId");

                    b.HasIndex("FatherPersonId");

                    b.HasIndex("MotherPersonId");

                    b.HasIndex("RoomId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("BirthClinic.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("BirthClinic.Models.Person", b =>
                {
                    b.HasOne("BirthClinic.Models.Person", "Father")
                        .WithOne()
                        .HasForeignKey("BirthClinic.Models.Person", "FatherPersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BirthClinic.Models.Person", "Mother")
                        .WithOne()
                        .HasForeignKey("BirthClinic.Models.Person", "MotherPersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BirthClinic.Models.Person", null)
                        .WithMany("Relatives")
                        .HasForeignKey("PersonId1");

                    b.HasOne("BirthClinic.Models.Reservation", null)
                        .WithMany("Clinicians")
                        .HasForeignKey("ReservationId");

                    b.Navigation("Father");

                    b.Navigation("Mother");
                });

            modelBuilder.Entity("BirthClinic.Models.Reservation", b =>
                {
                    b.HasOne("BirthClinic.Models.Person", "Child")
                        .WithMany()
                        .HasForeignKey("ChildPersonId");

                    b.HasOne("BirthClinic.Models.Person", "Father")
                        .WithMany()
                        .HasForeignKey("FatherPersonId");

                    b.HasOne("BirthClinic.Models.Person", "Mother")
                        .WithMany()
                        .HasForeignKey("MotherPersonId");

                    b.HasOne("BirthClinic.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.Navigation("Child");

                    b.Navigation("Father");

                    b.Navigation("Mother");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("BirthClinic.Models.Person", b =>
                {
                    b.Navigation("Relatives");
                });

            modelBuilder.Entity("BirthClinic.Models.Reservation", b =>
                {
                    b.Navigation("Clinicians");
                });
#pragma warning restore 612, 618
        }
    }
}
