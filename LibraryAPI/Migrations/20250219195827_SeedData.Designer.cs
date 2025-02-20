﻿// <auto-generated />
using System;
using LibraryAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryAPI.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20250219195827_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.20");

            modelBuilder.Entity("LibraryAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PublishedYear")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PublisherId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("books", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Robert C. Martin",
                            CategoryId = 1,
                            Isbn = "9780132350884",
                            PublishedYear = 2008,
                            PublisherId = 1,
                            Title = "Livre1"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Andrew Hunt",
                            CategoryId = 2,
                            Isbn = "9780201616224",
                            PublishedYear = 2020,
                            PublisherId = 2,
                            Title = "Livre 2"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Erich Gamma",
                            CategoryId = 3,
                            Isbn = "9780201633610",
                            PublishedYear = 2019,
                            PublisherId = 3,
                            Title = "Livre 3"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Martin Fowler",
                            CategoryId = 4,
                            Isbn = "9780201485677",
                            PublishedYear = 2018,
                            PublisherId = 4,
                            Title = "Livre 4"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Steve McConnell",
                            CategoryId = 5,
                            Isbn = "9780735619678",
                            PublishedYear = 2022,
                            PublisherId = 5,
                            Title = "Livre 5"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Steve McConnell 2",
                            CategoryId = 1,
                            Isbn = "9780735619679",
                            PublishedYear = 2022,
                            PublisherId = 1,
                            Title = "Livre 6"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Steve McConnell 3",
                            CategoryId = 2,
                            Isbn = "9780735619680",
                            PublishedYear = 2022,
                            PublisherId = 2,
                            Title = "Livre 7"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Steve McConnell 4",
                            CategoryId = 3,
                            Isbn = "9780735619681",
                            PublishedYear = 2022,
                            PublisherId = 3,
                            Title = "Livre 8"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Steve McConnell 5",
                            CategoryId = 4,
                            Isbn = "9780735619682",
                            PublishedYear = 2022,
                            PublisherId = 4,
                            Title = "Livre 9"
                        },
                        new
                        {
                            Id = 10,
                            Author = "Steve McConnell 6",
                            CategoryId = 5,
                            Isbn = "9780735619683",
                            PublishedYear = 2022,
                            PublisherId = 5,
                            Title = "Livre 10"
                        });
                });

            modelBuilder.Entity("LibraryAPI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Romantique"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Biographie"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Histoire"
                        });
                });

            modelBuilder.Entity("LibraryAPI.Models.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("BorrowerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("loans", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            BorrowDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BorrowerName = "Client 1",
                            ReturnDate = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            BorrowDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BorrowerName = "Client 2",
                            ReturnDate = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            BookId = 3,
                            BorrowDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BorrowerName = "Client 2",
                            ReturnDate = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            BookId = 4,
                            BorrowDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BorrowerName = "Client 3",
                            ReturnDate = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            BookId = 5,
                            BorrowDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BorrowerName = "Client 4",
                            ReturnDate = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("LibraryAPI.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FoundedYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("publishers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContactEmail = "johndoe@gmail.com",
                            FoundedYear = 2000,
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            ContactEmail = "thenry@gmail.com",
                            FoundedYear = 2005,
                            Name = "Thierry Henry corp"
                        },
                        new
                        {
                            Id = 3,
                            ContactEmail = "zzidane@gmail.com",
                            FoundedYear = 2010,
                            Name = "Zinédine Zidane le z la vraie librairie"
                        },
                        new
                        {
                            Id = 4,
                            ContactEmail = "creyel@gmail.com",
                            FoundedYear = 2015,
                            Name = "Colonel Reyel le flopesque libraire"
                        },
                        new
                        {
                            Id = 5,
                            ContactEmail = "renetaupe@gmail.com",
                            FoundedYear = 2020,
                            Name = "René la taupe le goat du livre"
                        });
                });

            modelBuilder.Entity("LibraryAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "client1@gmail.com",
                            Name = "Client 1",
                            Role = "Lecteur"
                        },
                        new
                        {
                            Id = 2,
                            Email = "client2@gmail.com",
                            Name = "Client 2",
                            Role = "Lecteur"
                        },
                        new
                        {
                            Id = 3,
                            Email = "client3@gmail.com",
                            Name = "Client 3",
                            Role = "Lecteur"
                        },
                        new
                        {
                            Id = 4,
                            Email = "client4@gmail.com",
                            Name = "Client 4",
                            Role = "Lecteur"
                        },
                        new
                        {
                            Id = 5,
                            Email = "admin@gmail.com",
                            Name = "Administrateur 1",
                            Role = "Administrateur"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
