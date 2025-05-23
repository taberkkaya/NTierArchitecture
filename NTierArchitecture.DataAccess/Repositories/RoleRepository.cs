﻿using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.DataAccess.Repositories;

internal class RoleRepository : Repository<AppRole>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context) : base(context)
    {
    }
}
