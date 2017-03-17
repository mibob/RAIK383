namespace Demo.Interfaces
{
    public interface IOrderManager
    {
        bool CreateOrder(string userId, int[] productIds);
    }
}