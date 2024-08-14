using ProyectoFasr.model;
using ProyectoFasr.repository;

namespace ProyectoFasr.Services;

public class TransaccionService
{
    private readonly ITransaccionRepository _transaccionRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ILogger<TransaccionService> _logger;

    public TransaccionService(ITransaccionRepository transaccionRepository, IUsuarioRepository usuarioRepository, ILogger<TransaccionService> logger)
    {
        _transaccionRepository = transaccionRepository;
        _usuarioRepository = usuarioRepository;
        _logger = logger;
    }

    public IEnumerable<Transaccion> ObtenerTransaccionesPorUsuario(int usuarioId)
    {
        var usuario = _usuarioRepository.ObtenerUsuarioPorId(usuarioId);
        if (usuario == null)
        {
            throw new Exception("Usuario no encontrado.");
        }

        return _transaccionRepository.ObtenerTransaccionesPorUsuario(usuarioId);
    }

    public Transaccion ObtenerTransaccionPorId(int id)
    {
        var transaccion = _transaccionRepository.ObtenerTransaccionPorId(id);
        if (transaccion == null)
        {
            throw new Exception("Transacción no encontrada.");
        }
        return transaccion;
    }

    public void RegistrarTransaccion(int usuarioId, Transaccion transaccion)
    {
        var usuario = _usuarioRepository.ObtenerUsuarioPorId(usuarioId);
        if (usuario == null)
        {
            throw new Exception("Usuario no encontrado.");
        }

        transaccion.UsuarioId = usuarioId;
        _transaccionRepository.AgregarTransaccion(transaccion);
    }

    public void ActualizarTransaccion(int id, Transaccion transaccionActualizada)
    {
        var transaccion = _transaccionRepository.ObtenerTransaccionPorId(id);
        if (transaccion == null)
        {
            throw new Exception("Transacción no encontrada.");
        }

        transaccion.Monto = transaccionActualizada.Monto;
        transaccion.Descripcion = transaccionActualizada.Descripcion;
        transaccion.Fecha = transaccionActualizada.Fecha;

        _transaccionRepository.ActualizarTransaccion(transaccion);
    }

    public void EliminarTransaccion(int id)
    {
        var transaccion = _transaccionRepository.ObtenerTransaccionPorId(id);
        if (transaccion == null)
        {
            throw new Exception("Transacción no encontrada.");
        }
        _transaccionRepository.EliminarTransaccion(id);
    }
    
    
    public IEnumerable<Transaccion> ObtenerTransaccionesPorCategoria(string categoria)
    {
        return _transaccionRepository.ObtenerTransacciones()
            .Where(t => t.Categoria == categoria);
    }
    
    public decimal ObtenerTotalGastosPorPeriodo(int usuarioId, DateTime fechaInicio, DateTime fechaFin)
    {
        return _transaccionRepository.ObtenerTransaccionesPorUsuario(usuarioId)
            .Where(t => t.Fecha >= fechaInicio && t.Fecha <= fechaFin)
            .Sum(t => t.Monto);
    }
    
    public void NotificarSiGastoExcedeLimite(int usuarioId, decimal limite)
    {
        var gastosMensuales = ObtenerTotalGastosPorPeriodo(usuarioId, DateTime.Now.AddMonths(-1), DateTime.Now);

        var usuario = _usuarioRepository.ObtenerUsuarioPorId(usuarioId);
        if (gastosMensuales > limite)
        {
            _logger.LogWarning($"¡Atención! {usuario.Nombres} ha excedido su límite de gastos este mes. Gastos: {gastosMensuales}, Límite: {limite}");
        }
    }
}
