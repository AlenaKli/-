namespace OnlineStore
{
    // Класс WarehouseItem (товар на складе)
    public class WarehouseItem : IProduct, IStockItem
    {
        // Приватные поля
        private string _name;
        private int _price;
        private int _stock;

        // Новое поле для минимальной цены
        private int _minPrice;

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
                    value = 0;
                _price = value;
            }
        }

        // Реализация свойства из интерфейса IStockItem
        public int Stock
        {
            get { return _stock; }
            set
            {
                if (value < 0)
                    value = 0;
                _stock = value;
            }
        }

        // Свойство для минимальной цены
        public int MinPrice
        {
            get { return _minPrice; }
            set
            {
                if (value < 0)
                    value = 0;
                _minPrice = value;
            }
        }

        // Конструктор
        public WarehouseItem(string name, int price, int stock, int minPrice)
        {
            Name = name;
            Price = price;
            Stock = stock;
            MinPrice = minPrice;
        }

        // Реализация метода ApplyDiscount из интерфейса IProduct с переопределением
        public void ApplyDiscount(int percent)
        {
            // Рассчитываем скидку как в простом товаре
            int discount = Price * percent / 100;
            int newPrice = Price - discount;

            // Проверяем, чтобы цена не упала ниже минимальной
            if (newPrice < MinPrice)
                newPrice = MinPrice;

            Price = newPrice;
        }

        // Реализация метода Reserve из интерфейса IStockItem
        public bool Reserve(int qty)
        {
            if (qty <= Stock)
            {
                Stock -= qty;
                return true; // Товар зарезервирован
            }
            else
            {
                return false; // Недостаточно товара
            }
        }

        // Метод для вывода информации
        public string GetInfo()
        {
            return $"Товар: {Name}, Цена: {Price} руб., На складе: {Stock} шт., Мин. цена: {MinPrice} руб.";
        }
    }
}