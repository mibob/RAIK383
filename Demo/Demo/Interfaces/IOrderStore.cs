namespace Demo.Interfaces
{
    public interface IOrderStore
    {
        bool Create(string userId, int[] productsIds);
    }
}