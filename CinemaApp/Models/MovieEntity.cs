using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CinemaApp.Models
{
    public class MovieEntity : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public MovieGenreEnum Genre { get; set; }

        [Required]
        public short AllowedAge { get; set; }

        [Required]
        public short LengthMinutes { get; set; }
    }
}
