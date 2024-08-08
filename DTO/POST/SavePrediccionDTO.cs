namespace ProyectoFasr.DTO;

public class SavePrediccionDTO
{
    public decimal Monto { get; set; }
    public DateTime Fecha { get; set; }
    public string Categoria { get; set; }
    public int UsuarioId { get; set; }
}