using ProyectoFasr.model;

namespace ProyectoFasr.repository;

public interface IUsuarioRepository
{
   
    Usuario ObtenerUsuarioPorId(string id);

    
    IEnumerable<Usuario> ObtenerTodosLosUsuarios();
    
    void AgregarUsuario(Usuario usuario);
    
    void ActualizarUsuario(Usuario usuario);
    
    void EliminarUsuario(string id);
}
