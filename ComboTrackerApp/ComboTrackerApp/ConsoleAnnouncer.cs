using System;

namespace ComboTrackerApp
{
    public class ConsoleAnnouncer
    {
        // Конструктор принимает трекер и подписывается на события
        public ConsoleAnnouncer(ComboTracker tracker)
        {
            // Подписываемся на обычное событие
            tracker.StreakChanged += OnStreakChanged;

            // Подписываемся на кастомное событие
            tracker.MilestoneReached += OnMilestoneReached;
        }

        // Обработчик изменения комбо
        private void OnStreakChanged(ComboTracker sender, int streak)
        {
            Console.WriteLine($"Комбо: {streak}");
        }

        // Обработчик достижения рубежа
        private void OnMilestoneReached(object? sender, int milestone)
        {
            Console.WriteLine($"Рубеж комбо: {milestone}! Держи темп!");
        }

        // Метод для отписки от кастомного события
        public void UnsubscribeFromMilestone(ComboTracker tracker)
        {
            tracker.MilestoneReached -= OnMilestoneReached;
        }
    }
}