using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Contollers.Requests.TeamRole
{
    public class UpdateTeamRoleRequest
    {
        public long TeamRoleId { get; set; }
        public string Name { get; set; }
        public List<MatchService.Database.Models.Match>? players { get; set; }
    }
}