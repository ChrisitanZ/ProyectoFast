using ProyectoFasr.Data;
using ProyectoFasr.model;

namespace ProyectoFasr.repository;

public class TransaccionRepository : ITransaccionRepository
{
    private readonly AppDbContext _context;

    public TransaccionRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Transaccion> ObtenerTransaccionesPorUsuario(int usuarioId)
    {
        return _context.Transacciones
            .Where(t => t.UsuarioId == usuarioId)
            .ToList();
    }

    public Transaccion ObtenerTransaccionPorId(int id)
    {
        return _context.Transacciones
            .FirstOrDefault(t => t.Id == id);
    }

    public void AgregarTransaccion(Transaccion transaccion)
    {
        _context.Transacciones.Add(transaccion);
        _context.SaveChanges();
    }

    public void ActualizarTransaccion(Transaccion transaccion)
    {
        _context.Transacciones.Update(transaccion);
        _context.SaveChanges();
    }

    public void EliminarTransaccion(int id)
    {
        var transaccion = ObtenerTransaccionPorId(id);
        if (transaccion != null)
        {
            _context.Transacciones.Remove(transaccion);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Transaccion> ObtenerTransacciones()
    {
        return _context.Transacciones.ToList();
    }
}
