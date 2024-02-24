using ConsoleUtils;
using Zoo.Models;

namespace Zoo
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            Animal lev = new Lion("Лев");
            Animal elephant = new Elephant("Слон");

            animals.Add(lev);
            animals.Add(elephant);
        }
    }
}
