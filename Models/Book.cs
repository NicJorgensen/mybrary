using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Synopsis { get; set; }

        [Required]
        public string Cover { get; set; }
        public int Views { get; set; }
        public int Libraries { get; set; }

        public string UserId { get; set; }



    }

    public class CreateBook
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Synopsis { get; set; }

        [Required]
        public string Cover { get; set; }
        public string UserId { get; set; }
    }
}