using Logistics.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<bool> CreateAsync(CreateVehicleDto request);
        Task<VehicleDto> GetByIdAsync(Guid id);
        Task<IReadOnlyList<VehicleDto>> GetAllAsync(VehicleFilter filter);
        Task<VehicleDto> UpdateAsync(Guid id, VehicleDto request);
        Task<bool> DeleteAsync(Guid id);
    }
}
