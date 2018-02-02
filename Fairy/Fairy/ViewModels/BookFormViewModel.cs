using Fairy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fairy.ViewModels
{
    public class BookFormViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}