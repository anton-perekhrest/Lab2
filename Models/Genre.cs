using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BookLab2.Models
{
    public class Genre
    {
        public Genre()
        {
            BookGenres = new List<BookGenre>();
        }

        public int Id { get; set; }

        [Display(Name = "Жанр")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [RegularExpression(@"^([a-zA-Z\-]{2,})|([а-яіїєщА-ЯІЇЄЩ\-]{2,})$", ErrorMessage = "Введіть назву правильно")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Уведіть від 2 до 50 символів")]
        public string Name { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
    }
}
