using FiapStore.Entity;
using FiapStore.Interface;
using Microsoft.EntityFrameworkCore;

namespace FiapStore.Repository
{
    public class EFUsuarioRepository : EFRepository<Usuario>, IUsuarioRepository
    {
        public EFUsuarioRepository(ApplicationDbContext context) : base (context)
        {
                
        }
        public Usuario ObterComPedidos(int Id)
        {
            return _context.Usuario
                .Include(u => u.Pedidos)
                .Where(u => u.Id.Equals(Id))
                .ToList()
                .Select(user => 
                {
                    user.Pedidos = user.Pedidos.Select(pedido => new Pedido(pedido)).ToList();
                    return user;
                }).FirstOrDefault();
        }

        public Usuario ObterPorNomeUsuarioESenha(string nomeUsuario, string senha)
        {
            return _context.Usuario.FirstOrDefault(usuario => usuario.NomeUsuario.Equals(nomeUsuario) && usuario.Senha.Equals(senha));
        }
    }
}
