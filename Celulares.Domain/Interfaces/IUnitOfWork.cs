namespace Celulares.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
