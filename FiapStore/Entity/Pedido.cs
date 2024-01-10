using System.ComponentModel.DataAnnotations.Schema;

namespace FiapStore.Entity
{
    public class Pedido : Entidade
    {
        public string NomeProduto { get; set; }
        public int UsuarioId { get; set; }
        public decimal PrecoTotal { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public Usuario Usuario { get; set; }


        public Pedido()
        {

        }
        public Pedido(Pedido pedido)
        {
            NomeProduto = pedido.NomeProduto;
            UsuarioId = pedido.UsuarioId;
        }
    }
}
