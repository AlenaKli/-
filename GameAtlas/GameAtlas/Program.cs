using System;

namespace SimpleAtlas
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Тест Атласа ===\n");

            // Создаем атлас
            Atlas atlas = new Atlas();

            // Создаем локации
            Location loc1 = new Location("forest", "Лес", RegionRank.Regional);
            loc1.AddPoi(new PointOfInterest("tree", "Старое дерево", 3));

            Location loc2 = new Location("city", "Город", RegionRank.Capital);
            loc2.AddPoi(new PointOfInterest("castle", "Замок", 5));

            Location loc3 = new Location("mountain", "Гора", RegionRank.Sacred);
            loc3.AddPoi(new PointOfInterest("temple", "Храм", 4));

            // Добавляем в атлас
            atlas.Add(loc1);
            atlas.Add(loc2);
            atlas.Add(loc3);

            // Тест 1: Доступ по индексу
            Console.WriteLine("1. По индексу:");
            Console.WriteLine($"   [0]: {atlas[0].Name}");
            Console.WriteLine($"   [1]: {atlas[1].Name}");
            Console.WriteLine($"   [2]: {atlas[2].Name}");

            // Тест 2: Доступ по Id
            Console.WriteLine("\n2. По ID:");
            Console.WriteLine($"   [\"forest\"]: {atlas["forest"].Name}");
            Console.WriteLine($"   [\"city\"]: {atlas["city"].Name}");

            // Тест 3: foreach
            Console.WriteLine("\n3. Все локации:");
            foreach (Location loc in atlas)
            {
                Console.WriteLine($"   - {loc.Name} (POI: {loc.PointsOfInterest.Count})");
            }

            // Тест 4: EnumerateByRank
            Console.WriteLine("\n4. Локации с рангом >= Capital:");
            foreach (Location loc in atlas.EnumerateByRank(RegionRank.Capital))
            {
                Console.WriteLine($"   - {loc.Name} ({loc.Rank})");
            }

            // Тест 5: Удаление
            Console.WriteLine("\n5. Удаляем первую локацию:");
            bool removed = atlas.RemoveAt(0);
            Console.WriteLine($"   Удалено: {removed}");
            Console.WriteLine($"   Осталось: {atlas.Count}");

            Console.WriteLine("\n6. Проверяем что удалилось:");
            try
            {
                // Попытка получить удаленную локацию по ID
                var test = atlas["forest"];
                Console.WriteLine("   Ошибка: локация forest все еще существует!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Локация forest удалена: {ex.Message}");
            }

            Console.WriteLine("\n=== Конец теста ===");
            Console.ReadKey();
        }
    }
}