using HospitalApi.Application.Interfaces.Repositories;
using HospitalApi.Application.Interfaces.UnitOfWorks;
using HospitalApi.Persistence.Context;
using HospitalApi.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();


        public int Save() => dbContext.SaveChanges();
        public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext); //ReadRepository, Constructorda dbContext'i alıyor.
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);
    }
}
