namespace Assets.API.Infrastructures
{
    public class DatabaseSetting
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string AssetsCollectionName { get; set; } = null!;
    }
}
