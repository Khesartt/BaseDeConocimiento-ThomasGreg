
using BDC.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BDC.Infraestructura.Datos.Configs
{
    public class BusinessConfig : IEntityTypeConfiguration<Negocio>
    {
        public void Configure(EntityTypeBuilder<Negocio> builder)
        {
            //nombre de la tabla
            builder.ToTable("tb1Negocio_Lineas");
            //llave principal
            builder.HasKey(c => c.id_negocio);
            
        }
    }
}
