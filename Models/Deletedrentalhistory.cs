using System;
using System.Collections.Generic;


#nullable disable

namespace RentACar.Models

{ 
    public partial class Deletedrentalhistory
    {
        public decimal Id { get; set; }
        public decimal Userid { get; set; }
        public decimal Carid { get; set; }
        public DateTime Rentdate { get; set; }
        public DateTime Returndate { get; set; }
        public decimal Totalprice { get; set; }

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
    }
}


