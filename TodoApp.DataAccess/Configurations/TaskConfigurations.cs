using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TodoApp.DataAccess.Configurations
{
    public class TaskConfigurations : IEntityTypeConfiguration<Task>
    {

        public void Configure(EntityTypeBuilder<Task> builder)
        {

            builder.Property(x => x.Defination).HasMaxLength(300);
            builder.Property(x => x.Defination).IsRequired(true);
            builder.Property(x => x.IsCompleted).IsRequired(true);

        }
    }
}
