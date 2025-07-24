using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Eag.Jwt.Front.Models
{
    public class CreateProductModel
    {
        [Required(ErrorMessage = "Ürün Adı zorunludur")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Stok Sayısı zorunludur")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Ürün Fiyatı zorunludur")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Ürün Durumu zorunludur")]
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public SelectList? Categories { get; set; }
    }
}
