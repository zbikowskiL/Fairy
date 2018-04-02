﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fairy.DTOmodels
{
    public class BookDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public GenreDTO Genre { get; set; }

        [Required]
        public int GenreId { get; set; }
        
        public DateTime DateAdded { get; set; }
        
        public DateTime ReleaseDate { get; set; }
        
        [Range(1,20)]
        public int NumberInStock { get; set; }
        

    }
}