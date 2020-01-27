using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testForEducationErp.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Логин")]
        [RegularExpression(@"[\w\d]*", ErrorMessage = "Логин должен содержать только алфавитно-цифровые символы!")]
        [Remote("CheckUserName", "Account", ErrorMessage = "Пользователь с таким логином уже имеется")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [StringLength(100, ErrorMessage = "Пароль должен содержать не менее {2} символов!", MinimumLength = 6)]
        [RegularExpression(@"[\w\d\s:!?,.()%-]*", ErrorMessage = "Пароль содержит запрещающие символы!")]
        public string Password { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        public string PasswordConfirm { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Логин")]
        [RegularExpression(@"[\w\d]*", ErrorMessage = "Логин должен содержать только алфавитно-цифровые символы.")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [RegularExpression(@"[\w\d\s:!?,.()%-]*", ErrorMessage = "Пароль содержит запрещающие символы!")]
        public string Password { get; set; }
    }
}