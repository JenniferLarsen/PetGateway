﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetGateway.Models;

#nullable disable

namespace PetGateway.Migrations
{
    [DbContext(typeof(GatewayContext))]
    partial class GatewayContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PetGateway.Models.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OwnerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OwnerId");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            OwnerId = 1,
                            Address = "827 Cedar St",
                            City = "Webster City",
                            Email = "missamylmiles@gmail.com",
                            FirstName = "Amy",
                            LastName = "Miles",
                            PhoneNumber = "5155126039",
                            PostalCode = "50595",
                            State = "IA"
                        },
                        new
                        {
                            OwnerId = 2,
                            Address = "808 Georgia Ave",
                            City = "Palm Harbor",
                            Email = "traceydele@gmail.com",
                            FirstName = "Tracey",
                            LastName = "Larrison",
                            PhoneNumber = "5152057809",
                            PostalCode = "34683",
                            State = "FL"
                        });
                });

            modelBuilder.Entity("PetGateway.Models.Pet", b =>
                {
                    b.Property<int>("PetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PetId"));

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("PetAge")
                        .HasColumnType("int");

                    b.Property<string>("PetBreed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PetColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PetGender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PetType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PetWeight")
                        .HasColumnType("int");

                    b.Property<bool>("Spayed_Neutered")
                        .HasColumnType("bit");

                    b.HasKey("PetId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Pets");

                    b.HasData(
                        new
                        {
                            PetId = 1,
                            OwnerId = 1,
                            PetAge = 6,
                            PetBreed = "Yorkshire Terrier",
                            PetColor = "black and grey",
                            PetGender = "male",
                            PetName = "Very",
                            PetType = "canine",
                            PetWeight = 13,
                            Spayed_Neutered = true
                        },
                        new
                        {
                            PetId = 2,
                            OwnerId = 2,
                            PetAge = 10,
                            PetBreed = "Yorkshire Terrier",
                            PetColor = "black and grey",
                            PetGender = "male",
                            PetName = "Cooper",
                            PetType = "canine",
                            PetWeight = 11,
                            Spayed_Neutered = true
                        },
                        new
                        {
                            PetId = 3,
                            OwnerId = 2,
                            PetAge = 16,
                            PetBreed = "tabby",
                            PetColor = "grey",
                            PetGender = "female",
                            PetName = "Jasmine",
                            PetType = "feline",
                            PetWeight = 18,
                            Spayed_Neutered = true
                        });
                });

            modelBuilder.Entity("PetGateway.Models.Pet", b =>
                {
                    b.HasOne("PetGateway.Models.Owner", "Owner")
                        .WithMany("Pets")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("PetGateway.Models.Owner", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
