using System.ComponentModel.DataAnnotations;

namespace PPR.Web.Models
{
    public class LoginViewModel
    {
        [Display(Name ="Имя пользователя:")]
        [Required]
        public string UserName { get; set; }
        [Display(Name = "Пароль:")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}