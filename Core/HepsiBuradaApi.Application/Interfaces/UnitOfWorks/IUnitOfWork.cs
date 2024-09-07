﻿using System;
using HepsiBuradaApi.Application.Interfaces.Repositories;
using HepsiBuradaApi.Domain.Common;

namespace HepsiBuradaApi.Application.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();
    }
}
