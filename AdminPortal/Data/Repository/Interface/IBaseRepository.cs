﻿using AdminPortal.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace AdminPortal.Data.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class, ITypeWithId
    {
        TEntity GetEntityById(int Id);

        IEnumerable<TEntity> Execute(Func<IDbConnection, 
            IEnumerable<TEntity>> query);
    }
}
