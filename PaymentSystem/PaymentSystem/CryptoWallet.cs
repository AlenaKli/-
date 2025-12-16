using System;

namespace PaymentSystem
{
    // Класс CryptoWallet наследуется от WalletGateway
    public class CryptoWallet : WalletGateway
    {
        // Приватное поле
        private string _network;

        // Свойство с валидацией
        public string Network
        {
            get { return _network; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Сеть не может быть пустой");
                _network = value;
            }
        }

        // Конструктор
        public CryptoWallet(string providerName, bool sandbox = false)
            : base(providerName, sandbox)
        {
            _network = "BTC"; // Значение по умолчанию
        }

        // Невиртуальный метод: переключает сеть
        public void SwitchNetwork(string network)
        {
            Network = network;
            Console.WriteLine($"Сеть изменена на {network}");
        }

        // Переопределение виртуального метода Process (от "деда" PaymentGateway)
        public override string Process(decimal amount)
        {
            return $"Crypto payment of {amount} processed in {Network} network via {ProviderName}";
        }
    }
}