using Logistics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Infrastructure.Interface
{
    public interface IReferenceDataRepository
    {
        Task<List<ReferenceData>> GetReferenceDataListAsync();
    }
}
