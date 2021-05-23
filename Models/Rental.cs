using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RentACar.Models
{
    public partial class Rental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public decimal Id { get; set; }
        public decimal Userid { get; set; }
        public decimal Carid { get; set; }
        public DateTime Rentdate { get; set; }
        public DateTime Returndate { get; set; }
        public decimal Totalprice { get; set; }
        public bool? Delivery { get; set; }

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
    }
}
