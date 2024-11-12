﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.healthy.src.context;

#nullable disable

namespace api.healthy.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20241111025215_addddddd")]
    partial class addddddd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("api.healthy.src.components.diet.BodyInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<double>("Heigth")
                        .HasColumnType("REAL");

                    b.Property<double>("Weigth")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("BodyInformation");
                });

            modelBuilder.Entity("api.healthy.src.components.diet.DietModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("BMR")
                        .HasColumnType("REAL");

                    b.Property<Guid>("BodyInformationId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExerciseLevel")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("MacrosId")
                        .HasColumnType("TEXT");

                    b.Property<double>("MedianKcalLose")
                        .HasColumnType("REAL");

                    b.Property<double>("RecomendedKcalToEat")
                        .HasColumnType("REAL");

                    b.Property<long>("UserCpf")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BodyInformationId");

                    b.HasIndex("MacrosId");

                    b.HasIndex("UserCpf");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("api.healthy.src.components.diet.Macros", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("Calories")
                        .HasColumnType("REAL");

                    b.Property<double>("Carbs")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<double>("Fat")
                        .HasColumnType("REAL");

                    b.Property<double>("Protein")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Macros");
                });

            modelBuilder.Entity("api.healthy.src.components.users.UserModel", b =>
                {
                    b.Property<long>("Cpf")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<char>("Sex")
                        .HasColumnType("TEXT");

                    b.HasKey("Cpf");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("api.healthy.src.components.diet.DietModel", b =>
                {
                    b.HasOne("api.healthy.src.components.diet.BodyInformation", "BodyInformation")
                        .WithMany()
                        .HasForeignKey("BodyInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.healthy.src.components.diet.Macros", "Macros")
                        .WithMany()
                        .HasForeignKey("MacrosId");

                    b.HasOne("api.healthy.src.components.users.UserModel", "User")
                        .WithMany("Diets")
                        .HasForeignKey("UserCpf")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BodyInformation");

                    b.Navigation("Macros");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.healthy.src.components.users.UserModel", b =>
                {
                    b.Navigation("Diets");
                });
#pragma warning restore 612, 618
        }
    }
}
