namespace Zoo.Models
{
    internal class Elephant : Animal
    {
        public Elephant(string name) : base(name) { }

        public override void Move()
        {
            Console.WriteLine("Elephant moves");
        }
    }
}
