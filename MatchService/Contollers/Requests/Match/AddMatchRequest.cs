using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchService.Contollers.Requests
{
    public class AddMatchRequest
    {
        public long Team1Id { get; set; }
        public long Team2Id { get; set; }
        public long StatusId { get; set; }
        public DateTime? SheduledStart { get; set; }
        public DateTime? EndedAt { get; set; }
        public string? EventName {get;set;}
        public string? Result {get;set;}
        public string? StreamRecord {get;set;}
        public string? Json {get;set;}
    }
}