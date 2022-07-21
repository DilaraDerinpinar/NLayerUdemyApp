using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } //KATEGORININ BİRDEN FAZLA PRODUCTI OLABİLECEĞİ İÇİN BÖYLE NAVIGATION PROP TANIMLADIK.
        public int Id { get; set; }
    }
}
