using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Contollers.Responses.Match
{
    public class AddMatchResponse
    {
        public bool success { get; set; }
        public string? error { get; set; }
    }
}