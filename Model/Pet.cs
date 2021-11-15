﻿using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        public string Species { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}