using Microsoft.EntityFrameworkCore;

namespace ExamDemo.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Kitap> Kitaplar { get; set; }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Kitap>().HasData(
                new Kitap { Id=1, KitapAdi="Lord Of The Rings Series", Yazar="J.R.R Tolkien"},
                new Kitap { Id=2, KitapAdi="Harry Potter Chamber of Secrets", Yazar="J.K.Rowling"},
                new Kitap { Id=3, KitapAdi="Harry Potter and the Goblet of Fire", Yazar="J.K.Rowling"},
                new Kitap { Id=4, KitapAdi="Harry Potter and the Half-Blood Prince", Yazar="J.K.Rowling"}
                );
        }
    }
}
