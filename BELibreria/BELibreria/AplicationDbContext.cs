using BELibreria.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BELibreria
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<Libro> Libreria { get; set; }
        public DbSet<Autor> LibreriaAutor { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }
    }
}
