namespace SystemTestingProject
{
    using System.Data.Entity;
    public class Connect : DbContext
    {
        public Connect()
            : base("name=TestSystem")
        {
           
        }
     public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ResultExam> Exam { get; set; }
    }

   
}