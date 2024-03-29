﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ODataSample.Library.Database;

#nullable disable

namespace ODataSample.Library.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240104203050_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_unicode_ci")
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("ODataSample.Library.Models.Calendar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Calendars", (string)null);
                });

            modelBuilder.Entity("ODataSample.Library.Models.Meeting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CalendarId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasMaxLength(800)
                        .HasColumnType("varchar(800)");

                    b.Property<uint>("Duration")
                        .HasColumnType("int unsigned");

                    b.Property<DateTime>("StartAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.ToTable("Meetings", (string)null);
                });

            modelBuilder.Entity("ODataSample.Library.Models.Reminder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MeetingId")
                        .HasColumnType("char(36)");

                    b.Property<uint>("RemindBefore")
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.ToTable("Reminders", (string)null);
                });

            modelBuilder.Entity("ODataSample.Library.Models.Meeting", b =>
                {
                    b.HasOne("ODataSample.Library.Models.Calendar", "Calendar")
                        .WithMany("Meetings")
                        .HasForeignKey("CalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calendar");
                });

            modelBuilder.Entity("ODataSample.Library.Models.Reminder", b =>
                {
                    b.HasOne("ODataSample.Library.Models.Meeting", "Meeting")
                        .WithMany("Reminders")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meeting");
                });

            modelBuilder.Entity("ODataSample.Library.Models.Calendar", b =>
                {
                    b.Navigation("Meetings");
                });

            modelBuilder.Entity("ODataSample.Library.Models.Meeting", b =>
                {
                    b.Navigation("Reminders");
                });
#pragma warning restore 612, 618
        }
    }
}
