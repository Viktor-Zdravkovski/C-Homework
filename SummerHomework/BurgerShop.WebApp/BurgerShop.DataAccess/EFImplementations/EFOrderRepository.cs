using BurgerShop.DataAccess.Interfaces;
using BurgerShop.Domain;

namespace BurgerShop.DataAccess.EFImplementations
{
    public class EFOrderRepository : IRepository<Order>
    {
        private readonly BurgerShopDbContext _context;

        public EFOrderRepository(BurgerShopDbContext context)
        {
            _context = context;
        }

        public Order GetById(int id)
        {
            return _context.Order.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Order.ToList();
        }

        public void Add(Order entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Order entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                Order order = GetById(id);

                if (order != null)
                {
                    _context.Order.Remove(order);
                    _context.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
