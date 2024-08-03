using BurgerShop.DataAccess.Interfaces;
using BurgerShop.Domain;
using BurgerShop.Dto.Dto;
using BurgerShop.Mapper;
using BurgerShop.Services.Interfaces;

namespace BurgerShop.Services
{
    public class FilterService : IFilterService
    {
        private readonly IRepository<Burger> _burgerRepo;
        private readonly IRepository<Order> _orderRepo;

        public FilterService(IRepository<Burger> burger, IRepository<Order> order)
        {
            _burgerRepo = burger;
            _orderRepo = order;
        }

        public List<BurgerDto> GetBurgers()
        {
            return _burgerRepo.GetAll().Select(x => x.Map()).ToList();
        }

        public List<OrderDto> GetOrders()
        {
            return _orderRepo.GetAll().Select(x => x.Map()).ToList();
        }

        public FilterDto GetFilteredDetails()
        {
            return new FilterDto
            {
                Burgers = GetBurgers(),
                Orders = GetOrders()
            };
        }
    }
}
