namespace AuroraHRMPWA.Server.Data
{
    public class DataContext : DbContext
    {
        protected DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
