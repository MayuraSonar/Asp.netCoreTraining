using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingApp.DataModel.Context;
using DatingApp.DataModel.Entities;
using DatingApp.DataModel.Helper;
using DatingApp.DataModel.Repositories.Interfaces;
using DatingApp.ServiceModel.DTOs.Request;
using DatingApp.ServiceModel.DTOs.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.DataModel.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DatingAppDbContext _datingAppDbContext;
        private readonly IMapper _mapper;

        public MessageRepository(DatingAppDbContext datingAppDbContext, IMapper mapper)
        {
            _datingAppDbContext = datingAppDbContext;
            _mapper = mapper;
        }
        public void AddMessage(Messages messages)
        {
            _datingAppDbContext.Message.Add(messages);
        }

        public void DeleteMessage(Messages messages)
        {
            _datingAppDbContext.Message.Add(messages);
        }



        public async Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams)
        {
            var query = _datingAppDbContext.Message
                .OrderByDescending(m => m.MessageSent)
                .ProjectTo<MessageDto>(_mapper.ConfigurationProvider)
                .AsQueryable();

            query = messageParams.Container switch
            {
                "Inbox" => query.Where(u => u.RecipientId == messageParams.UserId
                    && u.RecipientDeleted == false),
                "Outbox" => query.Where(u => u.SenderId == messageParams.UserId
                    && u.SenderDeleted == false),
                _ => query.Where(u => u.RecipientId ==
                    messageParams.UserId && u.RecipientDeleted == false && u.DateRead == null)
            };

            var message = query.ProjectTo<MessageDto>(_mapper.ConfigurationProvider);
            return await PagedList<MessageDto>.CreateAsync(message, messageParams.PageNumber, messageParams.PageSize);

        }

        public async Task<Messages> GetMessages(int id)
        {
            return await _datingAppDbContext.Message
              .Include(u => u.Sender)
              .Include(u => u.Receipent)
              .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<MessageDto>> GetMessageThread(int currentUserId, int receipentId)
        {
            var message = await _datingAppDbContext.Message
                  .Where(m => m.Receipent.Id == currentUserId && m.ReceipentDeleted == false
                  && m.Sender.Id == receipentId || m.Receipent.Id == receipentId
                  && m.Sender.Id == currentUserId && m.SenderDeleted == false).OrderBy(m => m.MessageSent)
                  .ProjectTo<MessageDto>(_mapper.ConfigurationProvider).ToListAsync();

            var unreadMessages = message.Where(m => m.DateRead == null && m.RecipientId == currentUserId).ToList();
            if (unreadMessages.Any())
            {
                foreach (var messages in unreadMessages)
                {
                    messages.DateRead = DateTime.UtcNow;
                }
            }

            return message;
        }


       
        public async Task<bool> SaveAllAsync()
        {
            return await _datingAppDbContext.SaveChangesAsync() > 0;
        }
    }
}

     

    
       
    

