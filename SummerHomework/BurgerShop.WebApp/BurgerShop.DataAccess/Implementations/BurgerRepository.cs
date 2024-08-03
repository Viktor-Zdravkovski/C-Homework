using BurgerShop.DataAccess.Interfaces;
using BurgerShop.Domain;

namespace BurgerShop.DataAccess.Implementations
{
    public class BurgerRepository : IRepository<Burger>
    {
        public Burger GetById(int id)
        {
            return InMemoryDB.Burgers.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<Burger> GetAll()
        {
            return InMemoryDB.Burgers;
        }

        public void Add(Burger entity)
        {
            entity.Id = InMemoryDB.Burgers.Count + 1;
            InMemoryDB.Burgers.Add(entity);
        }

        public void Update(Burger entity)
        {
            var burger = GetById(entity.Id);

            if (burger != null)
            {
                var burgerIndex = InMemoryDB.Burgers.IndexOf(burger);
                InMemoryDB.Burgers[burgerIndex] = burger;
            }
        }

        public void Delete(int id)
        {
            var burger = GetById(id);

            if (burger != null)
            {
                InMemoryDB.Burgers.Remove(burger);
            }
        }
    }
}
