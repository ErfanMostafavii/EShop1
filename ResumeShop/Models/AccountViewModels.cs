using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ResumeShop.Models
{
    public class RegisterViewModel
    {
        
        [MaxLength(200)]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }

        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public string Password { get; set; }

        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public string rePassword { get; set; }

    }
}