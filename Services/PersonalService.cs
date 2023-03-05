using ApiPersonas.Models;
namespace ApiPersonas.Services
{
    public class PersonalService
    {
        PersonalContext _Context;
        public PersonalService(PersonalContext context)
        {
            _Context = context;
        }
        public IEnumerable<Personal> Get()
        {
            return _Context.personal;
        }
        public async Task Save(Personal personal)
        {
            _Context.Add(personal);
            await _Context.SaveChangesAsync();
        }

        public async Task Update(Guid Id, Personal personal)
        {
              var datosActuales = _Context.personal.Find(Id);
              if(datosActuales.Id != null){
                datosActuales.Nombre = personal.Nombre;
                datosActuales.Apellido = personal.Apellido;
                datosActuales.Direccion = personal.Direccion;
                datosActuales.Documento = personal.Documento;
                await _Context.SaveChangesAsync();
              }
        }

        public async Task Delete(Guid Id)
        {
             var datosActuales = _Context.personal.Find(Id);
              if(datosActuales.Id != null){
                _Context.Remove(datosActuales);
                await _Context.SaveChangesAsync();
              }
        }
    }
    public interface IPersonalService
    {
        IEnumerable<Personal> Get();
        Task Save(Personal personal);
        Task Update(Guid Id, Personal personal);
        Task Delete(Guid Id);
    }
}