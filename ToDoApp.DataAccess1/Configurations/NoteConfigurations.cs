using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Entities1.Domains;

namespace ToDoApp.DataAccess1.Configurations
{
    
        public class NoteConfigurations : IEntityTypeConfiguration<Note>
        {
            public void Configure(EntityTypeBuilder<Note> builder)
            {

                builder.Property(x => x.Defination).HasMaxLength(300);
                builder.Property(x => x.Defination).IsRequired(true);
                builder.Property(x => x.IsCompleted).IsRequired(true);

            }
        }


    }

