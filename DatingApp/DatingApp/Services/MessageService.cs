using DatingApp.Api.Services.Interfaces;
using DatingApp.DataModel.Entities;
using DatingApp.DataModel.Helper;
using DatingApp.DataModel.Repositories.Interfaces;
using DatingApp.ServiceModel.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Api.Services
{
    public class MessageService:IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public void AddMessage(Messages messages)
        {
            _messageRepository.AddMessage(messages);
        }

        public void DeleteMessage(Messages messages)
        {
            _messageRepository.DeleteMessage(messages);
        }

   
        public async Task<Messages> GetMessages(int id)
        {
        return await    _messageRepository.GetMessages(id);
        }

        public async Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams)
        {
            return await _messageRepository.GetMessagesForUser(messageParams);
        }

        public async Task<IEnumerable<MessageDto>> GetMessageThread(int currentUserId, int receipentId)
        {
            return await _messageRepository.GetMessageThread(currentUserId, receipentId);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _messageRepository.SaveAllAsync();
        }
    }
}
