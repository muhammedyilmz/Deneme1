using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme1.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? BookName { get; set; }
        [Required]
        public string? BookType { get; set; }
        [Required]
        public int BookPage { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}