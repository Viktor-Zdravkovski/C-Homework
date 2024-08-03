using BurgerShop.DataAccess.Interfaces;
using BurgerShop.Domain;

namespace BurgerShop.Services.Interfaces
{
    public interface IOrderService
    {
        void AddOrder(Order order);

        void EditOrder(Order order);

        void RemoveOrder(Order order);

        List<Order> ServicedOrders(int? orderId, int? burgerId);

        double AverageOrderPrice();

    }
}
