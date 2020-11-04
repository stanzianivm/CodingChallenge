using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiContactos.Models
{
    public partial class ContactosContext : DbContext
    {
        //public ContactosContext()
        //{
        //}

        public ContactosContext(DbContextOptions<ContactosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=DESKTOP-5TFECBS\\SQLEXPRESS;initial catalog=DBContactos;Integrated Security=True;ConnectRetryCount=0");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Ciudad>(entity =>
            //{
            //    entity.HasOne(d => d.Provincia)
            //        .WithMany(p => p.Ciudad)
            //        .HasForeignKey(d => d.ProvinciaId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Ciudad_Provincia");
            //});

            //modelBuilder.Entity<Direccion>(entity =>
            //{
            //    entity.Property(e => e.Dpto).IsFixedLength();

            //    entity.HasOne(d => d.Ciudad)
            //        .WithMany(p => p.Direccion)
            //        .HasForeignKey(d => d.CiudadId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Direccion_Ciudad");
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
