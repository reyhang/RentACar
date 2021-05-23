using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RentACar.Models
{
    public partial class Car
    {
        public Car()
        {
            Deletedrentalhistories = new HashSet<Deletedrentalhistory>();
            Rentalhistories = new HashSet<Rentalhistory>();
            Rentals = new HashSet<Rental>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public decimal Id { get; set; }
        public decimal Brandid { get; set; }
        public decimal Modelid { get; set; }
        public decimal Colorid { get; set; }
        public string Status { get; set; }
        public string Plate { get; set; }
        public decimal? Dailyprice { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Color Color { get; set; }
        public virtual Model Model { get; set; }
        public virtual ICollection<Deletedrentalhistory> Deletedrentalhistories { get; set; }
        public virtual ICollection<Rentalhistory> Rentalhistories { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
