using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeerService.Models
{
    public class UserWeapon
    {
        [Key]
        public int Id { get; set; }
        public virtual BeerUser User{ get; set; }
        public virtual Weapon Weapon { get; set; }
        [Required]
        public bool InUse { get; set; }
    }
}