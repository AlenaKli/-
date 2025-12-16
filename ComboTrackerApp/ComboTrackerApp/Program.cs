using System;

namespace ComboTrackerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Трекер комбо-серии ===\n");

            // 1. Создаем экземпляр трекера
            ComboTracker tracker = new ComboTracker();

            // 2. Создаем подписчиков
            ConsoleAnnouncer announcer = new ConsoleAnnouncer(tracker);
            StreakStats stats = new StreakStats(tracker);

            // 3. Запускаем симуляцию
            tracker.Start();

            // 4. Отписываем announcer от события MilestoneReached
            Console.WriteLine("\nОтписываем ConsoleAnnouncer от MilestoneReached:");
            announcer.UnsubscribeFromMilestone(tracker);

            // 5. Выводим статистику
            Console.WriteLine("\nСтатистика:");
            stats.Report();

            Console.WriteLine("\n=== Симуляция завершена ===");
            Console.ReadKey();
        }
    }
}