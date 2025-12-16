namespace OnlineStore
{
    // Интерфейс IStockItem (Товар на складе)
    public interface IStockItem
    {
        // Свойство - количество на складе
        int Stock { get; set; }

        // Метод для резервирования товара
        bool Reserve(int qty);
    }
}