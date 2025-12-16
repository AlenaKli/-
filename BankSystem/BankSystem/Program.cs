using System;

namespace BankSystemSeparate
{
    // Главный класс программы
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Банковская система (классы в отдельных файлах) ===");
            Console.WriteLine();

            // 1. СОЗДАЕМ БАНК
            Console.WriteLine("1. СОЗДАЕМ БАНК");
            Bank sberbank = new Bank("Сбербанк");
            Console.WriteLine(sberbank);
            Console.WriteLine();

            // 2. СОЗДАЕМ КЛИЕНТОВ
            Console.WriteLine("2. СОЗДАЕМ КЛИЕНТОВ");
            Client client1 = new Client("4500 123456", 7);
            Client client2 = new Client("4500 654321", 9);

            Console.WriteLine("   Клиент 1: " + client1);
            Console.WriteLine("   Клиент 2: " + client2);
            Console.WriteLine();

            // 3. ДОБАВЛЯЕМ КЛИЕНТОВ В БАНК
            Console.WriteLine("3. ДОБАВЛЯЕМ КЛИЕНТОВ В БАНК");
            sberbank.AddClient(client1);
            sberbank.AddClient(client2);
            Console.WriteLine(sberbank);
            Console.WriteLine();

            // 4. СОЗДАЕМ СЧЕТА
            Console.WriteLine("4. СОЗДАЕМ СЧЕТА");
            Account account1 = new Account("40817810123450000001", 50000, "RUB");
            Account account2 = new Account("40817810123450000002", 100000, "RUB");
            Account account3 = new Account("40817810123450000003", 150000, "RUB");

            Console.WriteLine("   " + account1);
            Console.WriteLine("   " + account2);
            Console.WriteLine("   " + account3);
            Console.WriteLine();

            // 5. ПРИВЯЗЫВАЕМ СЧЕТА К КЛИЕНТАМ
            Console.WriteLine("5. ПРИВЯЗЫВАЕМ СЧЕТА К КЛИЕНТАМ");
            client1.AddAccount(account1);
            client1.AddAccount(account2);
            client2.AddAccount(account3);

            Console.WriteLine("   У клиента 1 теперь счетов: " + client1.Accounts.Count);
            Console.WriteLine("   У клиента 2 теперь счетов: " + client2.Accounts.Count);
            Console.WriteLine();

            // 6. ПРОВОДИМ ОПЕРАЦИИ СО СЧЕТАМИ
            Console.WriteLine("6. ПРОВОДИМ ОПЕРАЦИИ СО СЧЕТАМИ");

            // Пополнение счета
            account1.Deposit(20000);
            Console.WriteLine("   Пополнили счет 1 на 20000: " + account1);

            // Снятие со счета (успешное)
            bool success = account2.Withdraw(30000);
            Console.WriteLine("   Сняли со счета 2 30000: " + (success ? "Успешно" : "Не удалось"));
            Console.WriteLine("   " + account2);

            // Снятие со счета (неудачное - недостаточно средств)
            success = account3.Withdraw(200000);
            Console.WriteLine("   Пытаемся снять со счета 3 200000: " + (success ? "Успешно" : "Не удалось"));
            Console.WriteLine("   " + account3);
            Console.WriteLine();

            // 7. ВЫВОДИМ ИТОГОВУЮ ИНФОРМАЦИЮ
            Console.WriteLine("7. ИТОГОВАЯ ИНФОРМАЦИЯ");

            Console.WriteLine("   " + sberbank);
            Console.WriteLine();

            Console.WriteLine("   Информация о клиентах:");
            foreach (var client in sberbank.Clients)
            {
                Console.WriteLine("   " + client);

                // Выводим счета каждого клиента
                foreach (var account in client.Accounts)
                {
                    Console.WriteLine("     " + account);
                }
                Console.WriteLine();
            }

            Console.WriteLine("=== Демонстрация завершена ===");
            Console.ReadKey();
        }
    }
}