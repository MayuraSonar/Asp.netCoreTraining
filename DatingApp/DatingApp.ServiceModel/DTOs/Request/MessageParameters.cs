using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp.ServiceModel.DTOs.Request
{
   public class MessageParameters
    {
        public int UserId { get; set; }

        public string Contents { get; set; } = "unread";
    }
}
