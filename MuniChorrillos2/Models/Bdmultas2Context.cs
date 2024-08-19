using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MuniChorrillos2.Models;

public partial class Bdmultas2Context : DbContext
{
    public Bdmultas2Context()
    {
    }

    public Bdmultas2Context(DbContextOptions<Bdmultas2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<CabComprobante> CabComprobantes { get; set; }

    public virtual DbSet<Comprobante> Comprobantes { get; set; }

    public virtual DbSet<ControlVehicular> ControlVehiculars { get; set; }

    public virtual DbSet<Deposito> Depositos { get; set; }

    public virtual DbSet<DetComprobante> DetComprobantes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Infraccion> Infraccions { get; set; }

    public virtual DbSet<Multum> Multa { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<TipoDoc> TipoDocs { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VehInfractor> VehInfractors { get; set; }

    public virtual DbSet<Vmunicipal> Vmunicipals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=bdmultas2;Integrated Security=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.IdArea).HasName("PK__Area__9C42D7FECE9A3E02");

            entity.ToTable("Area");

            entity.Property(e => e.IdArea).HasColumnName("Id_Area");
            entity.Property(e => e.NomArea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nom_Area");
        });

        modelBuilder.Entity<CabComprobante>(entity =>
        {
            entity.HasKey(e => e.IdCabeceraC).HasName("PK__CabCompr__F4C67864F74B4D75");

            entity.ToTable("CabComprobante");

            entity.Property(e => e.IdCabeceraC).HasColumnName("Id_CabeceraC");
            entity.Property(e => e.Entidad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.MedioPago)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tcomprobante).HasColumnName("TComprobante");
        });

        modelBuilder.Entity<Comprobante>(entity =>
        {
            entity.HasKey(e => e.IdComprobante).HasName("PK__Comproba__BCCA7AF13513C45F");

            entity.ToTable("Comprobante");

            entity.Property(e => e.IdComprobante).HasColumnName("Id_Comprobante");
            entity.Property(e => e.IdCabeceraC).HasColumnName("Id_CabeceraC");
            entity.Property(e => e.IdDetalleC).HasColumnName("Id_DetalleC");
            entity.Property(e => e.IdMulta).HasColumnName("Id_Multa");

            entity.HasOne(d => d.IdCabeceraCNavigation).WithMany(p => p.Comprobantes)
                .HasForeignKey(d => d.IdCabeceraC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comproban__Id_Ca__5629CD9C");

            entity.HasOne(d => d.IdDetalleCNavigation).WithMany(p => p.Comprobantes)
                .HasForeignKey(d => d.IdDetalleC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comproban__Id_De__571DF1D5");
        });

        modelBuilder.Entity<ControlVehicular>(entity =>
        {
            entity.HasKey(e => e.IdControl).HasName("PK__ControlV__2537521F63611CEF");

            entity.ToTable("ControlVehicular");

            entity.Property(e => e.Dia).HasColumnType("date");
            entity.Property(e => e.Hingreso).HasColumnName("HIngreso");
            entity.Property(e => e.Hsalida).HasColumnName("HSalida");
            entity.Property(e => e.Placa)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Deposito>(entity =>
        {
            entity.HasKey(e => e.IdDeposito).HasName("PK__Deposito__C363AF7261E869D6");

            entity.ToTable("Deposito");

            entity.Property(e => e.IdDeposito).HasColumnName("Id_Deposito");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdPersonal).HasColumnName("Id_Personal");
            entity.Property(e => e.NomDeposito)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPersonalNavigation).WithMany(p => p.Depositos)
                .HasForeignKey(d => d.IdPersonal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Deposito__Id_Per__5BE2A6F2");
        });

        modelBuilder.Entity<DetComprobante>(entity =>
        {
            entity.HasKey(e => e.IdDetalleC).HasName("PK__DetCompr__8498178E926D57F6");

            entity.ToTable("DetComprobante");

            entity.Property(e => e.IdDetalleC).HasColumnName("Id_DetalleC");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__74056223C26188C3");

            entity.ToTable("Empleado");

            entity.Property(e => e.IdEmpleado).HasColumnName("Id_Empleado");
            entity.Property(e => e.ApellidoM)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoP)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EstadoCivil)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaIngreso).HasColumnType("date");
            entity.Property(e => e.NomEmpleado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nom_Empleado");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoDocNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdTipoDoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleado__IdTipo__59FA5E80");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdHorario).HasName("PK__Horarios__1539229B9EDCCF94");

            entity.Property(e => e.Domingo).HasDefaultValueSql("((0))");
            entity.Property(e => e.Hingreso)
                .HasDefaultValueSql("('00:00:00.00')")
                .HasColumnName("HIngreso");
            entity.Property(e => e.Hsalida)
                .HasDefaultValueSql("('00:00:00.00')")
                .HasColumnName("HSalida");
            entity.Property(e => e.IdArea).HasColumnName("Id_Area");
            entity.Property(e => e.IdEmpleado).HasColumnName("Id_Empleado");
            entity.Property(e => e.Jueves).HasDefaultValueSql("((0))");
            entity.Property(e => e.Lunes).HasDefaultValueSql("((0))");
            entity.Property(e => e.Martes).HasDefaultValueSql("((0))");
            entity.Property(e => e.Miercoles).HasDefaultValueSql("((0))");
            entity.Property(e => e.Sabado).HasDefaultValueSql("((0))");
            entity.Property(e => e.Viernes).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Horarios__Id_Are__0C85DE4D");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Horarios__Id_Emp__0B91BA14");
        });

        modelBuilder.Entity<Infraccion>(entity =>
        {
            entity.HasKey(e => e.IdInfraccion).HasName("PK__Infracci__A446E3CCB35FD15D");

            entity.ToTable("Infraccion");

            entity.Property(e => e.IdInfraccion).HasColumnName("Id_Infraccion");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.NomInfraccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nom_Infraccion");
            entity.Property(e => e.Rango)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Resolucion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Monto)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Multum>(entity =>
        {
            entity.HasKey(e => e.IdMulta).HasName("PK__Multa__F56FD24577A32191");

            entity.Property(e => e.IdMulta).HasColumnName("Id_Multa");
            entity.Property(e => e.ImagenBase64)
                .IsUnicode(false); // Configuración para la nueva columna
            entity.Property(e => e.CodPago)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Direcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DistritoMulta)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EstPago)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FecMulta).HasColumnType("date");
            entity.Property(e => e.Grua)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdDeposito).HasColumnName("Id_Deposito");
            entity.Property(e => e.IdInfraccion).HasColumnName("Id_Infraccion");
            entity.Property(e => e.IdPersonal).HasColumnName("Id_Personal");
            entity.Property(e => e.LugarMulta)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Marca)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nmotor)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("NMotor");
            entity.Property(e => e.NroSerie)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Nro_Serie");
            entity.Property(e => e.Placa)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Propietario)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDepositoNavigation).WithMany(p => p.Multa)
                .HasForeignKey(d => d.IdDeposito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Multa__Id_Deposi__5CD6CB2B");

            entity.HasOne(d => d.IdInfraccionNavigation).WithMany(p => p.Multa)
                .HasForeignKey(d => d.IdInfraccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Multa__Id_Infrac__5DCAEF64");

            entity.HasOne(d => d.IdPersonalNavigation).WithMany(p => p.Multa)
                .HasForeignKey(d => d.IdPersonal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Multa__Id_Person__5EBF139D");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.IdPersonal).HasName("PK__Personal__C797A7F853C0C4D3");

            entity.ToTable("Personal");

            entity.Property(e => e.IdPersonal).HasColumnName("Id_Personal");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdArea).HasColumnName("Id_Area");
            entity.Property(e => e.IdEmpleado).HasColumnName("Id_Empleado");
            entity.Property(e => e.UsuarioAcceso)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Personals)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Personal__Id_Are__59063A47");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Personals)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Personal__Id_Emp__5812160E");
        });

        modelBuilder.Entity<TipoDoc>(entity =>
        {
            entity.HasKey(e => e.IdTipoDoc).HasName("PK__TipoDoc__08119E685A2D3FA2");

            entity.ToTable("TipoDoc");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumIdentifica)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Num_Identifica");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__63C76BE20C3553DA");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.ApellidoU)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreU)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VehInfractor>(entity =>
        {
            entity.HasKey(e => e.IdVehInfractor).HasName("PK__VehInfra__1BDBC389B18D8AE9");

            entity.ToTable("VehInfractor");

            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Marca)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nmotor)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("NMotor");
            entity.Property(e => e.Placa)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vmunicipal>(entity =>
        {
            entity.HasKey(e => e.IdVehiculoMunicipal).HasName("PK__VMunicip__72557A8B2285EE0F");

            entity.ToTable("VMunicipal");

            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IdPersonal).HasColumnName("Id_Personal");
            entity.Property(e => e.Marca)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nmotor)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("NMotor");
            entity.Property(e => e.Placa)
                .HasMaxLength(6)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPersonalNavigation).WithMany(p => p.Vmunicipals)
                .HasForeignKey(d => d.IdPersonal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VMunicipa__Id_Pe__5AEE82B9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
