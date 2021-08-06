using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.Api.Extensions;
using DatingApp.Api.Services.Interfaces;
using DatingApp.DataModel.Entities;
using DatingApp.DataModel.Helper;
using DatingApp.ServiceModel.DTOs.Request;
using DatingApp.ServiceModel.DTOs.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        IMapper _mapper;
        private readonly IUserService _userService;
        public MessageController(IMessageService messageService, IUserService userService, IMapper mapper)
        {
            _messageService = messageService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<MessageDto>> CreateMessage(CreateMessageDto createMessageDto)
        {
            var userId = User.GetUserId();
            if (userId == createMessageDto.RecipentId) return BadRequest("you cannot send message to yourself");
            var senderId = await _userService.GetByIdAsync(userId);
            var receipentId = await _userService.GetByIdAsync(createMessageDto.RecipentId);
            if (receipentId == null) return NotFound();
            var message = new Messages
            {
                Sender = senderId,
                Receipent = receipentId,
                SenderId = senderId.Id,
                RecipentId = receipentId.Id,
                Content = createMessageDto.Content

            };

            _messageService.AddMessage(message);
            if (await _messageService.SaveAllAsync()) return Ok(_mapper.Map<MessageDto>(message));
            return BadRequest("Failed to send Message");

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessageForUser([FromQuery] MessageParams messageParams)
        {
            messageParams.UserId = User.GetUserId();
            var message = await _messageService.GetMessagesForUser(messageParams);
            Response.AddPaginationHeader(message.CurrentPage, message.PageSize,
              message.TotalCount, message.TotalPages);

            return message;
        }

        [HttpGet("thread/{userId}")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessageThread(int userId)
        {
            var currentId = User.GetUserId();
            return Ok(await _messageService.GetMessageThread(currentId, userId));
        }

    }
      
    }

