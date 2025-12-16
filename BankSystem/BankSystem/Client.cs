using System.Collections.Generic;

namespace BankSystemSeparate
{
    // Класс Client - отвечает за клиента банка
    public class Client
    {
        // Свойства (атрибуты) клиента
        public string PassportData { get; }          // Паспортные данные
        public int CreditRating { get; set; }        // Кредитный рейтинг (1-10)
        public List<Account> Accounts { get; }       // Список счетов клиента

        // Конструктор класса Client
        public Client(string passportData, int creditRating)
        {
            PassportData = passportData;

            // Проверка кредитного рейтинга
            if (creditRating < 1) creditRating = 1;
            if (creditRating > 10) creditRating = 10;
            CreditRating = creditRating;

            // Инициализируем пустой список счетов
            Accounts = new List<Account>();
        }

        // Метод для добавления счета клиенту
        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        // Метод для расчета общего баланса клиента
        public decimal GetTotalBalance()
        {
            decimal total = 0;
            foreach (var account in Accounts)
            {
                total += account.Balance;
            }
            return total;
        }

        // Метод для получения информации о клиенте
        public override string ToString()
        {
            return $"Клиент: {PassportData}, Рейтинг: {CreditRating}, Счетов: {Accounts.Count}, Общий баланс: {GetTotalBalance()}";
        }
    }
}