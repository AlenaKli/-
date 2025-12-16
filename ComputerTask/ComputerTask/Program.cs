using System;

namespace ComputerTask
{
    public class Computer
    {
        private string manufacturer;
        private string model;
        private int ram;

        public Computer(string manufacturer, string model, int ram)
        {
            this.manufacturer = manufacturer;
            this.model = model;
            this.ram = ram;
        }

        public void ExpandMemory(int additionalRAM)
        {
            ram += additionalRAM;
        }

        public override string ToString()
        {
            return $"Computer: {manufacturer} {model}, RAM: {ram} GB";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Testing Computer Class ===\n");

            Computer myPC = new Computer("Dell", "XPS 15", 16);
            Console.WriteLine("Created: " + myPC.ToString());

            myPC.ExpandMemory(8);
            Console.WriteLine("After +8GB: " + myPC.ToString());

            Console.WriteLine("\nCreating another computer...");
            Computer laptop = new Computer("Apple", "MacBook Pro", 8);
            Console.WriteLine(laptop.ToString());

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}