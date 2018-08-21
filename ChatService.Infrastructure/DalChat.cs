using ChatService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatService.Infrastructure
{
    public class DalChat
    {
        private ChatContext _context;

        public DalChat()
        {
            _context = new ChatContext();
        }

        public void AddMessage(Chat chat)
        {
            try
            {
                chat.ToPrint = chat.Printed = false;
                _context.Chats.Add(chat);
                if (_context.SaveChanges() == 0)
                    throw new Exception("An error occured when creating chat message.");
            }
            catch
            {
                throw new Exception("An error occured when creating chat message.");
            }
        }
        public List<Chat> GetMessages()
        {
            return _context.Chats.OrderBy(c => c.Time).Skip(Math.Max(0, _context.Chats.Count() - 10)).ToList();
        }
    }
}
