
using FiapStore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapStore.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(u => u.Nome).HasColumnType("VARCHAR(100)");
            builder.Property(u => u.NomeUsuario).IsRequired().HasColumnType("VARCHAR(50)");
            builder.Property(u => u.Senha).IsRequired().HasColumnType("VARCHAR(50)");
            builder.Property(u => u.Permissao).HasConversion<int>().IsRequired();

            builder.HasMany(u => u.Pedidos)//TEMOS VARIOAS PEDIDOS
                .WithOne(p => p.Usuario)//COM UM USUARIO SÓ
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
