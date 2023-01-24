using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Entities;
using task.Helpers;

namespace task.Data.GameRepo
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> findAll(GameParams gameParams);
        Task<Game> findById(int id) ;
        Task<Game> addGame(Game game);
        Task DeleteGame(Game game);


    }
}