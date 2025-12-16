using System;

namespace OnlineStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Тестирование системы товаров и склада ===\n");

            // Часть 1: Тестирование SimpleProduct
            Console.WriteLine("1. ТЕСТИРОВАНИЕ SIMPLEPRODUCT:");
            Console.WriteLine("-----------------------------");

            SimpleProduct simpleProduct = new SimpleProduct("Книга", 1000);
            Console.WriteLine("Создан товар: " + simpleProduct.GetInfo());

            // Применяем скидку 20%
            simpleProduct.ApplyDiscount(20);
            Console.WriteLine("После скидки 20%: " + simpleProduct.GetInfo());

            // Применяем скидку 90% (цена должна упасть до 0)
            simpleProduct.Price = 1000; // Возвращаем цену
            simpleProduct.ApplyDiscount(90);
            Console.WriteLine("После скидки 90%: " + simpleProduct.GetInfo());

            Console.WriteLine();

            // Часть 2: Тестирование WarehouseItem
            Console.WriteLine("2. ТЕСТИРОВАНИЕ WAREHOUSEITEM:");
            Console.WriteLine("------------------------------");

            WarehouseItem warehouseItem = new WarehouseItem("Ноутбук", 50000, 10, 40000);
            Console.WriteLine("Создан товар на складе: " + warehouseItem.GetInfo());

            // Проверяем резервирование товара
            Console.WriteLine("\nПроверка резервирования товара:");
            Console.WriteLine("Пытаемся зарезервировать 3 шт.: " + (warehouseItem.Reserve(3) ? "Успешно" : "Не удалось"));
            Console.WriteLine("Остаток на складе: " + warehouseItem.Stock + " шт.");

            Console.WriteLine("Пытаемся зарезервировать 10 шт. (больше чем есть): " +
                (warehouseItem.Reserve(10) ? "Успешно" : "Не удалось"));
            Console.WriteLine("Остаток на складе: " + warehouseItem.Stock + " шт.");

            Console.WriteLine("\nПроверка скидок с минимальной ценой:");
            Console.WriteLine("Исходная цена: " + warehouseItem.Price + " руб.");

            // Применяем скидку 10%
            warehouseItem.ApplyDiscount(10);
            Console.WriteLine("После скидки 10%: " + warehouseItem.Price + " руб.");

            // Возвращаем исходную цену и применяем скидку 30%
            warehouseItem.Price = 50000;
            warehouseItem.ApplyDiscount(30);
            Console.WriteLine("После скидки 30%: " + warehouseItem.Price + " руб.");

            // Пытаемся применить скидку больше 20% (цена должна упасть до минимальной)
            warehouseItem.Price = 50000;
            warehouseItem.ApplyDiscount(25);
            Console.WriteLine("После скидки 25% (не ниже мин. цены): " + warehouseItem.Price + " руб.");

            Console.WriteLine();

            // Часть 3: Демонстрация работы через интерфейсы
            Console.WriteLine("3. ДЕМОНСТРАЦИЯ ЧЕРЕЗ ИНТЕРФЕЙСЫ:");
            Console.WriteLine("--------------------------------");

            // Используем интерфейс IProduct
            IProduct product1 = new SimpleProduct("Мышь", 1500);
            IProduct product2 = new WarehouseItem("Клавиатура", 3000, 5, 2500);

            Console.WriteLine("Товар 1 (мышь) до скидки: " + product1.Price + " руб.");
            product1.ApplyDiscount(10);
            Console.WriteLine("Товар 1 после скидки 10%: " + product1.Price + " руб.");

            Console.WriteLine("\nТовар 2 (клавиатура) до скидки: " + product2.Price + " руб.");
            product2.ApplyDiscount(20);
            Console.WriteLine("Товар 2 после скидки 20%: " + product2.Price + " руб.");

            // Используем интерфейс IStockItem
            IStockItem stockItem = new WarehouseItem("Монитор", 15000, 3, 12000);

            Console.WriteLine("\nТовар на складе (монитор): " + ((WarehouseItem)stockItem).Stock + " шт.");
            bool result = stockItem.Reserve(2);
            Console.WriteLine("Резервируем 2 шт.: " + (result ? "Успешно" : "Не удалось"));
            Console.WriteLine("Остаток после резервирования: " + ((WarehouseItem)stockItem).Stock + " шт.");

            Console.WriteLine("\n=== Тестирование завершено ===");
            Console.ReadKey();
        }
    }
}