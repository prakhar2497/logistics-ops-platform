using Logistics.Domain.Entities;
using Logistics.Infrastructure.Context;
using Logistics.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Infrastructure.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly LogisticsDbContext _dbContext;
        
        public VehicleRepository(LogisticsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateVehicleAsync(Vehicle vehicle)
        {
            try
            {
                await _dbContext.Vehicles.AddAsync(vehicle);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }

        public async Task DeleteVehicleAsync(Guid id)
        {
            try
            {
                if(id == Guid.Empty)
                {
                    throw new KeyNotFoundException(string.Format("Unable to find vehicle with Id {0}", id));
                }
                var vehicle = await _dbContext.Vehicles.FirstOrDefaultAsync(x => x.Id == id);
                if(vehicle == null)
                {
                    throw new NullReferenceException(nameof(vehicle));
                }
                _dbContext.Vehicles.Remove(vehicle);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Vehicles.AsNoTracking().ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Vehicle> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.Vehicles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task UpdateVehicleAsync(Guid id, Vehicle vehicle)
        {
            try
            {
                var vehicleFromDB = await this.GetByIdAsync(id);
                if(vehicleFromDB == null)
                {
                    throw new NullReferenceException(string.Format("Cannot find value with Id {0}", id));
                }
                vehicle.Id = vehicleFromDB.Id;
                _dbContext.Vehicles.Update(vehicle);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
