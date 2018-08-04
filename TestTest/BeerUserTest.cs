using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerService.Infrastructure;
using BeerService.Models;

namespace TestTest
{
    [TestClass]
    public class BeerUserTest
    {
        [TestMethod]
        public void CreateDeleteBeerUser()
        {
            using (IDalBeer dal = new DalBeer())
            {
                var beerUser = dal.GetBeerUserByPseudonym("TheFirstUser");
                if (beerUser != null)
                    dal.DeleteBeerUser(beerUser);
                beerUser = dal.GetBeerUserByPseudonym("TheSecondUser");
                if (beerUser != null)
                    dal.DeleteBeerUser(beerUser);

                dal.CreateBeerUser("0", dal.GetGamerTypeByName("Archer"), "TheFirstUser");
                dal.CreateBeerUser("0", dal.GetGamerTypeByName("Sorcier"), "TheSeconfUser");

                List<BeerUser> users = dal.GetAllBeerUsers();

                Assert.IsNotNull(users);
                Assert.AreEqual("TheFirstUser", dal.GetBeerUserByPseudonym("TheFirstUser").Pseudonym);
                Assert.AreEqual("TheSeconfUser", dal.GetBeerUserByPseudonym("TheSecondUser").Pseudonym);

                dal.DeleteBeerUser(dal.GetBeerUserByPseudonym("TheFirstUser"));
                dal.DeleteBeerUser(dal.GetBeerUserByPseudonym("TheSecondUser"));
            }
        }
    }
}
