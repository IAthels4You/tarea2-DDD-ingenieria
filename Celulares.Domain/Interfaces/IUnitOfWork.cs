namespace Celulares.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        //esta es la interfaz del Unit of Work
        //Básicamente se hace de nuevo la inversión de dependencias, ahora la capa de aplicación depende de esta interfaz,
        //en lugar de depender directamente de una implementación concreta del Unit of Work.
        //Como patrón, el unit of work se encarga de coordinar las operaciones que involucran cambios en el estado de la base de datos,
        //asegurando que todas las operaciones se realicen correctamente o se deshagan en caso de error.
        //Por lo tanto, en vez de tener que llamar a diferentes métodos para guardar los cambios en la base de datos,
        //el servicio de aplicación simplemente llama a un método "CommitAsync" del Unit of Work,
        //que se encarga de coordinar todas las operaciones necesarias de un caso de uso para guardar los cambios de manera atómica.
        Task<int> CommitAsync();
    }
}
