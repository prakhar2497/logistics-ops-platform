using AutoMapper;
using Logistics.Application.DTOs;
using Logistics.Application.Interfaces;
using Logistics.Domain.Entities;
using Logistics.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper) 
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(CreateVehicleDto request)
        {
            try
            {
                if(request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }
                var mappedRequest = _mapper.Map<Vehicle>(request);
                await _vehicleRepository.CreateVehicleAsync(mappedRequest);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                if(id == Guid.Empty)
                {
                    throw new NullReferenceException("id cannot be null or empty");
                }
                await _vehicleRepository.DeleteVehicleAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<IReadOnlyList<VehicleDto>> GetAllAsync(VehicleFilter filter)
        {
            var vehicleList = await _vehicleRepository.GetAllAsync();
            if(vehicleList == null)
            {
                throw new NullReferenceException("Cannot find the vehicles");
            }

            var mappedVehicleList = _mapper.Map<IReadOnlyList<VehicleDto>>(vehicleList);
            
            if(filter.Type != null && filter.Type != Guid.Empty)
            {
                mappedVehicleList = mappedVehicleList.Where(x => x.Type == filter.Type).ToList();
            }

            if(filter.Status != null && filter.Status != Guid.Empty)
            {
                mappedVehicleList = mappedVehicleList.Where(x => x.Status == filter.Status).ToList();
            }

            return mappedVehicleList;
        }

        public async Task<VehicleDto> GetByIdAsync(Guid id)
        {
            try
            {
                var vehicle = await _vehicleRepository.GetByIdAsync(id);
                if (vehicle == null || vehicle.Id == Guid.Empty)
                {
                    throw new NullReferenceException(string.Format("Unable to find the vehicle of id {0}", id));
                }
                var res = _mapper.Map<VehicleDto>(vehicle);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<VehicleDto> UpdateAsync(Guid id, VehicleDto request)
        {
            try
            {
                if (request == null || id == Guid.Empty)
                {
                    throw new NullReferenceException("request cannot be null or empty");
                }
                var vehicle = _mapper.Map<Vehicle>(request);
                await _vehicleRepository.UpdateVehicleAsync(id, vehicle);
                return request;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
