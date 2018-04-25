using System.Threading.Tasks;
using DemoGAB2018Ecuador.Modelos;

namespace DemoGAB2018Ecuador.Servicios
{
    public interface IServicioBaseDatos
    {
        Task<Usuario> ObtenerUsuario(string key);
        Task<bool> RegistrarUsuario(Usuario dato);
        Task<bool> ActualizarUsuario(Usuario dato);
    }
}

