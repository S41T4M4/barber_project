using BarberAPI.Model;
using BarberAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BarberAPI.Controllers
{
    [ApiController]
    [Route("api/v1/barber")]
    public class UserController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UserController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }
        [HttpPost("user")]
        public IActionResult AddUser(UsuarioViewModel userView)
        {
            var user = new Usuarios
            {
                
            };
            _usuariosRepository.AddUsuarios(user);
            return Ok();
        }
        [HttpGet("allUser")]
        public IActionResult GetAllUsers()
        {
            var users = _usuariosRepository.GetUsuarios();
            return Ok(users);
        }
        [HttpPut("editUser/{id}")]
        public IActionResult UpdateUser(int id ,[FromBody] UsuarioViewModel userView)
        {
            var existingUsuario = _usuariosRepository.GetUsuariosById(id);

            if (existingUsuario == null)
            {
                return NotFound();
            }


            
            existingUsuario.nome = userView.Nome;
            existingUsuario.telefone = userView.Telefone;
            existingUsuario.email = userView.Email;
            existingUsuario.senha = userView.Senha;
            existingUsuario.tipo_usuario = userView.TipoUsuario;
           
            _usuariosRepository.UpdateUsuarios(existingUsuario);
            return Ok();
        }
        [HttpGet("getUserById")]
        public IActionResult GetUserById(int id)
        {
            var user = _usuariosRepository.GetUsuariosById(id);
            return Ok(user);
        }
        [HttpDelete("deleteUser")]
        public IActionResult DeleteUserById(int id)
        {
            var user = _usuariosRepository.GetUsuariosById(id);
            if (user != null)
            {
                _usuariosRepository.DeleteUsuarios(id);
                return Ok();
            }
            else
            {
                return BadRequest("O Usuario não existe");
            }
        }
    }
}
