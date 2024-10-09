using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Contollers.Requestss.Player
{
    public class AddPlayerRequest
    {
        public long TeamId { get; set; }
        public long? UserId {get;set;}
        public long? TeamRoleId{get;set;}
    }
}