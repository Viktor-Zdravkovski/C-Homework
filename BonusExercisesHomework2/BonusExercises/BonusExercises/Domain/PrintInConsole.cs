namespace BonusExercises
{
    public class PrintInConsole<T>
    {
        public void Print(T item)
        {
            Console.WriteLine(item);
        }

        public void PrinCollection(List<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
