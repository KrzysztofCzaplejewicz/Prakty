using System.Collections.Generic;
using System.Threading.Tasks;
using vega.Models;

namespace vega.Persistence
{
    public interface IVehicleRepository
    {
          Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
          Task<IEnumerable<Vehicle>> GetVehicles(Filter filter);

          void Add(Vehicle vehicle);

          void Remove(Vehicle vehicle);
        
    }

}