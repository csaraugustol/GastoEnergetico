using GastoEnergetico.Models.Categorias;
using GastoEnergetico.Models.Itens;
using GastoEnergetico.Models.Parametros;
using Microsoft.EntityFrameworkCore;

namespace GastoEnergetico.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<ParametrosEntity> Parametros { get; set; }
        public DbSet<CategoriasEntity> Categorias { get; set; }
        public DbSet<ItensEntity> Itens { get; set; }
        
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }
    }
}