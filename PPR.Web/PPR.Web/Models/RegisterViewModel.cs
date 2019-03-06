using System.ComponentModel.DataAnnotations;

namespace PPR.Web.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Пароль:")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Повторите пароль:")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Имя пользователя:")]
        [Required]
        public string UserName { get; set; }
    }
}