using AutoMapper;
using Logistics.Application.DTOs;
using Logistics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Application.MappingProfiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleDto, Vehicle>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.StatusId, o => o.MapFrom(s => s.Status))
                .ForMember(d => d.LastServiceDate, o => o.Ignore())
                .ForMember(d => d.Deliveries, o => o.Ignore());

            CreateMap<Vehicle, VehicleDto>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.StatusId));

            CreateMap<VehicleDto, VehicleDto>();
        }
    }
}
