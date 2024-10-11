using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Contollers.Requests.Player
{
    public class UpdatePlayerRequest
    {
        public long PlayerId { get; set; }
        public long TeamId { get; set; }
        public long? UserId {get;set;}
        public long? TeamRoleId{get;set;}
        public string? Country{get;set;}
    }
}