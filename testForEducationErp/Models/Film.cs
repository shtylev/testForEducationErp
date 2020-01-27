using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace testForEducationErp.Models
{
    public class Film
    {
        [Index(IsUnique = true)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Index]
        [Required(ErrorMessage = "Поле не должно быть пустым!")]
        [Display(Name = "Название")]
        [StringLength(150, ErrorMessage = "Количество символов не должно превышать 150!")]
        [RegularExpression(@"[\w\d\sА-яёЁ:!?,.()%-]*", ErrorMessage = "Текст содержит запрещающие символы!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым!")]
        [Display(Name = "Описание")]
        [RegularExpression(@"[\w\d\sА-яёЁ:!?,.()%-]*", ErrorMessage = "Текст содержит запрещающие символы!")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Index]
        [Required(ErrorMessage = "Поле не должно быть пустым!")]
        [Display(Name = "Год выпуска")]
        [RegularExpression(@"\d{4}", ErrorMessage = "Недопустимый год!")]
        public int YearRelease { get; set; }

        [Index]
        [Required(ErrorMessage = "Поле не должно быть пустым!")]
        [Display(Name = "Режиссер")]
        [StringLength(150, ErrorMessage = "Количество символов не должно превышать 150!")]
        [RegularExpression(@"[\w\d\sА-яёЁ:!?,.()%-]*", ErrorMessage = "Текст содержит запрещающие символы!")]
        public string Producer { get; set; }

        [Display(Name = "Постер")]
        public string Poster { get; set; }

        [ScaffoldColumn(false)]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}