using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Contollers.Requests.Status
{
    public class UpdateStatusRequest
    {
        public long StatusId { get; set; }
        public string Name { get; set; }
    }
}