namespace MoneyFlow.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SkillTreeHomeworkEntries : DbContext
    {
        public SkillTreeHomeworkEntries()
            : base("name=SkillTreeHomeworkEntries")
        {
        }

        public virtual DbSet<AccountBook> AccountBook { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
