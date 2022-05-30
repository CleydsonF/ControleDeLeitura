using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestePV.Models;

namespace TestePV.Data
{
    public class TestePVContext : DbContext
    {
        public TestePVContext (DbContextOptions<TestePVContext> options)
            : base(options)
        {
        }

        public DbSet<TestePV.Models.Leitor> Leitor { get; set; }

        public DbSet<TestePV.Models.Livro> Livro { get; set; }

        public DbSet<TestePV.Models.Leitura> Leitura { get; set; }
    }
}
