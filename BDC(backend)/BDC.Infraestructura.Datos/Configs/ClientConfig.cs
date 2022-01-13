
using BDC.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BDC.Infraestructura.Datos.Configs
{
    public class ClientConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //nombre de la tabla
            builder.ToTable("tb1Clientes");
            //llave principal
            builder.HasKey(c => c.id_cliente);
            
        }
    }
}
