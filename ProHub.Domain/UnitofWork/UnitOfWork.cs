using ProHub.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProHub.Domain.Entities;

namespace ProHub.Domain.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ProHubDbContext Context { get; }
        private Dictionary<Type, object> _repositories;

        //private IRepository<Establishment> _establishmentRepository;

        //public IRepository<Establishment> EstablishmentRepository =>
        //    _establishmentRepository ?? new Repository<Establishment>(context: Context);

        //private IRepository<DocumentHub> _documentRepository;

        //public IRepository<DocumentHub> DocumentRepository =>
        //    _documentRepository ?? new Repository<DocumentHub>(context: Context);


        //private IRepository<LookupItem> _lookupItemRepository;

        //public IRepository<LookupItem> LookupItemRepository =>
        //    _lookupItemRepository ?? new Repository<LookupItem>(context: Context);




        private readonly ILogger _logger;


        public UnitOfWork(ProHubDbContext context, ILoggerFactory loggerFactory)
        {
            this.Context = context;
            _logger = loggerFactory.CreateLogger("logs");
            //  _establishmentRepository = new Repository<Establishment>(context);
        }

        public void Dispose()
        {
            Context?.Dispose();
            GC.SuppressFinalize(this);

        }


        public bool Save()
        {
            return Context.SaveChanges() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            return await Context.SaveChangesAsync() > 0;
        }

        public IRepository<TEntity> RepositoryOf<TEntity>() where TEntity : class
        {
            _repositories ??= new Dictionary<Type, object>();
            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] =
                new Repository<TEntity>(Context);
            return (IRepository<TEntity>)_repositories[type];
        }
    }
}
