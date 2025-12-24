using Logistics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Application.Interface
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
