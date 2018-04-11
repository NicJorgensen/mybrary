using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class LibraryBook
    {
        public int Id { get; set; }
        public int LibraryId { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
    }
}