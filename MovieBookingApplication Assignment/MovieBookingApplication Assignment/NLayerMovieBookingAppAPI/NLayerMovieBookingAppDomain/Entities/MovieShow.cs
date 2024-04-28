using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppDomain.Entities
{
    public class MovieShow
    {
        [Key]
        public Guid ShowId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int TotalSeats { get; set; }
        public int Price { get; set; }
        public int ScreenId { get; set; }
        [Required]
        [ForeignKey("MovieId")]
        public Guid MovieId { get; set; }
        
        public Movie MovieData { get; set; }
        public int SeatsRemaining { get; set; }
        public List<Ticket>? Tickets { get; set; }
    }
}
