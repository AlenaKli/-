using System;

namespace OrderProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Обработка заказа в интернет-магазине ===\n");

            // Создаем контекст заказа
            OrderContext order = new OrderContext();
            Console.WriteLine("Создан новый заказ:");
            Console.WriteLine($"Наличие товара: {order.HasStock}");
            Console.WriteLine($"Стоимость доставки: {order.DeliveryCost}");
            Console.WriteLine($"Подтвержден: {order.IsConfirmed}");
            Console.WriteLine();

            // Создаем пайплайн обработки
            OrderPipeline pipeline = new OrderPipeline();

            // Добавляем обработчики через +=
            Console.WriteLine("Добавляем обработчики в пайплайн...");
            pipeline.Pipeline += OrderHandlers.CheckStock;
            pipeline.Pipeline += OrderHandlers.CalculateDelivery;

            // Добавляем обработчик как лямбда-выражение (требование задания)
            pipeline.Pipeline += (context) =>
            {
                context.IsConfirmed = true;
            };

            // Запускаем пайплайн
            Console.WriteLine("Запускаем пайплайн обработки...");
            pipeline.Run(order);

            // Выводим результат
            Console.WriteLine("\nПосле обработки пайплайном:");
            Console.WriteLine($"Наличие товара: {order.HasStock}");
            Console.WriteLine($"Стоимость доставки: {order.DeliveryCost}");
            Console.WriteLine($"Подтвержден: {order.IsConfirmed}");
            Console.WriteLine();

            // Демонстрация удаления обработчика
            Console.WriteLine("Удаляем обработчик CheckStock из пайплайна...");
            pipeline.Pipeline -= OrderHandlers.CheckStock;

            // Создаем новый заказ для демонстрации
            OrderContext order2 = new OrderContext();
            Console.WriteLine("\nСоздан второй заказ:");
            Console.WriteLine($"Наличие товара: {order2.HasStock} (проверка не выполнится)");
            Console.WriteLine($"Стоимость доставки: {order2.DeliveryCost}");
            Console.WriteLine($"Подтвержден: {order2.IsConfirmed}");
            Console.WriteLine();

            Console.WriteLine("Запускаем пайплайн для второго заказа...");
            pipeline.Run(order2);

            Console.WriteLine("\nРезультат обработки второго заказа:");
            Console.WriteLine($"Наличие товара: {order2.HasStock} (осталось false)");
            Console.WriteLine($"Стоимость доставки: {order2.DeliveryCost}");
            Console.WriteLine($"Подтвержден: {order2.IsConfirmed}");
            Console.WriteLine();

            // Демонстрация с пустым пайплайном
            Console.WriteLine("Создаем пустой пайплайн...");
            OrderPipeline emptyPipeline = new OrderPipeline();
            OrderContext order3 = new OrderContext();

            Console.WriteLine("Запускаем пустой пайплайн...");
            emptyPipeline.Run(order3);

            Console.WriteLine("Заказ не изменился (пайплайн пустой):");
            Console.WriteLine($"Наличие товара: {order3.HasStock}");
            Console.WriteLine($"Стоимость доставки: {order3.DeliveryCost}");
            Console.WriteLine($"Подтвержден: {order3.IsConfirmed}");

            Console.WriteLine("\n=== Обработка завершена ===");
            Console.ReadKey();
        }
    }
}