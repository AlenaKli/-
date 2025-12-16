using System;

namespace ComboTrackerApp
{
    public class StreakStats
    {
        private int _resetCount = 0;
        private int _maxStreak = 0;

        // Конструктор принимает трекер и подписывается на событие
        public StreakStats(ComboTracker tracker)
        {
            tracker.StreakChanged += OnStreakChanged;
        }

        // Обработчик изменения комбо (только для статистики)
        private void OnStreakChanged(ComboTracker sender, int streak)
        {
            // Обновляем максимальное комбо
            if (streak > _maxStreak)
                _maxStreak = streak;

            // Считаем сбросы (когда комбо = 0 и предыдущее было > 0)
            // Но в нашем случае считаем сбросы по факту, когда комбо становится 0
            if (streak == 0)
                _resetCount++;
        }

        // Метод для вывода отчета
        public void Report()
        {
            Console.WriteLine($"Сбросов: {_resetCount}; Максимальное комбо: {_maxStreak}");
        }
    }
}