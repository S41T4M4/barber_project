namespace BarberAPI.ViewModel
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string TipoUsuario { get; set; } = string.Empty; // Cliente ou Funcionario
        public string Senha { get; set; } = string.Empty; // Para o registro e autenticação
    }
}
