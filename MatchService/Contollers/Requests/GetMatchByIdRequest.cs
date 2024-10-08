using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Contollers.Requests
{
    public class GetMatchByIdRequest
    {
        public long match_id { get; set; }
    }
}