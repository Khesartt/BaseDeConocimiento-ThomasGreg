
using BDC.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BDC.Infraestructura.Datos.Configs
{
    public class ClientAplicationConfig : IEntityTypeConfiguration<ClienteAplicacion>
    {
        public void Configure(EntityTypeBuilder<ClienteAplicacion> builder)
        {
            //nombre de la tabla
            builder.ToTable("tb1ClienteAplicacion");
            //llave principal
            builder.HasKey(ca => new { ca.id_aplicativo, ca.id_cliente });
                        
        }
    }
}
