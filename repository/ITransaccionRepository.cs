using ProyectoFasr.model;

namespace ProyectoFasr.repository;

public interface ITransaccionRepository
{
   
    IEnumerable<Transaccion> ObtenerTransaccionesPorUsuario(int usuarioId);

    
    Transaccion ObtenerTransaccionPorId(int id);
    void AgregarTransaccion(Transaccion transaccion);
    void ActualizarTransaccion(Transaccion transaccion);
    void EliminarTransaccion(int id);
    IEnumerable<Transaccion> ObtenerTransacciones();
}