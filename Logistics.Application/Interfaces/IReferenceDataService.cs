using Logistics.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Application.Interfaces
{
    public interface IReferenceDataService
    {
        Task<List<ReferenceDataDto>> GetAllReferenceDataAsync();
    }
}
