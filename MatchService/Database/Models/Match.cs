using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Database.Models
{
    public class Match
    {
        [Key]
        public long MatchId { get; set; }
        [ForeignKey("Team1Id")]
        public long Team1Id { get; set; }
        public virtual Team Team1 { get; set; }
        [ForeignKey("Team2Id")]
        public long Team2Id { get; set; }
        public virtual Team Team2 { get; set; }
        [ForeignKey("StatusId")]
        public long StatusId { get; set; }
        public Status Status { get; set; }
        public DateTime? SheduledStart { get; set; }
        public DateTime? EndedAt { get; set; }
        public string? EventName {get;set;}
        public string? Result {get;set;}
        public string? StreamRecord {get;set;}
        public string? Json {get;set;}
    }
}