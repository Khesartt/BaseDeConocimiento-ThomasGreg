
using BDC.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BDC.Infraestructura.Datos.Configs
{
    public class ComentConfig : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            //nombre de la tabla
            builder.ToTable("tb1Comentarios");
            //llave principal
            builder.HasKey(c => c.id_comentario);
            //relacion con la tabla Usuario
            builder
            .HasOne<Usuario>()
            .WithMany()
            .HasForeignKey(p => p.id_usuario);

           


        }
    }
}
