using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookLab2.Models
{
    public class Book
    {
        public Book()
        {
            BookGenres = new List<BookGenre>();
        }
        public int BookId { get; set; }
        [Display(Name = "Назва книги")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Уведіть від 2 до 50 символів")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; }
        [Display(Name = "Рік виходу книги")]
        [Range(1500, 2020, ErrorMessage = "Уведіть рік від 1500 до поточного")]
        public int Year { get; set; }

        public int AuthorId { get; set; }

        [Display(Name = "Автор")]
        public virtual Author Author { get; set; }

        public virtual ICollection<BookGenre> BookGenres { get; set; }

    }
}
