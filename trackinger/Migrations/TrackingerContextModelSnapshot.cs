﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using trackinger.Models;

namespace trackinger.Migrations
{
    [DbContext(typeof(TrackingerContext))]
    partial class TrackingerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("trackinger.Models.Bug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<int?>("CreatorId");

                    b.Property<string>("Description");

                    b.Property<int>("Priority");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Bug");
                });

            modelBuilder.Entity("trackinger.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AssigneeId");

                    b.Property<int>("BugId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("NotificationDate");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("BugId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("trackinger.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("trackinger.Models.Bug", b =>
                {
                    b.HasOne("trackinger.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");
                });

            modelBuilder.Entity("trackinger.Models.Notification", b =>
                {
                    b.HasOne("trackinger.Models.User", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

                    b.HasOne("trackinger.Models.Bug", "Bug")
                        .WithMany()
                        .HasForeignKey("BugId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
