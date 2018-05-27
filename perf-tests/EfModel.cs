namespace MvcPerfTest
{
    using System.Data.Entity;

    public class EfModel : DbContext
    {
        public EfModel() : base("name=EfModel") { }

        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Page1Model> Page1Models { get; set; }
        public virtual DbSet<Page2Model> Page2Models { get; set; }
        public virtual DbSet<Page3Model> Page3Models { get; set; }
        public virtual DbSet<Page4Model> Page4Models { get; set; }
        public virtual DbSet<Page5Model> Page5Models { get; set; }
    }
}
