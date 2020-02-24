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
        public virtual DbSet<Song> Song { get; set; }

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
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
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
        }
    }
}
