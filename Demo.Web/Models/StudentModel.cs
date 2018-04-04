﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo.Web.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string StudentName { get; set; }
        [Range(5, 50)]
        public int Age { get; set; }
    }
}