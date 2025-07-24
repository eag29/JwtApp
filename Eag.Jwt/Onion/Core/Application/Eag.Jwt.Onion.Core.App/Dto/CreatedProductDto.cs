using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eag.Jwt.Onion.Core.App.Dto
{
    public class CreatedProductDto
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
    }
}
