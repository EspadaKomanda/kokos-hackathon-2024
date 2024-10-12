using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchService.Database.Models;

namespace MatchService.Contollers.Requests.Team
{
    public class AddTeamRequest
    {
        public string Name { get; set; }
        public List<MatchService.Database.Models.Player>? Players { get; set; }
        public List<MatchService.Database.Models.Match>? Matches { get; set; }
    }
}