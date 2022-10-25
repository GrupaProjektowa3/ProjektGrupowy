﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class UserLogin
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "{0} powinno zawierać min {2} i max {1}", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
