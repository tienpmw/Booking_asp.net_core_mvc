using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SE1617_Group4_A3.Models
{
    public partial class Show
    {
        public Show()
        {
            Bookings = new HashSet<Booking>();
        }

        public int ShowId { get; set; }
        [Display(Name = "Room")]
        public int RoomId { get; set; }
        [Display(Name = "Film")]
        public int FilmId { get; set; }
        [Display(Name = "Show date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ShowDate { get; set; }
        [Required(ErrorMessage = "Please enter show price.")]
        [Range(0,999999, ErrorMessage ="Price must be from 0 to 999,999")]
        public decimal? Price { get; set; }
        public bool? Status { get; set; }
        [Required(ErrorMessage = "Slot not empty")]
        public int? Slot { get; set; }

        public virtual Film Film { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
