﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using ProEventos.Persistence.Contexto;

#nullable disable

namespace ProEventos.Persistence.Migrations
{
    [DbContext(typeof(ProEventosContext))]
    [Migration("20221017150807_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("ProEventos.Domain.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataEvento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("QtdPessoas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tema")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("ProEventos.Domain.Lote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Preco")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("Lotes");
                });

            modelBuilder.Entity("ProEventos.Domain.Palestrante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagemURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MiniCurriculo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Palestrantes");
                });

            modelBuilder.Entity("ProEventos.Domain.PalestranteEvento", b =>
                {
                    b.Property<int>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PalestranteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventoId", "PalestranteId");

                    b.HasIndex("PalestranteId");

                    b.ToTable("PalestranteEventos");
                });

            modelBuilder.Entity("ProEventos.Domain.RedeSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PalestranteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("PalestranteId");

                    b.ToTable("RedeSociais");
                });

            modelBuilder.Entity("ProEventos.Domain.Lote", b =>
                {
                    b.HasOne("ProEventos.Domain.Evento", "Evento")
                        .WithMany("Lotes")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("ProEventos.Domain.PalestranteEvento", b =>
                {
                    b.HasOne("ProEventos.Domain.Evento", "Evento")
                        .WithMany("PalestrantesEventos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProEventos.Domain.Palestrante", "Palestrante")
                        .WithMany("PalestrantesEventos")
                        .HasForeignKey("PalestranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Palestrante");
                });

            modelBuilder.Entity("ProEventos.Domain.RedeSocial", b =>
                {
                    b.HasOne("ProEventos.Domain.Evento", "Evento")
                        .WithMany("RedesSociais")
                        .HasForeignKey("EventoId");

                    b.HasOne("ProEventos.Domain.Palestrante", "Palestrante")
                        .WithMany("RedeSociais")
                        .HasForeignKey("PalestranteId");

                    b.Navigation("Evento");

                    b.Navigation("Palestrante");
                });

            modelBuilder.Entity("ProEventos.Domain.Evento", b =>
                {
                    b.Navigation("Lotes");

                    b.Navigation("PalestrantesEventos");

                    b.Navigation("RedesSociais");
                });

            modelBuilder.Entity("ProEventos.Domain.Palestrante", b =>
                {
                    b.Navigation("PalestrantesEventos");

                    b.Navigation("RedeSociais");
                });
#pragma warning restore 612, 618
        }
    }
}