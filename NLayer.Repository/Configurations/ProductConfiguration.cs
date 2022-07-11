using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ID); //id bir key olacak
            builder.Property(x => x.ID).UseIdentityColumn(); //aynı zamanda birer birer artcak.default olarak bıraktım birer birer artsın
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);//nullable olmasın ve max 50 char olsun
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryID); //foreign key ilişkisini açıkça belirtilebilir isternirse



        }
    }
}
