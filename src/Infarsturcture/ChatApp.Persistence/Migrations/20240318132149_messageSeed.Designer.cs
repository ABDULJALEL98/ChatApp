﻿// <auto-generated />
using System;
using ChatApp.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChatApp.Persistence.Migrations
{
    [DbContext(typeof(AppliactionDbContext))]
    [Migration("20240318132149_messageSeed")]
    partial class messageSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChatApp.Domain.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MessageSend")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("RecipientDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<string>("RecipientUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SenderDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("SenderUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "test-one",
                            IsActive = true,
                            MessageSend = new DateTime(2024, 3, 18, 13, 21, 49, 397, DateTimeKind.Utc).AddTicks(9490),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RecipientDeleted = false,
                            RecipientId = 1,
                            RecipientUserName = "ahmed",
                            SenderDeleted = false,
                            SenderId = 1,
                            SenderUserName = "ali"
                        },
                        new
                        {
                            Id = 2,
                            Content = "test-two",
                            IsActive = true,
                            MessageSend = new DateTime(2024, 3, 18, 13, 21, 49, 397, DateTimeKind.Utc).AddTicks(9497),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RecipientDeleted = false,
                            RecipientId = 1,
                            RecipientUserName = "ahmed",
                            SenderDeleted = false,
                            SenderId = 1,
                            SenderUserName = "mohamad"
                        },
                        new
                        {
                            Id = 3,
                            Content = "test-two",
                            IsActive = true,
                            MessageSend = new DateTime(2024, 3, 18, 13, 21, 49, 397, DateTimeKind.Utc).AddTicks(9500),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RecipientDeleted = false,
                            RecipientId = 1,
                            RecipientUserName = "ahmed",
                            SenderDeleted = false,
                            SenderId = 1,
                            SenderUserName = "basem"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
