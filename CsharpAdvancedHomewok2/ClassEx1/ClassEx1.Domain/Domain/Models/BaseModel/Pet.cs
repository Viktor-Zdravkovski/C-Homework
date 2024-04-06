namespace ClassEx1.Domain.Domain.Models.BaseModel
{
    public abstract class Pet
    {
        public string Name { get; }
        public string Type { get; }
        public int Age { get; }

        public Pet(string name, string type, int age)
        {
            Name = name;
            Type = type;
            Age = age;
        }

        public abstract void PrintInfo();
    }
}
