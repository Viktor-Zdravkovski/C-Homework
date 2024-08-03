namespace BurgerShop.Dto.Dto
{
    public class FilterDto
    {
        public List<BurgerDto>? Burgers { get; set; }

        public List<OrderDto>? Orders { get; set; }

        public int BurgerId { get; set; }

        public int OrderId { get; set; }
    }
}
