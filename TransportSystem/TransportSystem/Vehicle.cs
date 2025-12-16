using System;

namespace SeparateTransport
{
    // Базовый класс Vehicle
    public class Vehicle
    {
        // Поля класса
        public string Make;        // Марка транспортного средства
        public int MaxSpeed;       // Максимальная скорость

        // Конструктор
        public Vehicle(string make, int maxSpeed)
        {
            Make = make;
            MaxSpeed = maxSpeed;
        }

        // Виртуальный метод для вывода информации
        public virtual void Info()
        {
            Console.WriteLine($"Марка: {Make}, Макс. скорость: {MaxSpeed} км/ч");
        }
    }
}