using ChatService.Infrastructure;
using ChatService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatService.Service
{
    public class ChatService
    {
        private readonly DalChat _context = new DalChat();

        public void AddMessage(Chat chat)
        {
            _context.AddMessage(chat);
        }
        public List<Chat> GetMessages(List<Chat> chatMessages)
        {
            List<Chat> chatMessagesDb = _context.GetMessages();
            foreach (var cc in chatMessagesDb)
            {
                if (chatMessages.FirstOrDefault(c => c.Id == cc.Id) == null)
                    chatMessages.Add(cc);
            }
            return chatMessages;
        }
    }
}
