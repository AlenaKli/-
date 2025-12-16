namespace OrderProcessing
{
    // Класс для хранения информации о заказе
    public class OrderContext
    {
        // Свойства заказа
        public bool HasStock { get; set; }       // Есть ли товар на складе
        public int DeliveryCost { get; set; }    // Стоимость доставки
        public bool IsConfirmed { get; set; }    // Подтвержден ли заказ
    }
}