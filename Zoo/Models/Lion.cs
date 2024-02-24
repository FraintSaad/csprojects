namespace Zoo.Models
{
    internal class Lion : Animal
    {
        public string Nickname = "lionchik";
        public override void Move()
        {
            Console.WriteLine($"Lion {Name} moved");
        }

        public override void MakeSound()
        {
            Console.WriteLine("Рык рык");
        }

        public void Jump()
        {
            Console.WriteLine("I am jumping!");
        }

        public Lion(string name) : base(name)
        {

        }
    }
}
