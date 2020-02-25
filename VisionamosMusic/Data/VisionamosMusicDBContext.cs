using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionamosMusic.Data.DataModels;

namespace VisionamosMusic.Data
{
    public partial class VisionamosMusicDBContext : DbContext
    {
        public VisionamosMusicDBContext(DbContextOptions<VisionamosMusicDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Song> Song { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.IdAutor)
                    .HasConstraintName("FK_Album_Author");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.IdSongNavigation)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.IdSong)
                    .HasConstraintName("FK_Car_Song");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.AlbumNavigation)
                    .WithMany(p => p.Song)
                    .HasForeignKey(d => d.Album)
                    .HasConstraintName("FK_Song_Album");

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Song)
                    .HasForeignKey(d => d.Author)
                    .HasConstraintName("FK_Song_Author");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EsAdmin)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
