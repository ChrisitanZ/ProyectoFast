using ProyectoFasr.model;

namespace ProyectoFasr.repository;

public interface IUsuarioRepository
{
   
    Usuario ObtenerUsuarioPorId(int id);

    
    IEnumerable<Usuario> ObtenerTodosLosUsuarios();
    
    void AgregarUsuario(Usuario usuario);
    
    void ActualizarUsuario(Usuario usuario);
    
    void EliminarUsuario(int id);
}
