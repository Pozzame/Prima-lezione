﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Prima_lezione.Migrations
{
    [DbContext(typeof(Model))]
    partial class ModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Partecipante", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Partecipanti", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Professionista", b =>
                {
                    b.HasBaseType("Partecipante");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.ToTable("Professionisti", (string)null);
                });

            modelBuilder.Entity("Professionista", b =>
                {
                    b.HasOne("Partecipante", null)
                        .WithOne()
                        .HasForeignKey("Professionista", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
