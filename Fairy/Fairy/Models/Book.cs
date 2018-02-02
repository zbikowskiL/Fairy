using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fairy.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name ="Genre")]
        [Required]
        public int GenreId { get; set; }
        [Display(Name = "Add Date")]
        public DateTime DateAdded { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }
        public int NumberAvailable { get; set; }

    }
}