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
                },
                new FamilyMember
                {
                    Id = 2,
                    Name = "Kareeem",
                    Age = 12,
                    Gender = "Male",
                    Relation = Relation.Child,
                    UserId = 29
                },
                new FamilyMember
                {
                    Id = 3,
                    Name = "Kareeem",
                    Age = 10,
                    Gender = "Female",
                    Relation = Relation.Child,
                    UserId = 31
                },
                new FamilyMember
                {
                    Id = 4,
                    Name = "jacky",
                    Age = 5,
                    Gender = "Male",
                    Relation = Relation.Child,
                    UserId = 29
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
