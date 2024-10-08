using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Database.Models
{
    public class Status
    {
        [Key]
        public long StatusId { get; set; }
        public string Name { get; set; }
    }
}