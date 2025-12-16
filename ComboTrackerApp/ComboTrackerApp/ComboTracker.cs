using System;

namespace ComboTrackerApp
{
    // Собственный делегат (требование задания)
    public delegate void ComboEventHandler(ComboTracker sender, int streak);

    public class ComboTracker
    {
        private int _currentStreak = 0;
        private Random _random = new Random();

        // Обычное событие на основе собственного делегата (требование 1, 2)
        public event ComboEventHandler? StreakChanged;

        // Внутреннее поле для кастомного события
        private EventHandler<int>? _milestoneReached;

        // Кастомное событие с add/remove (требование 3)
        public event EventHandler<int> MilestoneReached
        {
            add
            {
                _milestoneReached += value;
                Console.WriteLine($"Подписчик добавлен к MilestoneReached");
            }
            remove
            {
                _milestoneReached -= value;
                Console.WriteLine($"Подписчик удален из MilestoneReached");
            }
        }

        // Метод для запуска симуляции
        public void Start()
        {
            // Генерируем 12-16 шагов
            int steps = _random.Next(12, 17);
            Console.WriteLine($"Начинаем симуляцию на {steps} шагов\n");

            for (int i = 0; i < steps; i++)
            {
                // 70% шанс увеличить комбо, 30% сбросить
                if (_random.Next(100) < 70)
                {
                    // Увеличиваем комбо на 1-3
                    int increase = _random.Next(1, 4);
                    int oldStreak = _currentStreak;
                    _currentStreak += increase;

                    Console.WriteLine($"Шаг {i + 1}: Комбо увеличено на {increase}");

                    // Проверяем достижение рубежей (10, 20, 30...)
                    CheckMilestones(oldStreak, _currentStreak);
                }
                else
                {
                    // Сбрасываем комбо
                    _currentStreak = 0;
                    Console.WriteLine($"Шаг {i + 1}: Комбо сброшено");
                }

                // Вызываем обычное событие
                OnStreakChanged();
            }
        }

        // Метод для проверки достижения рубежей
        private void CheckMilestones(int oldValue, int newValue)
        {
            if (_milestoneReached == null)
                return;

            // Проверяем все рубежи от 10 до максимального возможного
            for (int milestone = 10; milestone <= newValue; milestone += 10)
            {
                if (oldValue < milestone && newValue >= milestone)
                {
                    // Вызываем кастомное событие
                    _milestoneReached?.Invoke(this, milestone);
                }
            }
        }

        // Метод для вызова обычного события
        private void OnStreakChanged()
        {
            StreakChanged?.Invoke(this, _currentStreak);
        }
    }
}