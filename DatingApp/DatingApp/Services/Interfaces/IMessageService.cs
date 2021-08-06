using DatingApp.DataModel.Entities;
using DatingApp.DataModel.Helper;
using DatingApp.ServiceModel.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Api.Services.Interfaces
{
   public interface IMessageService
    {
        void AddMessage(Messages messages);
        void DeleteMessage(Messages messages);
        Task<Messages> GetMessages(int id);
        Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams);
        Task<IEnumerable<MessageDto>> GetMessageThread(int currentUserId, int receipentId);
        Task<bool> SaveAllAsync();
    }
}
