using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookLab2.Models
{
    public class Author {
        
        public Author()
        {
            Books = new List<Book>();
        }

        public int AuthorId { get; set; }
        [Display(Name = "Ім'я автора")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Уведіть від 2 до 50 символів")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; }
        [Display(Name = "Рік народження")]
        [Range(1500, 2020, ErrorMessage = "Уведіть рік від 1500 до поточного")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int BitrhYear { get; set; }
        [Display(Name = "Рік смерті")]
        [Range(1500, 2020, ErrorMessage = "Уведіть рік від 1500 до поточного")]
        public int? DeathYear { get; set; }
        public int CountryId { get; set; }

        [JsonIgnore]
        [Display(Name = "Країна")]
        public virtual Country Country { get; set; }
        public virtual ICollection<Book> Books { get; set; }


    }
}