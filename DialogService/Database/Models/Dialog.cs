using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DialogService.Database.Models
{
    public class Dialog
    {
        [Key]
        public long DialogId { get; set; }
        public long User1Id {get;set;}
        public long User2Id {get;set;}
        public bool IsBlocked {get;set;}
        public ICollection<Message> Messages {get;set;}
    }
}