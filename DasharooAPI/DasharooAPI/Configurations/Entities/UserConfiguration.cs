using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DasharooAPI.Configurations.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

        }
    }
}
