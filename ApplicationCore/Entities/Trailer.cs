using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Trailer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string TrailerUrl { get; set; }

        public int MovieId { get; set; } //will inply the foreignkey. [Name]+[pk]

        //Navigation prop

        public Movie Movie { get; set; }
        //a movie should have multiple trailer, a tailer belongs to one movie
    }
}
