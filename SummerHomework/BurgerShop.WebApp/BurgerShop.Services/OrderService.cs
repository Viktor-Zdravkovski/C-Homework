using BurgerShop.DataAccess.Interfaces;
using BurgerShop.Domain;
using BurgerShop.Services.Interfaces;

namespace BurgerShop.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<Burger> _burgerRepo;

        public OrderService(IRepository<Order> order, IRepository<Burger> burgerRepo)
        {
            _orderRepo = order;
            _burgerRepo = burgerRepo;
        }

        public void AddOrder(Order order)
        {
            var addedOrder = new Order
            {
                Address = order.Address,
                FullName = order.FullName,
                Burgers = order.Burgers,
                IsDelivered = order.IsDelivered,
                Location = order.Location,
            };

            _orderRepo.Add(addedOrder);
        }

        public void EditOrder(Order order)
        {
            var orderToEdit = _orderRepo.GetAll().FirstOrDefault(x => x.Id == order.Id);

            if (orderToEdit == null)
            {
                throw new ArgumentException("Order doesn't exit");
            }

            orderToEdit.Address = order.Address;
            orderToEdit.FullName = order.FullName;
            orderToEdit.Burgers = order.Burgers;
            orderToEdit.IsDelivered = order.IsDelivered;
            orderToEdit.Location = order.Location;

            _orderRepo.Update(orderToEdit);
        }

        public void RemoveOrder(Order order)
        {
            if (order == null || order.Id <= 0)
            {
                throw new ArgumentException("Invalid order object");
            }

            _orderRepo.Delete(order.Id);
        }

        public List<Order> ServicedOrders(int? orderId, int? burgerId)
        {
            var orders = _orderRepo.GetAll();

            //orders.GroupBy(x => x.Id)
            //      .Count();

            //return orders.ToList();

            var servicedOrders = orders.GroupBy(x => x.Id)
                                       .SelectMany(y => y)
                                       .ToList();

            return servicedOrders;
        }

        public double AverageOrderPrice()
        {
            var burgerPrice = _burgerRepo.GetAll();

            //return burgerPrice.Average(x => x.Price);

            if (burgerPrice == null || !burgerPrice.Any())
            {
                return 0;
            }

            return burgerPrice.Average(x => x.Price);
        }

        public List<Location> BurgerLocations()
        {
            //var alllocations = _orderrepo.getall();

            //var locations = new list<location>();

            //foreach (var location in alllocations)
            //{

            //}

            var allorders = _orderRepo.GetAll();

            var locations = new List<Location>();

            foreach (var order in allorders)
            {
                if (order.Location != null)
                {
                    locations.Add(order.Location);
                }
            }

            return locations;
        }
    }
}
