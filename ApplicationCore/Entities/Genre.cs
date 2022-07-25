using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [MaxLength(24)]
        public string Name { get; set; }

        //public  ICollection<Movie> Movies { get; set; }

        //want new control? new entity
        public ICollection<MovieGenre> MoviesOfGenre { get; set; }
    }
}
