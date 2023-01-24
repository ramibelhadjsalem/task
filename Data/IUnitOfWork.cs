using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Data.GameRepo;

namespace task.Data
{
    public interface IUnitOfWork
    {
        IGameRepository gameRepository {get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}