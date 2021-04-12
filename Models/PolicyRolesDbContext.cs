using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models
{
    public class PolicyRolesDbContext : DbContext
    {
        public PolicyRolesDbContext(DbContextOptions<PolicyRolesDbContext> options) : base(options)
        {

        }
        public DbSet<WriteRole> WriteRoles { get; set; }

        public DbSet<DeleteRole> DeleteRoles { get; set; }
    }
}
