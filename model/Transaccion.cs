namespace ProyectoFasr.model;

public class Transaccion
{
    public int Id { get; set; }
    public decimal Monto { get; set; }
    public DateTime Fecha { get; set; }
    public string Categoria { get; set; }
    public string Descripcion { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}