namespace Demo.Interfaces
{
    public interface IOrderManager
    {
        bool MakeOrder(string userId, int[] selectedProducts);
    }
}