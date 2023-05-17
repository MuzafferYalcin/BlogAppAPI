using BlogApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Repository
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<Blog> Bloglar { get; set; }
        public DbSet<Category> Categoryler { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Blog>()
                .HasOne(b => b.Yazar)
                .WithMany(y => y.Bloglar)
                .HasForeignKey(b => b.YazarId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Yorum>()
                .HasOne(y => y.Yazar)
                .WithMany(y => y.Yorumlar)
                .HasForeignKey(y => y.YazarId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Yorum>()
                .HasOne(y => y.Blog)
                .WithMany(b => b.Yorumlar)
                .HasForeignKey(y => y.BlogId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Blog>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Bloglar)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
