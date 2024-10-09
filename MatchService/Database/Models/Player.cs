using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Database.Models
{
    public class Player
    {
        [Key]
        public long PlayerId { get; set; }
        [ForeignKey("TeamId")]
        public long TeamId { get; set; }
        [Required]
        public Team Team { get; set; }
        public long? UserId { get; set; }
        [ForeignKey("TeamRoleId")]
        public long? TeamRoleId { get; set; }
        [Required]
        public TeamRole TeamRole { get; set; }
    }
}