using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme1.Models
{
    public class Hire
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? UserLastName { get; set; }
        [Required]
        public string? TcNo { get; set; }
        [Required]
        public string? UserPhone { get; set; }
    }
}