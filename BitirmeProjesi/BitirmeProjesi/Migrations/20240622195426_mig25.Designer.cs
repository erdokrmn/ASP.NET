﻿// <auto-generated />
using System;
using BitirmeProjesi.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BitirmeProjesi.Migrations
{
    [DbContext(typeof(BitirmeProjesiDbContext))]
    [Migration("20240622195426_mig25")]
    partial class mig25
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BitirmeProjesi.Models.FingerPrintData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("IOZaman")
                        .HasColumnType("datetime2");

                    b.Property<string>("InOut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KullanıcıNo")
                        .HasColumnType("int");

                    b.Property<string>("Mode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PersonelId");

                    b.ToTable("FingerPrintDatas");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Firma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirmaAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Iban")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelofonNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("İlgiliKisi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Firmalar");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.GC", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CS")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("GS")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PersonelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonelId");

                    b.ToTable("GCs");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Gelir", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FaturaKesilenAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FaturaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kesinti")
                        .HasColumnType("int");

                    b.Property<int>("Miktar")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ÖdenmeTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Gelirler");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Gemi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GemiAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GemiTipi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GemiyeBaslamaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("TahminiBitirmeSuresi")
                        .HasColumnType("int");

                    b.Property<string>("TershaneAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gemiler");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.GemiEnvanteri", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Durum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GemiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParcaAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParcaMiktarı")
                        .HasColumnType("int");

                    b.Property<Guid>("PersonelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("Zone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GemiId");

                    b.ToTable("GemiEnvanterleri");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Maas", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DegerMaasi")
                        .HasColumnType("int");

                    b.Property<DateTime>("MaasTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaasTutarı")
                        .HasColumnType("int");

                    b.Property<int>("MesaiMaasi")
                        .HasColumnType("int");

                    b.Property<int>("NormalMaas")
                        .HasColumnType("int");

                    b.Property<int>("OzelGunMaasi")
                        .HasColumnType("int");

                    b.Property<Guid>("PersonelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PersonelId");

                    b.ToTable("Maaslar");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Malzeme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MalzemeAdet")
                        .HasColumnType("int");

                    b.Property<string>("MalzemeAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MalzemeAlınısTarih")
                        .HasColumnType("datetime2");

                    b.Property<int>("MalzemeFiyatı")
                        .HasColumnType("int");

                    b.Property<string>("MalzemeKodu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MalzemeSkt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MalzemeTürü")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ÜrünDurumu")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Malzemeler");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Masraf", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FirmaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MasrafAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasrafTipi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MasrafTutarı")
                        .HasColumnType("int");

                    b.Property<DateTime>("ÖdemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ÖdenenTarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FirmaId");

                    b.ToTable("Masraflar");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.OzelGun", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OzelGunler");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Personel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcilDurumdaUlaşılacakKişiNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CalısmaDurumu")
                        .HasColumnType("bit");

                    b.Property<string>("CalıstıgıTershane")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Cinsiyet")
                        .HasColumnType("bit");

                    b.Property<string>("DoğumYeri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoğumYılı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EDevletŞifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Il")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ilce")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IseBaslamaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IstenAyrılmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("KanGrubu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Maas")
                        .HasColumnType("int");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yetki")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personeller");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Tevzi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CalısmaSaati")
                        .HasColumnType("int");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<int>("MesaiSaati")
                        .HasColumnType("int");

                    b.Property<Guid>("PersonelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TevziTarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonelId");

                    b.ToTable("Tevziler");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsLoggedIn")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Zimmet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MalzemeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("VerilmeTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MalzemeId");

                    b.HasIndex("PersonelId");

                    b.ToTable("Zimmetler");
                });

            modelBuilder.Entity("GemiEnvanteriPersonel", b =>
                {
                    b.Property<Guid>("GemiEnvanterleriId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GemiEnvanterleriId", "PersonelId");

                    b.HasIndex("PersonelId");

                    b.ToTable("GemiEnvanteriPersonel");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.FingerPrintData", b =>
                {
                    b.HasOne("BitirmeProjesi.Models.Personel", "Personel")
                        .WithMany("FingerPrintDatas")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.GC", b =>
                {
                    b.HasOne("BitirmeProjesi.Models.Personel", "PersonelAd")
                        .WithMany("GCler")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonelAd");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.GemiEnvanteri", b =>
                {
                    b.HasOne("BitirmeProjesi.Models.Gemi", "GemiAdı")
                        .WithMany("gemiEnvanterileri")
                        .HasForeignKey("GemiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GemiAdı");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Maas", b =>
                {
                    b.HasOne("BitirmeProjesi.Models.Personel", "Personel")
                        .WithMany("Maaslar")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Masraf", b =>
                {
                    b.HasOne("BitirmeProjesi.Models.Firma", "Firma")
                        .WithMany("Masraflar")
                        .HasForeignKey("FirmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Firma");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Tevzi", b =>
                {
                    b.HasOne("BitirmeProjesi.Models.Personel", "Personel")
                        .WithMany("Tevziler")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Zimmet", b =>
                {
                    b.HasOne("BitirmeProjesi.Models.Malzeme", "ZimmetEdilenMalzeme")
                        .WithMany("ZimmetEdilenMalzemeler")
                        .HasForeignKey("MalzemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BitirmeProjesi.Models.Personel", "ZimmetEdilenKisi")
                        .WithMany("ZimmetEdilenPersoneller")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ZimmetEdilenKisi");

                    b.Navigation("ZimmetEdilenMalzeme");
                });

            modelBuilder.Entity("GemiEnvanteriPersonel", b =>
                {
                    b.HasOne("BitirmeProjesi.Models.GemiEnvanteri", null)
                        .WithMany()
                        .HasForeignKey("GemiEnvanterleriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BitirmeProjesi.Models.Personel", null)
                        .WithMany()
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Firma", b =>
                {
                    b.Navigation("Masraflar");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Gemi", b =>
                {
                    b.Navigation("gemiEnvanterileri");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Malzeme", b =>
                {
                    b.Navigation("ZimmetEdilenMalzemeler");
                });

            modelBuilder.Entity("BitirmeProjesi.Models.Personel", b =>
                {
                    b.Navigation("FingerPrintDatas");

                    b.Navigation("GCler");

                    b.Navigation("Maaslar");

                    b.Navigation("Tevziler");

                    b.Navigation("ZimmetEdilenPersoneller");
                });
#pragma warning restore 612, 618
        }
    }
}