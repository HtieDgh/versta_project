namespace versta.Shared
{
    /// <summary>
    /// Представление конфига для подключения
    /// </summary>
    public record DatabaseConfig
    {
        [ConfigurationKeyName("db_host")]
        public string dbHost { get; set; }

        [ConfigurationKeyName("db_name")]
        public string dbName { get; set; }

        [ConfigurationKeyName("db_pass")]
        public string dbPass { get; set; }

        [ConfigurationKeyName("db_user")]
        public string dbUser { get; set; }

        [ConfigurationKeyName("db_port")]
        public string dbPort { get; set; }
    }
}
