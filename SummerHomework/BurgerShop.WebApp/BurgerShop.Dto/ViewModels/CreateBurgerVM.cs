namespace BurgerShop.Dto.ViewModels
{
	public class CreateBurgerVM
	{
		public string Name { get; set; }

		public bool IsVegetarian { get; set; }

		public bool IsVegan { get; set; }

		public bool HasFires { get; set; }

		public int BurgerId { get; set; }

		public int OrdredId { get; set; }
	}
}
