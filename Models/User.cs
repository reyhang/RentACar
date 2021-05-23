using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RentACar.Models
{
    public partial class User
    {
        public User()
        {
            Deletedrentalhistories = new HashSet<Deletedrentalhistory>();
            Rentalhistories = new HashSet<Rentalhistory>();
            Rentals = new HashSet<Rental>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public decimal Id { get; set; }
        public decimal Contactid { get; set; }
        public decimal Addressid { get; set; }
        public decimal Cardid { get; set; }
        public string Nationalid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Birthplace { get; set; }
        public decimal Birthyear { get; set; }

        public virtual Address Address { get; set; }
        public virtual Card Card { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual ICollection<Deletedrentalhistory> Deletedrentalhistories { get; set; }
        public virtual ICollection<Rentalhistory> Rentalhistories { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
