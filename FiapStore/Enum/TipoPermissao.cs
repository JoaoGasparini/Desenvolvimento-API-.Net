using System.ComponentModel;

namespace FiapStore.Enum
{
    public enum TipoPermissao
    {
        [Description("Administrador")]
        Administrador,
        Funcionario
    }
    public static class Permissoes
    {
        public const string Administrador = "Administrados";
        public const string Funcionario = "Funcionario";
    }
}