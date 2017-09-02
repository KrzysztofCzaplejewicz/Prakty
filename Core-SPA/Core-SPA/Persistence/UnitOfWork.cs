using Core.Core;
using System.Threading.Tasks;

namespace Core.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoreDbContext context;

        public UnitOfWork(CoreDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
