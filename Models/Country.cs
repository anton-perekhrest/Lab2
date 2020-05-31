using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookLab2.Models
{
    public class Country
    {
        public Country()
        {
            Authors = new List<Author>();
        }

        public int Id { get; set; }
        [Display(Name = "Країна")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [RegularExpression(@"^([a-zA-Z\' ']{2,})|([а-яіїєщА-ЯІЇЄЩ\' ']{2,})$", ErrorMessage = "Введіть назву країни правильно")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Уведіть від 2 до 50 символів")]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Author> Authors { get; set; }
        
    }
}

