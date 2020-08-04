namespace Integration.DAL
{
    public class RepositoryOption
    {
        public string SqlServerDbConnectionString { get; set; }
        public string HanaDbConnectionString { get; set; }
        public string MySQLDbConnectionString { get; set; }
        public string SqlQueryStoreProcedure { get; set; }
        public string SqlQueryText { get; set; }
    }
}
