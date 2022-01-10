using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CVSITEHT2021.Models;

namespace CVSITEHT2021.Repo
{
    public class MessageRepository
    {
        private readonly CVDatabase _context;

        public MessageRepository(CVDatabase context)
        {
            _context = context;
        }
        public MessageRepository cvRepo
        {
            get { return new MessageRepository(_context ?? new CVDatabase()); }
        }

        public bool newMessage(Message newMessage)
        {
            _context.Messages.Add(newMessage);
            _context.SaveChanges();
            return (true);
        }

        public Message GetMessageById(int id)
        {
            var msg = _context.Messages.FirstOrDefault(x => x.MessageId == id);
            return msg;
        }

        public List<Message> GetMessageByCV(int id)
        {
            var msg = _context.Messages.Where(x => x.CVId == id).ToList();

            return msg;
        }

        public List<Message> getMsgByUser(string user)
        {
                var UserCVID = _context.cv.FirstOrDefault(x => x.Mail == user).id;
                return GetMessageByCV(UserCVID);
        }

        public List<Message> getUsersUnreadMsg(int id)
        {
            var msg = GetMessageByCV(id);
            return msg.Where(x => x.isRead == false).ToList();
        }


        public void saveMessage(Message message)
        {
            if (message.MessageId != 0) 
            {
                _context.Entry(message).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                _context.Messages.Add(message);
            }
            _context.SaveChanges();
        }

        public void markMessageRead(int id)
        {
            var msg = GetMessageById(id);
            msg.isRead = true;
            saveMessage(msg);
        }



    }
}