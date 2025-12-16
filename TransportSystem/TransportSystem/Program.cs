using System;
using TransportSystem;

namespace SeparateTransport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем автомобиль
            Car car = new Car("Toyota", 180, 5);

            // Создаем поезд
            Train train = new Train("Сапсан", 250, 10);

            Console.WriteLine("ИНФОРМАЦИЯ ОБ АВТОМОБИЛЕ:");
            car.Info();

            Console.WriteLine("ИНФОРМАЦИЯ О ПОЕЗДЕ:");
            train.Info();

            // Дополнительные примеры
            Car car2 = new Car("Lada", 150, 4);
            Train train2 = new Train("Ласточка", 200, 8);

            Console.WriteLine("ЕЩЕ АВТОМОБИЛЬ:");
            car2.Info();

            Console.WriteLine("ЕЩЕ ПОЕЗД:");
            train2.Info();
        }
    }
}