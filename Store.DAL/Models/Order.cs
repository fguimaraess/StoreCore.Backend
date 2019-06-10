
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DAL.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Paid { get; set; }
        public decimal RemainingValue { get; set; }

        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        public List<Product> Products { get; set; }
    }
       
}
