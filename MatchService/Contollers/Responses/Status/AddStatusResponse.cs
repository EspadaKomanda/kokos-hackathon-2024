using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Contollers.Responses.Status
{
    public class AddStatusResponse
    {
        public bool success {get; set;}
        public string? error {get;set;}
    }
}