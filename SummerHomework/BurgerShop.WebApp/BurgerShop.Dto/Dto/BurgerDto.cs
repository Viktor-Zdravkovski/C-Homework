namespace BurgerShop.Dto.Dto
{
    public class BurgerDto
    {
        public int Id { get; set; }

		public string? Name { get; set; }

		public int Price { get; set; }

		public bool IsVegetarian { get; set; }

		public bool IsVegan { get; set; }

		public bool HasFries { get; set; }

		//public bool IsSelected { get; set; }
	}
}
