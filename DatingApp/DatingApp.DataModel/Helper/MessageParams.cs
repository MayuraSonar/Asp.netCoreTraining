using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp.DataModel.Helper
{
   public class MessageParams:PaginationParams
    {
        public int UserId { get; set; }
        public string Container { get; set; } = "Unread";
    }
}
