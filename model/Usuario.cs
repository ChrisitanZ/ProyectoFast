namespace ProyectoFasr.model;

public class Usuario
{
    public string Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public ICollection<Transaccion> Transacciones { get; set; } = new List<Transaccion>();
    public ICollection<Prediccion> Predicciones { get; set; } = new List<Prediccion>();
}