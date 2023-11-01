namespace CashRegister.Models
{
    public class RebarDatabaseSettings : IRebarDatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;

        public string ShakesCollectionName { get; set; } = string.Empty;

        public string OrdersCollectionName { get; set; } = string.Empty;

        public string AccuntsCollectionName { get; set; } = string.Empty;
    }
}
