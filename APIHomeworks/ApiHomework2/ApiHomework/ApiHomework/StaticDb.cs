using ApiHomework.Model;

namespace ApiHomework
{
    public class StaticDb
    {
        public static List<Book> Books { get; set; } = new List<Book>()
        {
            new Book()
            {
                Author = "Leo Tolstoy",
                Title = "War & Peace"
            },

            new Book()
            {
                Author = "Arthur Morgan",
                Title= "Dutch Van Der Linde"
            },

            new Book()
            {
                Author = "Franz Kafka",
                Title = "The Metamorphosis"
            }
        };
    }
}
