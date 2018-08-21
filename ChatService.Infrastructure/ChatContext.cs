using ChatService.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatService.Infrastructure
{
    public class ChatContext : DbContext
    {
        public ChatContext() : base("ChatDBContex")
        {
        }

        public DbSet<Chat> Chats { get; set; }
    }
}
