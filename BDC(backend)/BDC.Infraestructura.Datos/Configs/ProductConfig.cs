
using BDC.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace BDC.Infraestructura.Datos.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            //nombre de la tabla
            builder.ToTable("tb1Productos");
            //llave principal
            builder.HasKey(c => c.id_producto);
                     
              
        }



    }
}
