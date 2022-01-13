
using BDC.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BDC.Infraestructura.Datos.Configs
{
    public class BusinessClientConfig : IEntityTypeConfiguration<NegocioCliente>
    {
        public void Configure(EntityTypeBuilder<NegocioCliente> builder)
        {
            //nombre de la tabla
            builder.ToTable("tb1NegocioCliente");
            //llave principal compuesta
            builder.HasKey(nc => new { nc.id_negocio, nc.id_cliente });

        }
    }
}
