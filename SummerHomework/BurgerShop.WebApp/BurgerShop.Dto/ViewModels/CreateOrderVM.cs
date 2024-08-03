using BurgerShop.Dto.Dto;

namespace BurgerShop.Dto.ViewModels
{
    public class CreateOrderVM
    {
        public List<BurgerDto>? Burgers { get; set; }

        public DateTime? OrderDate { get; set; }

        public string? OrderName { get; set; }

        public int BurgerId { get; set; }

        public int OrderId { get; set; }

    }
}
