using BurgerShop.Domain;

namespace BurgerShop.Services.Interfaces
{
	public interface IBurgerService
    {
        List<Burger> ShowAllBurgers(int? burgerId);

        void EditBurger(Burger burger);

        void AddBurger(Burger burger);

        void RemoveBurger(Burger burgerId);

        Burger MostPopularBurer(int? burgerId);

        //List<Order> ServicedOrders();

        //double AverageOrderPrice();

        //List<Location> BurgerLocations();


    }
}
