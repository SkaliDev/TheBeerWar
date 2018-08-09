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
        private string _pseudonym;
        [Required]
        public string Pseudonym { get { return _pseudonym; } set { _pseudonym = StringLengthSmalerOrEqual(value, 20, "Pseudonym"); } }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Life { get; set; }
        public int MaxExperience { get; set; }

        public BeerUser()
        {
        }

        private string StringLengthSmalerOrEqual(string str, int max, string variableName)
        {
            if (str.Length <= max)
            {
                return str;
            }
            else
            {
                throw new BeerException("Too much characters in the string '" + variableName + "'. Maximum " + max.ToString() + " characters.");
            }
        }
    }
}