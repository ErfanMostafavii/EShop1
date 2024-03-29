﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ResumeShop.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string password { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; }

        public List<Order> orders { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
