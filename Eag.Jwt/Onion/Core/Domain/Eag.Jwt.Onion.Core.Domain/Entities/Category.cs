using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eag.Jwt.Onion.Core.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public List<Product>? Products { get; set; }
    }
}
