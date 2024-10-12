using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialogService.Database.Models;
using DialogService.Exceptions;
using DialogService.Repository;

namespace DialogService.Services.MessageService
{
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> _messageRepository;

        public MessageService(IRepository<Message> messageRepository)
        {
            _messageRepository = messageRepository;
        }
        
        public async Task<bool> AddMessage(Message message)
        {
            try
            {
                return await _messageRepository.Add(message);
            }
            catch(Exception ex)
            {
                throw new AddException(ex.Message);
            }
        }

       
    }
}