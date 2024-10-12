using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialogService.Database.Models;

namespace DialogService.Services.MessageService
{
    public interface IMessageService
    {
        public Task<bool> AddMessage(Message message);
    }
}