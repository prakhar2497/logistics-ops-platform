using Logistics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Infrastructure.Interface
{
    public interface IVehicleRepository
    {
        Task CreateVehicleAsync(Vehicle vehicle);
        Task<Vehicle> GetByIdAsync(Guid id);
        Task<IEnumerable<Vehicle>> GetAllAsync();
        Task UpdateVehicleAsync(Guid id, Vehicle vehicle);
        Task DeleteVehicleAsync(Guid id);
    }
}
