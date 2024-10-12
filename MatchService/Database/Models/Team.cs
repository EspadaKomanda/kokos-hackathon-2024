using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Database.Models
{
    public class Team
    {
        [Key]
        public long TeamId {get;set;}
        [Required]
        public string Name {get;set;}
        public ICollection<Player>? Players {get;set;}
        public ICollection<Match>? Matches {get;set;}
    }
}