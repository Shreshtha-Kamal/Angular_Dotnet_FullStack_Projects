using NLayerMovieBookingAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppBLL.Models
{
    public class TicketModel
    {
        public int SeatCount { get; set; }
        public DateTime ShowDate { get; set; }
        public Guid ShowId { get; set; }
    }
}
