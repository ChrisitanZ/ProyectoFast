using Microsoft.EntityFrameworkCore;
using ProyectoFasr.model;

namespace ProyectoFasr.Data;

public class AppDbContext :DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Transaccion> Transacciones { get; set; }
   /* public DbSet<Prediccion> Predicciones { get; set; }*/

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Usuario>().ToTable("Usuario");
        builder.Entity<Usuario>().HasKey(u => u.Id);
        builder.Entity<Usuario>().Property(u => u.Nombre).IsRequired().HasMaxLength(100);
        builder.Entity<Usuario>().Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Entity<Usuario>().Property(u => u.Password).IsRequired().HasMaxLength(100);
        
        builder.Entity<Transaccion>().ToTable("Transaccion");
        builder.Entity<Transaccion>().HasKey(t => t.Id);
        builder.Entity<Transaccion>().Property(t => t.Monto).IsRequired();
        builder.Entity<Transaccion>().Property(t => t.Fecha).IsRequired();
        builder.Entity<Transaccion>().Property(t => t.Categoria).IsRequired();
        builder.Entity<Transaccion>().Property(t => t.Descripcion);
        builder.Entity<Transaccion>().Property(t => t.UsuarioId).IsRequired();
        
        /*builder.Entity<Prediccion>().ToTable("Prediccion");
        builder.Entity<Prediccion>().HasKey(p => p.Id);
        builder.Entity<Prediccion>().Property(p => p.Monto).IsRequired().HasMaxLength(100);
        builder.Entity<Prediccion>().Property(p => p.Fecha).IsRequired().HasMaxLength(100);
        builder.Entity<Prediccion>().Property(p => p.Categoria).IsRequired().HasMaxLength(100);
        builder.Entity<Prediccion>().Property(p => p.UsuarioId).IsRequired();*/
        
        

        builder.Entity<Transaccion>()
            .HasOne(t => t.Usuario)
            .WithMany(u => u.Transacciones)
            .HasForeignKey(t => t.UsuarioId);

        /*builder.Entity<Prediccion>()
            .HasOne(p => p.Usuario)
            .WithMany(u => u.Predicciones)
            .HasForeignKey(p => p.UsuarioId);*/
    }
}