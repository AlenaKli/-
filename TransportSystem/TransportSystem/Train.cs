using TransportSystem;

namespace SeparateTransport
{
    // Класс Train наследуется от Vehicle
    public class Train : Vehicle
    {
        // Дополнительное свойство
        public int CarriagesCount;  // Количество вагонов

        // Конструктор
        public Train(string make, int maxSpeed, int carriages)
            : base(make, maxSpeed)  // Вызов конструктора родителя
        {
            CarriagesCount = carriages;
        }

        // Переопределение метода Info
        public override void Info()
        {
            base.Info();  // Вызов метода родителя
            Console.WriteLine($"Количество вагонов: {CarriagesCount}");
            Console.WriteLine($"Тип: Поезд");
            Console.WriteLine();
        }
    }
}