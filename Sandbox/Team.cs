using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Team
    {
        public Team(string name, List<string> players)
        {
            Name = name;
            Players = players;
        }

        public string Name { get; set; }
        [MaxLength(11)]
        [MinLength(11)]
        public List<string> Players { get; set; }
    }
}
