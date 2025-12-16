using System;

namespace PaymentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Демонстрация платёжной системы ===\n");

            // 1. Тестируем базовый класс PaymentGateway
            Console.WriteLine("1. Базовый класс PaymentGateway:");
            PaymentGateway baseGateway = new PaymentGateway("Base Provider");
            Console.WriteLine(baseGateway.Info());
            baseGateway.EnableSandbox(true);
            Console.WriteLine("Результат Process: " + baseGateway.Process(100.50m));
            Console.WriteLine();

            // 2. Тестируем CardGateway
            Console.WriteLine("2. Класс CardGateway:");
            CardGateway cardGateway = new CardGateway("Visa");
            cardGateway.SetMaskedPan("**** **** **** 1234");
            Console.WriteLine(cardGateway.Info());
            Console.WriteLine("Результат Process: " + cardGateway.Process(200.75m));
            Console.WriteLine();

            // 3. Тестируем WalletGateway
            Console.WriteLine("3. Класс WalletGateway:");
            WalletGateway walletGateway = new WalletGateway("YooMoney");
            walletGateway.Link("user123_wallet");
            walletGateway.EnableSandbox(false);
            Console.WriteLine(walletGateway.Info());
            Console.WriteLine("Результат Process: " + walletGateway.Process(150.25m));
            Console.WriteLine();

            // 4. Тестируем CryptoWallet
            Console.WriteLine("4. Класс CryptoWallet:");
            CryptoWallet cryptoWallet = new CryptoWallet("Binance");
            cryptoWallet.Link("crypto_user_456");
            cryptoWallet.SwitchNetwork("ETH");
            cryptoWallet.EnableSandbox(true);
            Console.WriteLine(cryptoWallet.Info());
            Console.WriteLine("Результат Process: " + cryptoWallet.Process(500.00m));
            Console.WriteLine();

            // 5. Демонстрация полиморфизма
            Console.WriteLine("5. Демонстрация полиморфизма (через массив):");

            PaymentGateway[] gateways = new PaymentGateway[4];
            gateways[0] = new PaymentGateway("Generic");
            gateways[1] = new CardGateway("MasterCard");
            gateways[2] = new WalletGateway("WebMoney");
            gateways[3] = new CryptoWallet("Coinbase");

            foreach (var gateway in gateways)
            {
                Console.WriteLine(gateway.Process(50.00m));
            }

            Console.WriteLine("\n=== Демонстрация завершена ===");
            Console.ReadKey();
        }
    }
}