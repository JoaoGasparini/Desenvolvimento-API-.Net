using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FiapStore.Entity;

namespace FiapStore.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(u => u.NomeProduto).HasColumnType("VARCHAR(100)");
            builder.Property(u => u.PrecoTotal).HasColumnType("decimal");
            builder.HasOne(u => u.Usuario)//TEMOS UM USUARIO
                     .WithMany(p => p.Pedidos)//COM VARIOS PEDIDOS
                     .HasPrincipalKey(u => u.Id);
        }
    }
}
