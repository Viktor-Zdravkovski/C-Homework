using ClassEx1.Domain.Domain;
using ClassEx1.Domain.Domain.Models;

PetStore<Dog> dogStore = new PetStore<Dog>();
PetStore<Cat> catStore = new PetStore<Cat>();
PetStore<Fish> fishStore = new PetStore<Fish>();

Dog dog1 = new Dog("Sam", "Sarplaninec", 5, true, "wolves");
Dog dog2 = new Dog("Dimche", "Labrador", 4, false, "bread");

Cat cat1 = new Cat("Surko", "cat", 12, true, 3);
Cat cat2 = new Cat("Dime", "cat", 12, false, 9);

Fish fish1 = new Fish("Krokodil", "skusha", 5, "white", "27cm");
Fish fish2 = new Fish("Delfin", "pastrmka", 5, "black", "32cm");

dogStore.BringPet(dog1);
dogStore.BringPet(dog2);
catStore.BringPet(cat1);
catStore.BringPet(cat2);
fishStore.BringPet(fish1);
fishStore.BringPet(fish2);
dogStore.BuyPet("Bob");
catStore.BuyPet("Surko");
//fishStore.BuyPet("Damjana");
dogStore.PrintPets();
catStore.PrintPets();
fishStore.PrintPets();