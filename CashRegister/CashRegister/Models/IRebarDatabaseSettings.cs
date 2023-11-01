namespace CashRegister.Models
{
    public interface IRebarDatabaseSettings
    {

        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string ShakesCollectionName { get; set; }
        string OrdersCollectionName { get; set; }
        string AccuntsCollectionName { get; set; }
    }
}
