﻿
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
       
}
