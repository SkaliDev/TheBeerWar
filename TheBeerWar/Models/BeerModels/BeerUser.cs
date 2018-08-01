using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheBeerWar.Exceptions;

namespace TheBeerWar.Models.BeerModels
{
    public class BeerUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
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

        private string StringLengthSmalerOrEqual(string str, int max, string variableName)
        {
            if (str.Length <= max)
            {
                return str;
            }
            else
            {
                throw new BeerWarException("Too much characters in the string '" + variableName + "'. Maximum " + max.ToString() + " characters.");
            }
        }
    }
}