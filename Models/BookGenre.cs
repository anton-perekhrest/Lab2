using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLab2.Models
{
    public class BookGenre
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int GenreId { get; set; }
        [Display(Name = "Книга")]
    
        public virtual Book Book{ get; set; }
        [Display(Name = "Жанр")]
        public virtual Genre Genre { get; set; }
    }
}
