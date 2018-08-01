using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeerService.Models
{
    public class Weapon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MinimumLevel { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public int AttackMore { get; set; }
        public virtual WeaponType WeaponType { get; set; }
    }
}