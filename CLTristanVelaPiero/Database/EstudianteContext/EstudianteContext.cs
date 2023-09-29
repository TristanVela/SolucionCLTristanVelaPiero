using Microsoft.EntityFrameworkCore;

namespace CLTristanVelaPiero.Database.EstudianteContext
{
    public class EstudianteContext : DbContext
    {
        public DbSet<EstudianteEntity> Estudiantes { get; set; }
        public EstudianteContext(DbContextOptions<EstudianteContext> option) : base(option) {
        
        }

    }
}


