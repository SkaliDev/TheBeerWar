using BeerService.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeerService.Model.ViewModels
{
    public class DashboardViewModel
    {
        [Required]
        public BeerUser beerUser { get; set; }
        public UserWeapon userWeaponInUse { get; set; }
        public List<UserWeapon> userWeapons { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }

    //public class Chat
    //{
    //    public string Name { get; set; }
    //    public DateTime Time { get; set; }
    //    public string Content { get; set; }
    //}
}
