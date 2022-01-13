using Microsoft.EntityFrameworkCore;
using BDC.Dominio;
using BDC.Infraestructura.Datos.Configs;


namespace BDC.Infraestructura.Datos.Contexts
{
    public class ApiContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aplicativo> aplicativos { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<ClienteAplicacion> clienteAplicacion { get; set; }
        public DbSet<ClienteProducto> clienteProducto { get; set; }
        public DbSet<Codigo> codigos { get; set; }
        public DbSet<Comentario> comentarios { get; set; }

        public DbSet<Negocio> negocios { get; set; }
        public DbSet<NegocioCliente> negocioCliente { get; set; }
        public DbSet<Producto> productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer(@"Data Source=DESKTOP-0153SS0\SQLEXPRESS; Initial Catalog = BDC; Integrated Security = true;");

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new AplicationConfig());
            builder.ApplyConfiguration(new BusinessClientConfig());
            builder.ApplyConfiguration(new BusinessConfig());
            builder.ApplyConfiguration(new ClientAplicationConfig());
            builder.ApplyConfiguration(new ClientConfig());
            builder.ApplyConfiguration(new ClientProductConfig());
            builder.ApplyConfiguration(new CodeConfig());
            builder.ApplyConfiguration(new ProductConfig());
            builder.ApplyConfiguration(new ComentConfig());
        }
    }
}
