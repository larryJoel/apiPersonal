
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using ApiPersonas.Models;
namespace ApiPersonas
{
    public class PersonalContext: DbContext
    {
        public DbSet<Personal> personal{get;set;}

        public PersonalContext(DbContextOptions<PersonalContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Personal> personal = new List<Personal>();
            personal.Add(new Personal(){Id=Guid.Parse("a4e742e3-53ed-402e-98e8-56c9de359509"),
                                        Nombre="Luis A.", Apellido="Medina Perez", Direccion="C.A.B.A.",
                                        Documento="95984741"});

            modelBuilder.Entity<Personal>(personal=>{
                personal.ToTable("Personal");
                personal.HasKey(p=>p.Id);
                personal.Property(personal=>personal.Nombre).IsRequired().HasMaxLength(150);
                personal.Property(personal=>personal.Apellido).IsRequired().HasMaxLength(150);
                personal.Property(personal=>personal.Direccion).IsRequired().HasMaxLength(500);
                personal.Property(personal=>personal.Documento).HasMaxLength(150);
            });
        }
    }
}