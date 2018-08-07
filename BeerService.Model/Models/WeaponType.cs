﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeerService.Model.Models
{
    public class WeaponType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameType { get; set; }

        public WeaponType()
        {
        }
    }
}