using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using task.Entities;

namespace task.Data
{
    public class Seed
    {
        public  static async Task seedGames(DataContext _context){
            var gamess = await _context.Games.ToListAsync();
            if(gamess.Count()>0) return;

            var gameData = await System.IO.File.ReadAllTextAsync("Data/SeedData.json");
            var games = JsonSerializer.Deserialize<List<Game>>(gameData);

            if(games ==null) return ;

            
            foreach(var game in games ){
                await _context.Games.AddAsync(game);
            }
            await _context.SaveChangesAsync();
        }
    }
}