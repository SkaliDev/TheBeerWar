using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatService.Model
{
    public class ChatViewModel
    {
        public List<Chat> ChatMessages { get; set; }

        public ChatViewModel(List<Chat> chats)
        {
            ChatMessages = chats;
        }
    }
}
