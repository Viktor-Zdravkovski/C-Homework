using BurgerShop.DataAccess.Interfaces;
using BurgerShop.Domain;

namespace BurgerShop.DataAccess.Implementations
{
    public class OrderRepository : IRepository<Order>
    {
        public IEnumerable<Order> GetAll()
        {
            return InMemoryDB.Orders;
        }

        public Order GetById(int id)
        {
            return InMemoryDB.Orders.FirstOrDefault(o => o.Id == id);
        }

        public void Add(Order entity)
        {
            entity.Id = InMemoryDB.Orders.Count + 1;
            InMemoryDB.Orders.Add(entity);
        }

        public void Update(Order entity)
        {
            var order = GetById(entity.Id);

            if (order != null)
            {
                var orderIndex = InMemoryDB.Orders.IndexOf(order);
                InMemoryDB.Orders[orderIndex] = entity;
            }
        }

        public void Delete(int id)
        {
            var order = GetById(id);

            if (order != null)
            {
                InMemoryDB.Orders.Remove(order);
            }
        }
    }
}
