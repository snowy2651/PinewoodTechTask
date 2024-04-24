using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PinewoodApi.Models;

namespace PinewoodApi.Data
{
    public class PinewoodApiContext : DbContext
    {
        public PinewoodApiContext (DbContextOptions<PinewoodApiContext> options)
            : base(options)
        {
        }

        public DbSet<PinewoodApi.Models.Customer> Customer { get; set; } = default!;
    }
}
