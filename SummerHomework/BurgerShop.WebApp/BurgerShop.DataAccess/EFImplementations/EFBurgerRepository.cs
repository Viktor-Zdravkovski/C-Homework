using BurgerShop.DataAccess.Interfaces;
using BurgerShop.Domain;

namespace BurgerShop.DataAccess.EFImplementations
{
    public class EFBurgerRepository : IRepository<Burger>
    {
        private readonly BurgerShopDbContext _context;

        public EFBurgerRepository(BurgerShopDbContext context)
        {
            _context = context;
        }

        public EFBurgerRepository()
        {

        }

        public Burger GetById(int id)
        {
            return _context.Burger.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Burger> GetAll()
        {
            return _context.Burger.ToList();
        }

        public void Add(Burger entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Burger entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                Burger burger = GetById(id);

                if (burger != null)
                {
                    _context.Remove(burger);
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
