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
    public class ReferenceDataRepository : IReferenceDataRepository
    {
        private readonly LogisticsDbContext _dbContext;
        public ReferenceDataRepository(LogisticsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ReferenceData>> GetReferenceDataListAsync()
        {
            try
            {
                return await _dbContext.ReferenceData.Where(x => x.IsActive).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
