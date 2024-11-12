﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalk.API.Data;

#nullable disable

namespace NZWalk.API.Migrations
{
    [DbContext(typeof(NZWalkDbContext))]
    partial class NZWalkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalk.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0e2f202e-0af6-4c91-9139-9153b950bbfa"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("0eedf313-3fbe-44b3-ab3a-74a4702436fd"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("17403890-c4f4-4cd4-81a9-f552524f2ae7"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalk.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("647164aa-27d7-4c84-81fc-be52753c24d8"),
                            Code = "AKL",
                            RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1\"\n                },",
                            RegionName = "Auckland"
                        },
                        new
                        {
                            Id = new Guid("95cb4e28-78cb-4e71-b50f-df4fb635e55a"),
                            Code = "NTL",
                            RegionImageUrl = "",
                            RegionName = "NorthLan"
                        },
                        new
                        {
                            Id = new Guid("d90f7a7b-dc1a-44e3-a5fe-ae22929aadf5"),
                            Code = "AKL",
                            RegionImageUrl = "",
                            RegionName = "Bay of Plenty"
                        },
                        new
                        {
                            Id = new Guid("94f069ad-79fe-4f89-bb95-322ab9d93dba"),
                            Code = "NSN",
                            RegionImageUrl = "",
                            RegionName = "Nelson"
                        },
                        new
                        {
                            Id = new Guid("4f4bcee7-d3bd-48bb-961b-7c7836bf8b96"),
                            Code = "STL",
                            RegionImageUrl = "",
                            RegionName = "SouthLand"
                        },
                        new
                        {
                            Id = new Guid("54571568-6cf0-4e40-a638-e4457f61bcfa"),
                            Code = "WGN",
                            RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            RegionName = "Wellington"
                        });
                });

            modelBuilder.Entity("NZWalk.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("walks");
                });

            modelBuilder.Entity("NZWalk.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("NZWalk.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalk.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
