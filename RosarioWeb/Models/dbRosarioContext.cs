using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RosarioWeb.Models
{
    public partial class dbRosarioContext : DbContext
    {
        public dbRosarioContext()
        {
        }

        public dbRosarioContext(DbContextOptions<dbRosarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudiantes> Estudiantes { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Modalidad> Modalidad { get; set; }
        public virtual DbSet<Notas> Notas { get; set; }
        public virtual DbSet<Profesores> Profesores { get; set; }
        public virtual DbSet<Secciones> Secciones { get; set; }
        public virtual DbSet<Tutor> Tutor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-QQ4CDATD\\SQLEXPRESS;Database= dbRosario; User Id= sa; Password= root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiantes>(entity =>
            {
                entity.HasKey(e => e.Idestudiante)
                    .HasName("PK__estudian__DE1D9AFA181F1915");

                entity.ToTable("estudiantes");

                entity.Property(e => e.Idestudiante).HasColumnName("idestudiante");

                entity.Property(e => e.Departamento)
                    .HasColumnName("departamento")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Domicilio)
                    .HasColumnName("domicilio")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Idmateria).HasColumnName("idmateria");

                entity.Property(e => e.Idmatricula).HasColumnName("idmatricula");

                entity.Property(e => e.Idnota).HasColumnName("idnota");

                entity.Property(e => e.Idtutor).HasColumnName("idtutor");

                entity.Property(e => e.Nacionalidad)
                    .HasColumnName("nacionalidad")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .HasColumnName("primer_apellido")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .HasColumnName("primer_nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("segundo_apellido")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasColumnName("segundo_nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasColumnName("sexo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdmateriaNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Idmateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__estudiant__idmat__628FA481");

                entity.HasOne(d => d.IdmatriculaNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Idmatricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__estudiant__idmat__656C112C");

                entity.HasOne(d => d.IdnotaNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Idnota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__estudiant__idnot__6383C8BA");

                entity.HasOne(d => d.IdtutorNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Idtutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__estudiant__idtut__6477ECF3");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.Idmateria)
                    .HasName("PK__materia__AD39326379CB035A");

                entity.ToTable("materia");

                entity.Property(e => e.Idmateria).HasColumnName("idmateria");

                entity.Property(e => e.Año)
                    .HasColumnName("año")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Materia1)
                    .HasColumnName("materia")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Semestre)
                    .HasColumnName("semestre")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => e.Idmatricula)
                    .HasName("PK__matricul__C63F5ED4417F5861");

                entity.ToTable("matricula");

                entity.Property(e => e.Idmatricula).HasColumnName("idmatricula");

                entity.Property(e => e.AñoLectivo)
                    .HasColumnName("año_lectivo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Modalidad)
                    .HasColumnName("modalidad")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCompleto)
                    .HasColumnName("nombre_completo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Seccion)
                    .HasColumnName("seccion")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Modalidad>(entity =>
            {
                entity.HasKey(e => e.Idmodalidad)
                    .HasName("PK__modalida__501D5B00172241BC");

                entity.ToTable("modalidad");

                entity.Property(e => e.Idmodalidad).HasColumnName("idmodalidad");

                entity.Property(e => e.Idestudiante).HasColumnName("idestudiante");

                entity.Property(e => e.Modalidad1)
                    .HasColumnName("modalidad")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdestudianteNavigation)
                    .WithMany(p => p.Modalidad)
                    .HasForeignKey(d => d.Idestudiante)
                    .HasConstraintName("FK__modalidad__modal__68487DD7");
            });

            modelBuilder.Entity<Notas>(entity =>
            {
                entity.HasKey(e => e.Idnota)
                    .HasName("PK__notas__60059F490162676A");

                entity.ToTable("notas");

                entity.Property(e => e.Idnota).HasColumnName("idnota");

                entity.Property(e => e.NotaFinal)
                    .HasColumnName("nota_final")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerParcial)
                    .HasColumnName("primer_parcial")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoParcial)
                    .HasColumnName("segundo_parcial")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TercerParcial)
                    .HasColumnName("tercer_parcial")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profesores>(entity =>
            {
                entity.HasKey(e => e.Idprofesor)
                    .HasName("PK__profesor__23511EA7F375737E");

                entity.ToTable("profesores");

                entity.Property(e => e.Idprofesor).HasColumnName("idprofesor");

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasColumnName("departamento")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Domicilio)
                    .HasColumnName("domicilio")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Idmateria).HasColumnName("idmateria");

                entity.Property(e => e.Inss)
                    .HasColumnName("inss")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nacionalidad)
                    .HasColumnName("nacionalidad")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .HasColumnName("primer_apellido")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .HasColumnName("primer_nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("segundo_apellido")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasColumnName("segundo_nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasColumnName("sexo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdmateriaNavigation)
                    .WithMany(p => p.Profesores)
                    .HasForeignKey(d => d.Idmateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__profesore__idmat__49C3F6B7");
            });

            modelBuilder.Entity<Secciones>(entity =>
            {
                entity.HasKey(e => e.Idseccion)
                    .HasName("PK__seccione__1B536B16F28EB8A6");

                entity.ToTable("secciones");

                entity.Property(e => e.Idseccion).HasColumnName("idseccion");

                entity.Property(e => e.Idestudiante).HasColumnName("idestudiante");

                entity.Property(e => e.Seccion)
                    .IsRequired()
                    .HasColumnName("seccion")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdestudianteNavigation)
                    .WithMany(p => p.Secciones)
                    .HasForeignKey(d => d.Idestudiante)
                    .HasConstraintName("FK__secciones__idest__6B24EA82");
            });

            modelBuilder.Entity<Tutor>(entity =>
            {
                entity.HasKey(e => e.Idtutor)
                    .HasName("PK__tutor__7AFD2AD5490666E9");

                entity.ToTable("tutor");

                entity.Property(e => e.Idtutor).HasColumnName("idtutor");

                entity.Property(e => e.Departamento)
                    .HasColumnName("departamento")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Domicilio)
                    .HasColumnName("domicilio")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCivil)
                    .HasColumnName("estado_civil")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Ocupacion)
                    .HasColumnName("ocupacion")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .HasColumnName("primer_apellido")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .HasColumnName("primer_nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("segundo_apellido")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasColumnName("segundo_nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasColumnName("sexo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
