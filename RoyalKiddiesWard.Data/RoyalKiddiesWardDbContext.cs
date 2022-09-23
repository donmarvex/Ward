
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoyalKiddiesWard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RoyalKiddiesWard.Data
{

    public  class RoyalKiddiesWardDbContext : IdentityDbContext< User,Role, int>
    {
        public RoyalKiddiesWardDbContext(DbContextOptions<RoyalKiddiesWardDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

    }
}
 
