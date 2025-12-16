namespace OnlineStore
{
    // Интерфейс IProduct (Товар)
    public interface IProduct
    {
        // Свойства
        string Name { get; set; }
        int Price { get; set; }

        // Метод для применения скидки
        void ApplyDiscount(int percent);
    }
}