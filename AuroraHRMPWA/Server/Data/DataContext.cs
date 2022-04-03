namespace AuroraHRMPWA.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FamilyMember>().HasData(
                new FamilyMember
                {
                    Id = 1,
                    Name = "Habib",
                    Age = 59,
                    Gender = "Male",
                    Relation = Relation.Parent,
                    UserId = 31
                }
                );

        }

        public DbSet<User> Users { get; set; }
        public DbSet<EmploymentDetail> EmploymentDetails { get; set; }
        public DbSet<EmployeeExperience> EmployeeExperiences { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
    }
}
