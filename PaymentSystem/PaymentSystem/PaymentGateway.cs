using System;

namespace PaymentSystem
{
    // Базовый класс PaymentGateway
    public class PaymentGateway
    {
        // Приватные поля
        private string _providerName;
        private bool _sandbox;

        // Свойства с валидацией
        public string ProviderName
        {
            get { return _providerName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя провайдера не может быть пустым");
                _providerName = value;
            }
        }

        public bool Sandbox
        {
            get { return _sandbox; }
            set { _sandbox = value; }
        }

        // Конструктор
        public PaymentGateway(string providerName, bool sandbox = false)
        {
            ProviderName = providerName;
            Sandbox = sandbox;
        }

        // Невиртуальный метод 1: переключает режим sandbox
        public void EnableSandbox(bool on)
        {
            Sandbox = on;
            Console.WriteLine($"Режим Sandbox {(on ? "включен" : "выключен")}");
        }

        // Невиртуальный метод 2: возвращает информацию
        public string Info()
        {
            return $"Провайдер: {ProviderName}, Режим: {(Sandbox ? "Sandbox" : "Production")}";
        }

        // Виртуальный метод для обработки платежа
        public virtual string Process(decimal amount)
        {
            return $"Processed {amount} via base";
        }
    }
}