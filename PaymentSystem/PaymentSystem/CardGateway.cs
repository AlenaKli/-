using System;

namespace PaymentSystem
{
    // Класс CardGateway наследуется от PaymentGateway
    public class CardGateway : PaymentGateway
    {
        // Приватное поле
        private string _maskedPan;

        // Свойство с валидацией
        public string MaskedPan
        {
            get { return _maskedPan; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 19)
                    throw new ArgumentException("PAN должен быть в формате '**** **** **** 1234'");
                _maskedPan = value;
            }
        }

        // Конструктор
        public CardGateway(string providerName, bool sandbox = false)
            : base(providerName, sandbox)
        {
            // Инициализируем пустым значением
            _maskedPan = "**** **** **** ****";
        }

        // Невиртуальный метод: устанавливает маскированный PAN
        public void SetMaskedPan(string pan)
        {
            MaskedPan = pan;
        }

        // Переопределение виртуального метода Process
        public override string Process(decimal amount)
        {
            return $"Card payment of {amount} processed via {ProviderName}. Card: {MaskedPan}";
        }
    }
}