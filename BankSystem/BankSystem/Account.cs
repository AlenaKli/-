using System;

namespace BankSystemSeparate
{
    // Класс Account - отвечает за банковский счет
    public class Account
    {
        // Свойства (атрибуты) счета
        public string AccountNumber { get; }      // Номер счета (только для чтения)
        public decimal Balance { get; set; }      // Баланс (можно менять)
        public string Currency { get; }           // Валюта счета (только для чтения)

        // Конструктор класса Account
        public Account(string accountNumber, decimal balance, string currency)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            Currency = currency;
        }

        // Метод для пополнения счета
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }

        // Метод для снятия денег
        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                return true;  // Успешно
            }
            return false;  // Не удалось
        }

        // Метод для получения информации о счете
        public override string ToString()
        {
            return $"Счет: {AccountNumber}, Баланс: {Balance} {Currency}";
        }
    }
}