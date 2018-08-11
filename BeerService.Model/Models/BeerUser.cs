using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BeerService.Exceptions;

namespace BeerService.Model.Models
{
    public class BeerUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ClientId { get; set; }
        public virtual GamerType GamerType { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public int Experience { get; set; }
        [Required]
        public int Money { get; set; }
        [Required(ErrorMessage = "The pseudonym is required.")]
        [RegularExpression(@"^[a-zA-Z0-9]{5,20}$", ErrorMessage = "The pseudonym must have between 5 and 20 characters (a-zA-Z0-9).")]
        public string Pseudonym { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Life { get; set; }
        public int MaxExperience { get; set; }

        public BeerUser()
        {
        }
    }
}