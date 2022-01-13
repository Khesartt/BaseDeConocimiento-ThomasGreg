
using BDC.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BDC.Infraestructura.Datos.Configs
{
    public class AplicationConfig : IEntityTypeConfiguration<Aplicativo>
    {
        public void Configure(EntityTypeBuilder<Aplicativo> builder)
        {
            //nombre de la tabla
            builder.ToTable("tb1Aplicativos");
            //llave principal
            builder.HasKey(a => a.id_aplicativo);
           
            
        }
    }
}
