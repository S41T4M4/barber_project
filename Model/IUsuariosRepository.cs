using Microsoft.AspNetCore.SignalR;

namespace BarberAPI.Model
{
    public interface IUsuariosRepository
    {
        void AddUsuarios(Usuarios usuarios);
        void UpdateUsuarios(Usuarios usuarios);
        List<Usuarios> GetUsuarios();
        void DeleteUsuarios(int id);
        Usuarios GetUsuariosById(int id);
    }
}
