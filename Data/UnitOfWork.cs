using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Data.GameRepo;

namespace task.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IGameRepository gameRepository => new GameRepository(_context);

        public async Task<bool> Complete()
        {
           return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            _context.ChangeTracker.DetectChanges();
            var changes = _context.ChangeTracker.HasChanges();

            return changes;
        }
    }
}