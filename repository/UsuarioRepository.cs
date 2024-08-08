using ProyectoFasr.Data;
using ProyectoFasr.model;

namespace ProyectoFasr.repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public Usuario ObtenerUsuarioPorId(string id)
    {
        return _context.Usuarios
            .FirstOrDefault(u => u.Id == id);
    }

    public IEnumerable<Usuario> ObtenerTodosLosUsuarios()
    {
        return _context.Usuarios.ToList();
    }

    public void AgregarUsuario(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public void ActualizarUsuario(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        _context.SaveChanges();
    }

    public void EliminarUsuario(string id)
    {
        var usuario = ObtenerUsuarioPorId(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }
    }
}
