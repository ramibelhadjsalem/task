using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task.Dtos
{
    public class GameDto
    {
        [Required]
        public int userId { get; set; }
         [Required]
        public string game { get; set; }
         [Required]
        public int playTime { get; set; }
         [Required]
        public string genre { get; set; }
         [Required]
        public string[] platforms { get; set; }
    }
}