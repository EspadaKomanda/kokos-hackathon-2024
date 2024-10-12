using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialogService.Database.Models;

namespace DialogService.Services.DialogService
{
    public interface IDialogService
    {
        public IQueryable<Dialog> GetDialogs(long userId);
        public Task<bool> AddDialog(Dialog dialog);
        public Task<Dialog> GetDialog(long dialogId);
        public bool DeleteDialog(Dialog dialog);
        public Dialog GetDialog(long userId,long interlocutorId);
        public ICollection<Message> GetMessages(long dialogId);
    }
}