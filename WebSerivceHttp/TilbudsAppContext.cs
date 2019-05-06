namespace WebSerivceHttp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TilbudsAppContext : DbContext
    {
        public TilbudsAppContext()
            : base("name=TilbudsAppContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Butik> Butik { get; set; }
        public virtual DbSet<Byer> Byer { get; set; }
        public virtual DbSet<Firma> Firma { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<TilbudItem> TilbudItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Butik>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Butik>()
                .HasMany(e => e.TilbudItem)
                .WithRequired(e => e.Butik)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Byer>()
                .Property(e => e.Bname)
                .IsUnicode(false);

            modelBuilder.Entity<Firma>()
                .Property(e => e.Fname)
                .IsUnicode(false);

            modelBuilder.Entity<Firma>()
                .HasMany(e => e.Butik)
                .WithRequired(e => e.Firma)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Iname)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Beskrivelse)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.TilbudItem)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);
        }
    }
}
