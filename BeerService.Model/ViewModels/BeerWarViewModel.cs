using BeerService.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerService.Model.ViewModels
{
    public class BeerWarViewModel
    {
        public BeerUser beerUser { get; set; }
        public UserWeapon userWeaponInUse { get; set; }
        public List<BeerUser> beerUsers { get; set; }
        public List<BeerUser> beerUsersPage { get; private set; }
        public string Search { get; set; }
        public int NumberOfPages { get; set; }
        public int? SelectedPage { get; set; }
        public string ResultFight { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public BeerWarViewModel()
        {
            SelectedPage = 1;
        }

        public void Pagination()
        {
            float beerUsersCount = beerUsers.Count;
            beerUsersCount = beerUsersCount / 10;

            NumberOfPages = beerUsers.Count / 10;
            if (NumberOfPages == 0)
                NumberOfPages = 1;
            else if (NumberOfPages < beerUsersCount)
                NumberOfPages++;

            if (SelectedPage == null || SelectedPage <= 0)
                SelectedPage = 1;
            else if (SelectedPage > NumberOfPages)
                SelectedPage = NumberOfPages;

            beerUsersPage = new List<BeerUser>();
            int flag = ((int)SelectedPage * 10);
            if (flag > beerUsers.Count)
                flag = beerUsers.Count;

            for (int i = ((int)SelectedPage * 10) - 9; i <= flag; i++)
                beerUsersPage.Add(beerUsers[i - 1]);
        }
    }
}
