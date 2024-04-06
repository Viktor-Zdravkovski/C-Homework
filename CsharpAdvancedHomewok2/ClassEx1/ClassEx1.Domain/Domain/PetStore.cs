using ClassEx1.Domain.Domain.Models.BaseModel;

namespace ClassEx1.Domain.Domain
{
    public class PetStore<T> where T : Pet
    {
        public List<T> Pets;
        public PetStore()
        {
            Pets = new List<T>();
        }

        public void BringPet(T pet)
        {
            Pets.Add(pet);
        }

        public void PrintPets()
        {
            foreach (T pet in Pets)
            {
                pet.PrintInfo();
            }
        }

        public void BuyPet(string name)
        {
            T? pet = Pets.SingleOrDefault(x => x.Name == name);
            if (pet == null)
            {
                Console.WriteLine($"The pet with name {name} was not found in the Shop");
            }
            else
            {
                Console.WriteLine($"You sucessfully puchased the pet with name: {name}");
                Pets.Remove(pet);
            }
        }
    }
}
