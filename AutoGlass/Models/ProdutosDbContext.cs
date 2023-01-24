using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AutoGlass.Models
{
    public class ProdutosDbContext : DbContext
    {
        public DbSet<Produtos> Produtos { get; set; }    
    }
}