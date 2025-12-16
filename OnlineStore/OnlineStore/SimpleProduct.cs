namespace OnlineStore
{
    // Класс SimpleProduct (простой товар)
    public class SimpleProduct : IProduct
    {
        // Приватные поля
        private string _name;
        private int _price;

        // Реализация свойств из интерфейса IProduct
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                    value = 0; // Цена не может быть отрицательной
                _price = value;
            }
        }

        // Конструктор
        public SimpleProduct(string name, int price)
        {
            Name = name;
            Price = price;
        }

        // Реализация метода ApplyDiscount из интерфейса IProduct
        public void ApplyDiscount(int percent)
        {
            // Рассчитываем скидку
            int discount = Price * percent / 100;
            int newPrice = Price - discount;

            // Не даем цене уйти ниже 0
            if (newPrice < 0)
                newPrice = 0;

            Price = newPrice;
        }

        // Метод для вывода информации
        public string GetInfo()
        {
            return $"Товар: {Name}, Цена: {Price} руб.";
        }
    }
}