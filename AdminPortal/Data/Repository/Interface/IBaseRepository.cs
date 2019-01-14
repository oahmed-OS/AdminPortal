﻿using AdminPortal.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace AdminPortal.Data.Repository
{
    interface IBaseRepository<TEntity> where TEntity : ITypeWithId
    {
        TEntity GetEntityById(int Id);

        IEnumerable<ITypeWithId> Execute(Action<IDbConnection> query);
    }
}
