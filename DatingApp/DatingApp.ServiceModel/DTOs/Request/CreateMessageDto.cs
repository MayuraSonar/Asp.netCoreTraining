using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp.ServiceModel.DTOs.Request
{
    public class CreateMessageDto
    {
        public int RecipentId { get; set; }

        public string Content { get; set; }
    }
}
