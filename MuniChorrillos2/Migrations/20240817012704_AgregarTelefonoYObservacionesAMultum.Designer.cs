﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MuniChorrillos2.Models;

#nullable disable

namespace MuniChorrillos2.Migrations
{
    [DbContext(typeof(Bdmultas2Context))]
    [Migration("20240817012704_AgregarTelefonoYObservacionesAMultum")]
    partial class AgregarTelefonoYObservacionesAMultum
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MuniChorrillos2.Models.Area", b =>
                {
                    b.Property<int>("IdArea")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Area");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArea"));

                    b.Property<string>("NomArea")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nom_Area");

                    b.HasKey("IdArea")
                        .HasName("PK__Area__9C42D7FECE9A3E02");

                    b.ToTable("Area", (string)null);
                });

            modelBuilder.Entity("MuniChorrillos2.Models.CabComprobante", b =>
                {
                    b.Property<int>("IdCabeceraC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_CabeceraC");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCabeceraC"));

                    b.Property<string>("Entidad")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("date");

                    b.Property<TimeSpan?>("Hora")
                        .HasColumnType("time");

                    b.Property<string>("MedioPago")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Tcomprobante")
                        .HasColumnType("int")
                        .HasColumnName("TComprobante");

                    b.HasKey("IdCabeceraC")
                        .HasName("PK__CabCompr__F4C67864F74B4D75");

                    b.ToTable("CabComprobante", (string)null);
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Comprobante", b =>
                {
                    b.Property<int>("IdComprobante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Comprobante");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdComprobante"));

                    b.Property<int>("IdCabeceraC")
                        .HasColumnType("int")
                        .HasColumnName("Id_CabeceraC");

                    b.Property<int>("IdDetalleC")
                        .HasColumnType("int")
                        .HasColumnName("Id_DetalleC");

                    b.Property<int>("IdMulta")
                        .HasColumnType("int")
                        .HasColumnName("Id_Multa");

                    b.HasKey("IdComprobante")
                        .HasName("PK__Comproba__BCCA7AF13513C45F");

                    b.HasIndex("IdCabeceraC");

                    b.HasIndex("IdDetalleC");

                    b.ToTable("Comprobante", (string)null);
                });

            modelBuilder.Entity("MuniChorrillos2.Models.ControlVehicular", b =>
                {
                    b.Property<int>("IdControl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdControl"));

                    b.Property<DateTime?>("Dia")
                        .HasColumnType("date");

                    b.Property<TimeSpan?>("Hingreso")
                        .HasColumnType("time")
                        .HasColumnName("HIngreso");

                    b.Property<TimeSpan?>("Hsalida")
                        .HasColumnType("time")
                        .HasColumnName("HSalida");

                    b.Property<string>("Placa")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)");

                    b.HasKey("IdControl")
                        .HasName("PK__ControlV__2537521F63611CEF");

                    b.ToTable("ControlVehicular", (string)null);
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Deposito", b =>
                {
                    b.Property<int>("IdDeposito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Deposito");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDeposito"));

                    b.Property<string>("Direccion")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdPersonal")
                        .HasColumnType("int")
                        .HasColumnName("Id_Personal");

                    b.Property<string>("NomDeposito")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("IdDeposito")
                        .HasName("PK__Deposito__C363AF7261E869D6");

                    b.HasIndex("IdPersonal");

                    b.ToTable("Deposito", (string)null);
                });

            modelBuilder.Entity("MuniChorrillos2.Models.DetComprobante", b =>
                {
                    b.Property<int>("IdDetalleC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_DetalleC");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleC"));

                    b.Property<double?>("Subtotal")
                        .HasColumnType("float");

                    b.Property<double?>("Total")
                        .HasColumnType("float");

                    b.Property<double?>("Vuelto")
                        .HasColumnType("float");

                    b.HasKey("IdDetalleC")
                        .HasName("PK__DetCompr__8498178E926D57F6");

                    b.ToTable("DetComprobante", (string)null);
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Empleado");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpleado"));

                    b.Property<byte?>("Activo")
                        .HasColumnType("tinyint");

                    b.Property<string>("ApellidoM")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ApellidoP")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("EstadoCivil")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("FechaIngreso")
                        .HasColumnType("date");

                    b.Property<int>("IdTipoDoc")
                        .HasColumnType("int");

                    b.Property<string>("NomEmpleado")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nom_Empleado");

                    b.Property<int?>("NroIdentidad")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("IdEmpleado")
                        .HasName("PK__Empleado__74056223C26188C3");

                    b.HasIndex("IdTipoDoc");

                    b.ToTable("Empleado", (string)null);
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Horario", b =>
                {
                    b.Property<int>("IdHorario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHorario"));

                    b.Property<int?>("Domingo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<TimeSpan?>("Hingreso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("time")
                        .HasColumnName("HIngreso")
                        .HasDefaultValueSql("('00:00:00.00')");

                    b.Property<TimeSpan?>("Hsalida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("time")
                        .HasColumnName("HSalida")
                        .HasDefaultValueSql("('00:00:00.00')");

                    b.Property<int>("IdArea")
                        .HasColumnType("int")
                        .HasColumnName("Id_Area");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int")
                        .HasColumnName("Id_Empleado");

                    b.Property<int?>("Jueves")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("Lunes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("Martes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("Miercoles")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("Sabado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("Viernes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("IdHorario")
                        .HasName("PK__Horarios__1539229B9EDCCF94");

                    b.HasIndex("IdArea");

                    b.HasIndex("IdEmpleado");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Infraccion", b =>
                {
                    b.Property<int>("IdInfraccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Infraccion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInfraccion"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<double?>("Monto")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("float");

                    b.Property<string>("NomInfraccion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nom_Infraccion");

                    b.Property<string>("Rango")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Resolucion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdInfraccion")
                        .HasName("PK__Infracci__A446E3CCB35FD15D");

                    b.ToTable("Infraccion", (string)null);
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Multum", b =>
                {
                    b.Property<int>("IdMulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Multa");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMulta"));

                    b.Property<int?>("Año")
                        .HasColumnType("int");

                    b.Property<string>("CodPago")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Color")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Direcion")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DistritoMulta")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("EstPago")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Estado")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("FecMulta")
                        .HasColumnType("date");

                    b.Property<string>("Grua")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<TimeSpan?>("HoraMulta")
                        .HasColumnType("time");

                    b.Property<int>("IdDeposito")
                        .HasColumnType("int")
                        .HasColumnName("Id_Deposito");

                    b.Property<int>("IdInfraccion")
                        .HasColumnType("int")
                        .HasColumnName("Id_Infraccion");

                    b.Property<int>("IdPersonal")
                        .HasColumnType("int")
                        .HasColumnName("Id_Personal");

                    b.Property<string>("LugarMulta")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Marca")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Modelo")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nmotor")
                        .HasMaxLength(17)
                        .IsUnicode(false)
                        .HasColumnType("varchar(17)")
                        .HasColumnName("NMotor");

                    b.Property<string>("NroSerie")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Nro_Serie");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)");

                    b.Property<string>("Propietario")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMulta")
                        .HasName("PK__Multa__F56FD24577A32191");

                    b.HasIndex("IdDeposito");

                    b.HasIndex("IdInfraccion");

                    b.HasIndex("IdPersonal");

                    b.ToTable("Multa");
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Personal", b =>
                {
                    b.Property<int>("IdPersonal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Personal");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersonal"));

                    b.Property<string>("Contraseña")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdArea")
                        .HasColumnType("int")
                        .HasColumnName("Id_Area");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int")
                        .HasColumnName("Id_Empleado");

                    b.Property<string>("UsuarioAcceso")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdPersonal")
                        .HasName("PK__Personal__C797A7F853C0C4D3");

                    b.HasIndex("IdArea");

                    b.HasIndex("IdEmpleado");

                    b.ToTable("Personal", (string)null);
                });

            modelBuilder.Entity("MuniChorrillos2.Models.TipoDoc", b =>
                {
                    b.Property<int>("IdTipoDoc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoDoc"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NumIdentifica")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Num_Identifica");

                    b.HasKey("IdTipoDoc")
                        .HasName("PK__TipoDoc__08119E685A2D3FA2");

                    b.ToTable("TipoDoc", (string)null);
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Usuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("ApellidoU")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Contraseña")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NombreU")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("IdUsuario")
                        .HasName("PK__Usuario__63C76BE20C3553DA");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("MuniChorrillos2.Models.VehInfractor", b =>
                {
                    b.Property<int>("IdVehInfractor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVehInfractor"));

                    b.Property<int?>("Año")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Estado")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Marca")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Modelo")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nmotor")
                        .HasMaxLength(17)
                        .IsUnicode(false)
                        .HasColumnType("varchar(17)")
                        .HasColumnName("NMotor");

                    b.Property<string>("Placa")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)");

                    b.HasKey("IdVehInfractor")
                        .HasName("PK__VehInfra__1BDBC389B18D8AE9");

                    b.ToTable("VehInfractor", (string)null);
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Vmunicipal", b =>
                {
                    b.Property<int>("IdVehiculoMunicipal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVehiculoMunicipal"));

                    b.Property<int?>("Año")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Estado")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("IdPersonal")
                        .HasColumnType("int")
                        .HasColumnName("Id_Personal");

                    b.Property<string>("Marca")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Modelo")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nmotor")
                        .HasMaxLength(17)
                        .IsUnicode(false)
                        .HasColumnType("varchar(17)")
                        .HasColumnName("NMotor");

                    b.Property<string>("Placa")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)");

                    b.HasKey("IdVehiculoMunicipal")
                        .HasName("PK__VMunicip__72557A8B2285EE0F");

                    b.HasIndex("IdPersonal");

                    b.ToTable("VMunicipal", (string)null);
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Comprobante", b =>
                {
                    b.HasOne("MuniChorrillos2.Models.CabComprobante", "IdCabeceraCNavigation")
                        .WithMany("Comprobantes")
                        .HasForeignKey("IdCabeceraC")
                        .IsRequired()
                        .HasConstraintName("FK__Comproban__Id_Ca__5629CD9C");

                    b.HasOne("MuniChorrillos2.Models.DetComprobante", "IdDetalleCNavigation")
                        .WithMany("Comprobantes")
                        .HasForeignKey("IdDetalleC")
                        .IsRequired()
                        .HasConstraintName("FK__Comproban__Id_De__571DF1D5");

                    b.Navigation("IdCabeceraCNavigation");

                    b.Navigation("IdDetalleCNavigation");
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Deposito", b =>
                {
                    b.HasOne("MuniChorrillos2.Models.Personal", "IdPersonalNavigation")
                        .WithMany("Depositos")
                        .HasForeignKey("IdPersonal")
                        .IsRequired()
                        .HasConstraintName("FK__Deposito__Id_Per__5BE2A6F2");

                    b.Navigation("IdPersonalNavigation");
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Empleado", b =>
                {
                    b.HasOne("MuniChorrillos2.Models.TipoDoc", "IdTipoDocNavigation")
                        .WithMany("Empleados")
                        .HasForeignKey("IdTipoDoc")
                        .IsRequired()
                        .HasConstraintName("FK__Empleado__IdTipo__59FA5E80");

                    b.Navigation("IdTipoDocNavigation");
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Horario", b =>
                {
                    b.HasOne("MuniChorrillos2.Models.Area", "IdAreaNavigation")
                        .WithMany("Horarios")
                        .HasForeignKey("IdArea")
                        .IsRequired()
                        .HasConstraintName("FK__Horarios__Id_Are__0C85DE4D");

                    b.HasOne("MuniChorrillos2.Models.Empleado", "IdEmpleadoNavigation")
                        .WithMany("Horarios")
                        .HasForeignKey("IdEmpleado")
                        .IsRequired()
                        .HasConstraintName("FK__Horarios__Id_Emp__0B91BA14");

                    b.Navigation("IdAreaNavigation");

                    b.Navigation("IdEmpleadoNavigation");
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Multum", b =>
                {
                    b.HasOne("MuniChorrillos2.Models.Deposito", "IdDepositoNavigation")
                        .WithMany("Multa")
                        .HasForeignKey("IdDeposito")
                        .IsRequired()
                        .HasConstraintName("FK__Multa__Id_Deposi__5CD6CB2B");

                    b.HasOne("MuniChorrillos2.Models.Infraccion", "IdInfraccionNavigation")
                        .WithMany("Multa")
                        .HasForeignKey("IdInfraccion")
                        .IsRequired()
                        .HasConstraintName("FK__Multa__Id_Infrac__5DCAEF64");

                    b.HasOne("MuniChorrillos2.Models.Personal", "IdPersonalNavigation")
                        .WithMany("Multa")
                        .HasForeignKey("IdPersonal")
                        .IsRequired()
                        .HasConstraintName("FK__Multa__Id_Person__5EBF139D");

                    b.Navigation("IdDepositoNavigation");

                    b.Navigation("IdInfraccionNavigation");

                    b.Navigation("IdPersonalNavigation");
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Personal", b =>
                {
                    b.HasOne("MuniChorrillos2.Models.Area", "IdAreaNavigation")
                        .WithMany("Personals")
                        .HasForeignKey("IdArea")
                        .IsRequired()
                        .HasConstraintName("FK__Personal__Id_Are__59063A47");

                    b.HasOne("MuniChorrillos2.Models.Empleado", "IdEmpleadoNavigation")
                        .WithMany("Personals")
                        .HasForeignKey("IdEmpleado")
                        .IsRequired()
                        .HasConstraintName("FK__Personal__Id_Emp__5812160E");

                    b.Navigation("IdAreaNavigation");

                    b.Navigation("IdEmpleadoNavigation");
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Vmunicipal", b =>
                {
                    b.HasOne("MuniChorrillos2.Models.Personal", "IdPersonalNavigation")
                        .WithMany("Vmunicipals")
                        .HasForeignKey("IdPersonal")
                        .IsRequired()
                        .HasConstraintName("FK__VMunicipa__Id_Pe__5AEE82B9");

                    b.Navigation("IdPersonalNavigation");
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Area", b =>
                {
                    b.Navigation("Horarios");

                    b.Navigation("Personals");
                });

            modelBuilder.Entity("MuniChorrillos2.Models.CabComprobante", b =>
                {
                    b.Navigation("Comprobantes");
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Deposito", b =>
                {
                    b.Navigation("Multa");
                });

            modelBuilder.Entity("MuniChorrillos2.Models.DetComprobante", b =>
                {
                    b.Navigation("Comprobantes");
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Empleado", b =>
                {
                    b.Navigation("Horarios");

                    b.Navigation("Personals");
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Infraccion", b =>
                {
                    b.Navigation("Multa");
                });

            modelBuilder.Entity("MuniChorrillos2.Models.Personal", b =>
                {
                    b.Navigation("Depositos");

                    b.Navigation("Multa");

                    b.Navigation("Vmunicipals");
                });

            modelBuilder.Entity("MuniChorrillos2.Models.TipoDoc", b =>
                {
                    b.Navigation("Empleados");
                });
#pragma warning restore 612, 618
        }
    }
}
