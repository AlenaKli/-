namespace OrderProcessing
{
    // Класс пайплайна обработки заказа
    public class OrderPipeline
    {
        // Свойство-делегат для хранения обработчиков
        public OrderStep Pipeline { get; set; }

        // Метод для запуска пайплайна
        public void Run(OrderContext context)
        {
            // Проверяем, есть ли обработчики
            if (Pipeline != null)
            {
                // Вызываем все обработчики
                Pipeline(context);
            }
        }
    }
}