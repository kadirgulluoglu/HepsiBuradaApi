using System;
using HepsiBuradaApi.Application.Interfaces;
using HepsiBuradaApi.Application.Interfaces.Repositories;
using HepsiBuradaApi.Persistence.Context;
using HepsiBuradaApi.Persistence.Repositories;

namespace HepsiBuradaApi.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public ValueTask DisposeAsync() => context.DisposeAsync();

        public int Save() => context.SaveChanges();

        public Task<int> SaveAsync() => context.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(context);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(context);

    }
}

