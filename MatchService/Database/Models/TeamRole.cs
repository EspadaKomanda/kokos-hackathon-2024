using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Database.Models
{
    public class TeamRole
    {
        [Key]
        public long TeamRoleId { get; set; }

        [Required]
        public required string Name { get; set; }
        
        public ICollection<Player>? players { get; set; }
    }
}