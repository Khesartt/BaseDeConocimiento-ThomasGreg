
using BDC.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BDC.Infraestructura.Datos.Configs
{
    public class ClientProductConfig : IEntityTypeConfiguration<ClienteProducto>
    {
        public void Configure(EntityTypeBuilder<ClienteProducto> builder)
        {
            //nombre de la tabla
            builder.ToTable("tb1ClienteProducto");
            //llave principal
            builder.HasKey(ca => new { ca.id_producto, ca.id_cliente });
                        
        }
    }
}
