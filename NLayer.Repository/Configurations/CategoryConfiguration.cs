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
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.ID); //id bir key olacak
            builder.Property(x => x.ID).UseIdentityColumn(); //aynı zamanda birer birer artcak.default olarak bıraktım birer birer artsın
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);//nullable olmasın ve max 50 char olsun
            builder.ToTable("Categories") //tablo adı verilebilir. Eğer bunu vermezsek default olarak appdbcontextte yer alan adını alır.


        }
    }
}
