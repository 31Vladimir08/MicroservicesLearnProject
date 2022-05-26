namespace ECommerce.Api.Products.Models
{
    public class DbSettings
    {
        public const string DbSettingsKey = "DbSettings";

        public string ConnectionString { get; init; }
        public int MaxCountElements { get; init; }
    }
}
