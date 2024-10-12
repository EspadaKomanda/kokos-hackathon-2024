using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DialogService.Database.Models
{
    public class Message
    {
        [Key]
        public long MessageId { get; set; }
        [ForeignKey("DialogId")]
        public long DialogId { get; set; }
        public Dialog Dialog { get; set; }
        [ForeignKey("RespondedMessageId")]
        public long? RespondedMessageId { get; set; }
        public Message? RespondedMessage { get; set; }
        public string Text { get; set; }
        public string Attachment { get; set; }
    }
}