using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }

        //model oluşurken çalışacak olan metodu override edelim
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //assemblydeki tüm configuration interfaceleri bu kodla taratırız
            //bu sayede ef core a configuration içerisindeki bilgiler aktarılmış olur.

            //istenirse seed data aşağıdaki gibi de tanımlanabilir. örneğin productfeature için yapılmıştır ancak best practice açısından kullanışlı değildir. seed classları oluşturmak daha cleandir.
            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
            {
                ID = 1,
                Color = "red",
                Height = 100,
                Weight = 200,
                ProductID = 1
            },
            new ProductFeature
            {
                ID = 2,
                Color = "blue",
                Height = 100,
                Weight = 100,
                ProductID = 2
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
