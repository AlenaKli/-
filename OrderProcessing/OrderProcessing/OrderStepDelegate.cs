namespace OrderProcessing
{
    // Делегат для обработки шага заказа
    // Принимает OrderContext в качестве параметра
    public delegate void OrderStep(OrderContext context);
}