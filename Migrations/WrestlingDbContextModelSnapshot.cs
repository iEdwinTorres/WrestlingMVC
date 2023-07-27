﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WrestlingMVC.Data;

#nullable disable

namespace WrestlingMVC.Migrations
{
    [DbContext(typeof(WrestlingDbContext))]
    partial class WrestlingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WrestlingMVC.Data.Championship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Defunct")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Established")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PromotionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Retired")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PromotionId");

                    b.ToTable("Championships");
                });

            modelBuilder.Entity("WrestlingMVC.Data.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Defunct")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Established")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Shuttered")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("WrestlingMVC.Data.Reign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Championship")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReignDateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReignDateStart")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Wrestler")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Championship");

                    b.HasIndex("Wrestler");

                    b.ToTable("Reigns");
                });

            modelBuilder.Entity("WrestlingMVC.Data.Wrestler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Picture")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Retired")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Wrestlers");
                });

            modelBuilder.Entity("WrestlingMVC.Data.Championship", b =>
                {
                    b.HasOne("WrestlingMVC.Data.Promotion", "Promotion")
                        .WithMany()
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("WrestlingMVC.Data.Reign", b =>
                {
                    b.HasOne("WrestlingMVC.Data.Championship", "ChampionshipId")
                        .WithMany()
                        .HasForeignKey("Championship");

                    b.HasOne("WrestlingMVC.Data.Wrestler", "WrestlerId")
                        .WithMany()
                        .HasForeignKey("Wrestler");

                    b.Navigation("ChampionshipId");

                    b.Navigation("WrestlerId");
                });
#pragma warning restore 612, 618
        }
    }
}
