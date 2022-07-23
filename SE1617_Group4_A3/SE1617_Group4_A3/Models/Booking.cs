using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SE1617_Group4_A3.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int ShowId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Seat Status")]
        public string SeatStatus { get; set; }
        public decimal? Amount { get; set; }

        public virtual Show Show { get; set; }
    }
}
