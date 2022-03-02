using Microsoft.EntityFrameworkCore;
using ProEventos.APi.Models;

namespace ProEventos.APi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Evento> Eventos { get; set; }
    }
}