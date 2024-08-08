using ProyectoFasr.model;

namespace ProyectoFasr.repository;

public interface ITransaccionRepository
{
   
    IEnumerable<Transaccion> ObtenerTransaccionesPorUsuario(string usuarioId);

    
    Transaccion ObtenerTransaccionPorId(int id);
    void AgregarTransaccion(Transaccion transaccion);
    void ActualizarTransaccion(Transaccion transaccion);
    void EliminarTransaccion(int id);
}