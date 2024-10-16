using BarberAPI.Model;
using BarberAPI.Infraestrutura;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;


namespace BarberAPI.Infraestrutura.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
  
    {
        private readonly ConnectionContext _connectionContext;

        public UsuariosRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void AddUsuarios(Usuarios usuarios)
        {
            _connectionContext.Usuarios.Add(usuarios);
            _connectionContext.SaveChanges();
        }

        public void DeleteUsuarios(int id)
        {
            var user = _connectionContext.Usuarios.Find(id);
            if (user != null)
            {
                _connectionContext.Usuarios.Remove(user);
                _connectionContext.SaveChanges();
            }
            
        }

        public List<Usuarios> GetUsuarios()
        {
            return _connectionContext.Usuarios.ToList();
        }

        public Usuarios GetUsuariosById(int id)
        {
            return _connectionContext.Usuarios.Find(id);         
        }

        public void UpdateUsuarios(Usuarios usuarios)
        {
            var user = _connectionContext.Usuarios.Find(usuarios.id);
            if(user != null)
            {
               
                user.nome = usuarios.nome;
                user.email = usuarios.email;
                user.telefone = usuarios.telefone;
                user.senha = usuarios.senha;
                user.tipo_usuario = usuarios.tipo_usuario;

                _connectionContext.Usuarios.Update(user);
                _connectionContext.SaveChanges();
            }
        }
    }
}
