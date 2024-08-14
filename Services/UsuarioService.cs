using ProyectoFasr.model;
using ProyectoFasr.repository;

namespace ProyectoFasr.Services;

public class UsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public Usuario ObtenerUsuarioPorId(int id)
    {
        var usuario = _usuarioRepository.ObtenerUsuarioPorId(id);
        if (usuario == null)
        {
            throw new Exception("Usuario no encontrado.");
        }
        return usuario;
    }

    public IEnumerable<Usuario> ObtenerTodosLosUsuarios()
    {
        return _usuarioRepository.ObtenerTodosLosUsuarios();
    }

    public void RegistrarUsuario(Usuario usuario)
    {
        var usuarioExistente = _usuarioRepository.ObtenerTodosLosUsuarios()
            .Any(u => u.Email == usuario.Email);

        if (usuarioExistente)
        {
            throw new Exception("El correo electrónico ya está registrado.");
        }
        
        _usuarioRepository.AgregarUsuario(usuario);
    }

    public void ActualizarUsuario(int id, Usuario usuarioActualizado)
    {
        var usuario = _usuarioRepository.ObtenerUsuarioPorId(id);

        if (usuario == null)
        {
            throw new Exception("Usuario no encontrado.");
        }

        usuario.Nombres = usuarioActualizado.Nombres;
        usuario.Email = usuarioActualizado.Email;
        // Otras actualizaciones necesarias...

        _usuarioRepository.ActualizarUsuario(usuario);
    }

    public void EliminarUsuario(int id)
    {
        var usuario = _usuarioRepository.ObtenerUsuarioPorId(id);
        if (usuario == null)
        {
            throw new Exception("Usuario no encontrado.");
        }
        _usuarioRepository.EliminarUsuario(id);
    }
    
   
}
