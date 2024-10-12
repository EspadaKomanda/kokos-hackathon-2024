using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialogService.Database.Models;
using DialogService.Exceptions;
using DialogService.Repository;
using Microsoft.EntityFrameworkCore;

namespace DialogService.Services.DialogService
{
    public class DialogService : IDialogService
    {
        private readonly IRepository<Dialog> _dialogRepository;

        public DialogService(IRepository<Dialog> dialogRepository)
        {
            _dialogRepository = dialogRepository;
        }
        public async Task<bool> AddDialog(Dialog dialog)
        {
            try
            {
                return await _dialogRepository.Add(dialog);
            }
            catch(Exception ex)
            {
                throw new AddException(ex.Message);
            }
        }

        public bool DeleteDialog(Dialog dialog)
        {
            try
            {
                return _dialogRepository.Delete(dialog);
            }
            catch(Exception ex)
            {
                throw new DeleteException(ex.Message);
            }
        }

        public async Task<Dialog> GetDialog(long dialogId)
        {
            try
            {
                return await _dialogRepository.FindOne(x => x.DialogId == dialogId);
            }
            catch(Exception ex)
            {
                throw new GetException(ex.Message);
            }
        }

        public Dialog GetDialog(long userId, long interlocutorId)
        {
            try
            {
                return  _dialogRepository.GetAll().Where(x => x.User1Id == userId && x.User2Id == interlocutorId).Include(x => x.Messages).FirstOrDefault()!;
            }
            catch(Exception ex)
            {
                throw new GetException(ex.Message);
            }
        }

        public IQueryable<Dialog> GetDialogs(long userId)
        {
            try
            {
                return _dialogRepository.GetAll().Where(x => x.User1Id == userId || x.User2Id == userId);
            }
            catch(Exception ex)
            {
                throw new GetException(ex.Message);
            }
        }

        public ICollection<Message> GetMessages(long dialogId)
        {
            try
            {
                return _dialogRepository.GetAll().Where(x => x.DialogId == dialogId).Include(x => x.Messages).FirstOrDefault()!.Messages;
            }
            catch(Exception ex)
            {
                throw new GetException(ex.Message);
            }
        }
    }
}