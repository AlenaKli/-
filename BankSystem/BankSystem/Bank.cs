using System.Collections.Generic;

namespace BankSystemSeparate
{
    // Класс Bank - отвечает за банк
    public class Bank
    {
        // Свойства (атрибуты) банка
        public string Name { get; }                 // Название банка
        public decimal TotalProfit { get; set; }    // Общая прибыль банка
        public List<Client> Clients { get; }        // Список клиентов банка

        // Конструктор класса Bank
        public Bank(string name)
        {
            Name = name;
            TotalProfit = 0;
            Clients = new List<Client>();
        }

        // Метод для добавления клиента в банк
        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        // Метод для расчета общей суммы всех вкладов
        public decimal GetTotalDeposits()
        {
            decimal total = 0;
            foreach (var client in Clients)
            {
                total += client.GetTotalBalance();
            }
            return total;
        }

        // Метод для получения информации о банке
        public override string ToString()
        {
            return $"Банк: {Name}, Клиентов: {Clients.Count}, Общие вклады: {GetTotalDeposits()}, Прибыль: {TotalProfit}";
        }
    }
}