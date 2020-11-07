﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartDataInitiative.Data.Context;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SmartDataInitiative.Data.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartDataInitiative.Business.Models.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<int>("FeedbackType")
                        .HasColumnType("int");

                    b.Property<Guid>("FieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("SmartDataInitiative.Business.Models.Field", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("SmartDataInitiative.Business.Models.Model", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<Guid>("ReportModelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReportModelId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("SmartDataInitiative.Business.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<DateTime>("FinalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InitialDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("SmartDataInitiative.Business.Models.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FinalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InitialDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ReportModelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReportModelId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("SmartDataInitiative.Business.Models.ReportModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ReportModels");
                });

            modelBuilder.Entity("SmartDataInitiative.Business.Models.Feedback", b =>
                {
                    b.HasOne("SmartDataInitiative.Business.Models.Field", "Field")
                        .WithMany()
                        .HasForeignKey("FieldId")
                        .IsRequired();
                });

            modelBuilder.Entity("SmartDataInitiative.Business.Models.Field", b =>
                {
                    b.HasOne("SmartDataInitiative.Business.Models.Project", "Project")
                        .WithMany("Fields")
                        .HasForeignKey("ProjectId")
                        .IsRequired();
                });

            modelBuilder.Entity("SmartDataInitiative.Business.Models.Model", b =>
                {
                    b.HasOne("SmartDataInitiative.Business.Models.ReportModel", "ReportModel")
                        .WithMany("Models")
                        .HasForeignKey("ReportModelId")
                        .IsRequired();
                });

            modelBuilder.Entity("SmartDataInitiative.Business.Models.Report", b =>
                {
                    b.HasOne("SmartDataInitiative.Business.Models.ReportModel", "ReportModel")
                        .WithMany()
                        .HasForeignKey("ReportModelId")
                        .IsRequired();
                });

            modelBuilder.Entity("SmartDataInitiative.Business.Models.ReportModel", b =>
                {
                    b.HasOne("SmartDataInitiative.Business.Models.Project", "Project")
                        .WithMany("ReportModels")
                        .HasForeignKey("ProjectId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
