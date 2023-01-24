using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task.Entities
{
    public class Game
    { 
        public int Id { get; set; }
        public int userId { get; set; }
        public string game { get; set; }
        public int playTime { get; set; }
        public string genre { get; set; }
        public string[] platforms { get; set; }
    }
}