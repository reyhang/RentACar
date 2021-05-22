using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RentACar.Models
{
    public partial class Card
    {
        public Card()
        {
            Users = new HashSet<User>();
        }
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public decimal Id { get; set; }
        public string Userfirstname { get; set; }
        public string Userlastname { get; set; }
        public string Cardnumber { get; set; }
        public decimal Cardmonth { get; set; }
        public decimal Caryear { get; set; }
        public decimal Cvv { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
