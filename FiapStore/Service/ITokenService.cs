using FiapStore.Entity;

namespace FiapStore.Service
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}
