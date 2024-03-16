using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResumeShop.Models
{
    public class Order
    {

        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isFinally { get; set; }

        [ForeignKey("UserId")]
        public Users Users { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
