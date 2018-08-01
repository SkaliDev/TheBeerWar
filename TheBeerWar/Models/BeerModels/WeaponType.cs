using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheBeerWar.Models.BeerModels
{
    public class WeaponType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameType { get; set; }
    }
}