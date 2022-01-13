
using BDC.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BDC.Infraestructura.Datos.Configs
{
    public class UserConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tb1Usuarios");
            builder.HasKey(c => c.id_usuario);
            builder.HasKey(c => c.id_usuario);
            builder.Property(e => e.usuario).IsRequired();
            builder.Property(e => e.contraseña).IsRequired();




        }
    }
}
