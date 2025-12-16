using System;

namespace PaymentSystem
{
    // Класс WalletGateway наследуется от PaymentGateway
    public class WalletGateway : PaymentGateway
    {
        // Приватное поле
        private string _walletId;

        // Свойство с валидацией
        public string WalletId
        {
            get { return _walletId; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ID кошелька не может быть пустым");
                _walletId = value;
            }
        }

        // Конструктор
        public WalletGateway(string providerName, bool sandbox = false)
            : base(providerName, sandbox)
        {
            _walletId = "Not linked";
        }

        // Невиртуальный метод: связывает кошелек
        public void Link(string id)
        {
            WalletId = id;
            Console.WriteLine($"Кошелек {id} привязан");
        }

        // НЕ переопределяем метод Process (оставляем базовую реализацию)
    }
}