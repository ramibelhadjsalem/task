using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using task.Entities;
using task.Extentions;
using task.Helpers;

namespace task.Data.GameRepo
{
    public class GameRepository : IGameRepository
    {
       private readonly DataContext _context;

        public GameRepository(DataContext context)
        {
            _context = context;
        }

        

        public async Task<IEnumerable<Game>> findAll(GameParams gameParams)
        {
            var query =  _context.Games.AsEnumerable();
            query = query.OrderByDescending(x=> x.playTime);
            
            if(!String.IsNullOrEmpty( gameParams.genre)){
                 query = query.Where(game =>game.genre.ToLower() ==gameParams.genre.ToLower());
            }
           if(!String.IsNullOrEmpty( gameParams.platform)){
                  query = query
                    .Where( game =>game.platforms.Any(singlPlatform => singlPlatform.ToLower() ==gameParams.platform.ToLower()));
            }
           
            return  query;
        }

        public async Task<Game> findById(int id)
        {
            return await _context.Games.FindAsync(id);
            
        }
        public async Task<Game> addGame(Game game)
        {
             await _context.Games.AddAsync(game);
             await _context.SaveChangesAsync();
             return game;
        }

        public async Task DeleteGame(Game game)
        {
         
             _context.Games.Remove(game);
            
        }
    }
}