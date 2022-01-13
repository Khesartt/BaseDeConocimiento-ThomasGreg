
using BDC.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BDC.Infraestructura.Datos.Configs
{
    public class CodeConfig : IEntityTypeConfiguration<Codigo>
    {
        public void Configure(EntityTypeBuilder<Codigo> builder)
        {
            //nombre de la tabla
            builder.ToTable("tb1Codigos");
            //llave principal
            builder.HasKey(c => c.id_codigo);
            //relacion con la tabla producto
            builder
            .HasOne<Producto>()
            .WithMany()
            .HasForeignKey(p => p.id_producto);

            //relacion con la tabla aplicativo
            builder
            .HasOne<Aplicativo>()
            .WithMany()
            .HasForeignKey(p => p.id_aplicativo);


        }
    }
}
