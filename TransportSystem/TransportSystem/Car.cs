using TransportSystem;

namespace SeparateTransport
{
    // Класс Car наследуется от Vehicle
    public class Car : Vehicle
    {
        // Дополнительное свойство
        public int PassengerSeats;  // Количество пассажирских мест

        // Конструктор
        public Car(string make, int maxSpeed, int seats)
            : base(make, maxSpeed)  // Вызов конструктора родителя
        {
            PassengerSeats = seats;
        }

        // Переопределение метода Info
        public override void Info()
        {
            base.Info();  // Вызов метода родителя
            Console.WriteLine($"Количество мест: {PassengerSeats}");
            Console.WriteLine($"Тип: Автомобиль");
            Console.WriteLine();
        }
    }
}