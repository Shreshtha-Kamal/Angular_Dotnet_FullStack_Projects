using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppDomain.Entities
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public int SeatCount { get; set; }
        public DateTime ShowDate { get; set; }
        public int PricePerSeat { get; set; }
        public string UserId { get; set; }
        [Required]
        [ForeignKey("ShowId")]
        public Guid ShowId { get; set; }
        public MovieShow ShowData { get; set; }

    }
}
