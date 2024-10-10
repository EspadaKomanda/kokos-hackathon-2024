using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Contollers.Requests.Team
{
    public class UpdateTeamRequest
    {
        public long TeamId { get; set; }
        public string Name { get; set; }
        public List<MatchService.Database.Models.Player>? Players { get; set; }
        public List<MatchService.Database.Models.Match>? Matches { get; set; }
    }
}