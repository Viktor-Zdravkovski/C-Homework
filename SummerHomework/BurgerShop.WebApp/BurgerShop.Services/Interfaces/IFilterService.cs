using BurgerShop.Dto.Dto;

namespace BurgerShop.Services.Interfaces
{
    public interface IFilterService
    {
        List<OrderDto> GetOrders();

        List<BurgerDto> GetBurgers();

        FilterDto GetFilteredDetails();
    }
}
