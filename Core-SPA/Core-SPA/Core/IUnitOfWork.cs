using System.Threading.Tasks;

namespace Core.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}