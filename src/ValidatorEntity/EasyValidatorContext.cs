using System.ComponentModel.DataAnnotations.Schema;
using EasyValidator.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyValidator.Entity {
    public class EasyValidatorContext : DbContext {
        public EasyValidatorContext(DbContextOptions option) : base(option) {

        }

        public DbSet<QFile> Files { set; get; }
        public DbSet<QProperty> Properties { set; get; }
        public DbSet<QTemplate> Templates { set; get; }
        public DbSet<QRejectReason> RejectReasons { set; get; }
        public DbSet<QReconcile> Reconciles { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<QFile>()
                .HasIndex(x => x.Status);

            modelBuilder.Entity<QFile>()
                .HasIndex(x => x.Uuid);

            modelBuilder.Entity<QTemplate>()
                .HasIndex(x => x.Template);

            modelBuilder.Entity<QTemplate>()
                .HasIndex(x => x.ValidationRequire);
        }
    }
}
