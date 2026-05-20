using Celulares.Domain.Entities;

namespace Celulares.Domain.Interfaces
{
    public interface ICelularRepository
    {
        //Esta es la interfaz del repositorio, define las operaciones que se pueden realizar con los celulares a nivel de acceso a datos
        //es el reflejo de la inversión de dependencias, que menciona la lectura.
        //Ahora la capa de aplicación depende de esta interfaz, en lugar de depender directamente de una implementación concreta del repositorio,
        //que se implemente en la capa de infraestructura
        //La inversión se puede ver porque la capa de aplicación depende del dominio y asimismo la infraestructura también depende del dominio,
        // por lo que los módulos de alto nivel (aplicación, dominio) no dependen de los módulos de bajo nivel (infrastructura, acceso a datos)
        Task<Celular?> GetByIdAsync(Guid id);
        Task<IEnumerable<Celular>> GetAllAsync();
        Task AddAsync(Celular celular);
        void Update(Celular celular);
        void Delete(Celular celular);
    }
}
