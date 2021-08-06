using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp.DataModel.Entities
{
    public class Messages
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SendUserName { get; set; }
        public User Sender { get; set; }
        public int RecipentId { get; set; }
        public string ReceipentUserName { get; set; }

        public User Receipent { get; set; }

        public string Content { get; set; }

        public DateTime? DateRead { get; set; }
        public DateTime MessageSent { get; set; } = DateTime.Now;

        public bool SenderDeleted { get; set; }
        public bool ReceipentDeleted { get; set; }

    }
}
