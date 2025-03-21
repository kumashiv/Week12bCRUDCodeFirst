﻿using System.ComponentModel.DataAnnotations;

namespace Week12bCRUDCodeFirst.Models
{
    public class Employee
    {
        [Key]     // to make id primary key
        public int id { get; set; }   // properties  - auto type

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }
    }
}
