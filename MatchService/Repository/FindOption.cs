using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Repository
{
    public class FindOptions
    {
        public bool IsIgnoreAutoIncludes { get; set; }
        public bool IsAsNoTracking { get; set; }
    }

}