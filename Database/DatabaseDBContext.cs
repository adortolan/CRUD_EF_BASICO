using Microsoft.EntityFrameworkCore;
using CRUD_EFCS.Models;

namespace CRUD_EFCS.Database
{
    public class PessoaDBContext: DbContext
    {
        public DbSet<Pessoa> Pessoas{get; set;}
        public PessoaDBContext(DbContextOptions<PessoaDBContext> options):base(options){}                
        protected override void OnModelCreating(ModelBuilder builder) 
        { 
               builder.Entity<Pessoa>().HasKey(m => m.Id);                
               base.OnModelCreating(builder); 
        }               
    }    
}
