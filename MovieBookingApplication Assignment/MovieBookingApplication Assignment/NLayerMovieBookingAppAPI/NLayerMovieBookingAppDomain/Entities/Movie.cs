using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppDomain.Entities
{
    public class Movie
    {
        [Key]
        public Guid MovieId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string DirectorName { get; set; }
        public string Description { get; set; }
        public string BannerImageUrl { get; set; }
        public int MovieLengthInMinutes { get; set; }
        public bool IsShowAdded {  get; set; }
        public MovieShow? MovieShow { get; set;} //comment
    }
}
