using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IAutomobileContext
    {
        public DbSet<Automobile> Automobiles { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        public Task<IDbContextTransaction> BeginTransactionAsync();
        public Task CommitTransactions(IDbContextTransaction transaction);
    }
}
