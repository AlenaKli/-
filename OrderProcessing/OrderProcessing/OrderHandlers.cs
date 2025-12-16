namespace OrderProcessing
{
    // Класс с обработчиками заказа
    public static class OrderHandlers
    {
        // Метод проверки наличия товара на складе
        public static void CheckStock(OrderContext context)
        {
            context.HasStock = true;
        }

        // Метод расчета стоимости доставки
        public static void CalculateDelivery(OrderContext context)
        {
            context.DeliveryCost = 200;
        }
    }
}