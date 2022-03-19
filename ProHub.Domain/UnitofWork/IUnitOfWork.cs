﻿using ProHub.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProHub.Domain.Entities;

namespace ProHub.Domain.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> RepositoryOf<TEntity>() where TEntity : class;

        //IRepository<Establishment> EstablishmentRepository { get; }
        //IRepository<DocumentHub> DocumentRepository { get; }
        //IRepository<LookupItem> LookupItemRepository { get; }


        ProHubDbContext Context { get; }
        bool Save();
        Task<bool> SaveAsync();
    }
}
