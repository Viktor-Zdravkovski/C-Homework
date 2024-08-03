using BurgerShop.DataAccess.Interfaces;
using BurgerShop.Domain;
using BurgerShop.Services.Interfaces;
using System.Xml.Linq;

namespace BurgerShop.Services
{
    public class BurgerService : IBurgerService
    {
        private readonly IRepository<Burger> _burgerRepo;

        public BurgerService(IRepository<Burger> burgerRepo)
        {
            _burgerRepo = burgerRepo;
        }

        public List<Burger> ShowAllBurgers(int? burgerId)
        {
            var allBurgers = _burgerRepo.GetAll();

            if (burgerId.HasValue && burgerId > 0)
            {
                allBurgers = allBurgers.Where(x => x.Id == burgerId).ToList();
            }

            var burger = new List<Burger>();

            foreach (var burgers in allBurgers)
            {
                burger.Add(new Burger()
                {
                    Id = burgers.Id,
                    Name = burgers.Name,
                    HasFries = burgers.HasFries,
                    IsVegan = burgers.IsVegan,
                    IsVegetarian = burgers.IsVegetarian,
                    Price = burgers.Price
                });
            }

            return burger;
        }

        public void EditBurger(Burger burger)
        {
            var burgerToEdit = _burgerRepo.GetAll().FirstOrDefault(x => x.Id == burger.Id);

            if (burgerToEdit == null)
            {
                throw new Exception("Sorry we dont have such burger");
            }

            burgerToEdit.Name = burger.Name;
            burgerToEdit.IsVegan = burger.IsVegan;
            burgerToEdit.IsVegetarian = burger.IsVegetarian;
            burgerToEdit.HasFries = burger.HasFries;
            burgerToEdit.Price = burger.Price;

            _burgerRepo.Update(burgerToEdit);
        }

        public void AddBurger(Burger burger)
        {
            var addedBurger = new Burger
            {
                Name = burger.Name,
                HasFries = burger.HasFries,
                IsVegetarian = burger.IsVegetarian,
                IsVegan = burger.IsVegan,
                Price = burger.Price
            };

            _burgerRepo.Add(addedBurger);
        }

        public void RemoveBurger(Burger burger)
        {
            if (burger == null || burger.Id <= 0)
            {
                throw new ArgumentException("Invalid burger object");
            }

            _burgerRepo.Delete(burger.Id);
        }

        public Burger MostPopularBurer(int? burgerId)
        {
            var burgers = _burgerRepo.GetAll();

            //if (burgerId.HasValue && burgerId > 0)
            //{
            //    var burgers = _burgerRepo.GetAll();
            //    burgers.GroupBy(x => x.Id)
            //           .OrderByDescending(y => y.Count())                     MOE
            //           .Select(i => i)
            //           .ToList();
            //}

            //return burgers?.FirstOrDefault();

            if (burgerId.HasValue && burgerId > 0)
            {
                var mostPopularBurger = burgers.GroupBy(x => x.Id)
                                               .OrderByDescending(y => y.Count())            // CHATGPT
                                               .Select(i => i.FirstOrDefault())
                                               .FirstOrDefault();

                return mostPopularBurger;
            }

            return burgers.FirstOrDefault();
        }
    }
}


