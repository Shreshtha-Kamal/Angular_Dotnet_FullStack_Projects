﻿using NLayerMovieBookingAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppBLL.Models
{
    public class AddMovieShowModel
    {
        public Guid? ShowId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int TotalSeats { get; set; }
        public int Price { get; set; }
        public int ScreenId { get; set; }
        public Guid MovieId { get; set; }
    }
}
