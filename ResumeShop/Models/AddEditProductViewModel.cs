using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ResumeShop.Models
{
    public class AddEditProductViewModel
    {
  
        public int Id { get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "قیمت")]
        public decimal Price { get; set; }
        [Display(Name = "موجودی در انبار")]
        public int QuantityInStock { get; set; }
        [Display(Name = "تصویر")]
        public IFormFile Picture { get; set; }
    }
}
