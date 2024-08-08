namespace ProyectoFasr.DTO;

public class SaveTransaccionDTO
{
    public decimal Monto { get; set; }
    public DateTime Fecha { get; set; }
    public string Categoria { get; set; }
    public string Descripcion { get; set; }
    public int UsuarioId { get; set; }
}