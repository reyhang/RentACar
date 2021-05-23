using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RentACar.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Cars = new HashSet<Car>();
            Models = new HashSet<Model>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public decimal Id { get; set; }
        public string Brandname { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Model> Models { get; set; }
    }
}
