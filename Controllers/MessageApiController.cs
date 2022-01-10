using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using data.Repo;
using data.Models;

namespace CVSITEHT2021.Controllers
{
    public class MessageApiController : ApiController
    {

        private readonly CVDatabase _context;
        public MessageRepository msgRepo
        {
            get { return new MessageRepository(_context ?? new CVDatabase()); }
        }
        public CVRepository cvRepo
        {
            get { return new CVRepository(_context ?? new CVDatabase()); }
        }

        [Route("api/SendAPI/{id}/{title}/{content}/{sender}")]
        [HttpGet]
        public IHttpActionResult SendMessage(int id, string Title,  string Content, string sender)
        {
            Message msg = new Message
            {
                title = Title,
                content = Content,
                Sender = sender,
                CVId = id,
                isRead = false,
            };
            msgRepo.saveMessage(msg);
            return Ok();
        }
    
        [Route("api/CountMsg/")]
        [HttpGet]
        public int countMsg()
        {
            var cv = cvRepo.getCvByUser(User.Identity.Name);
            if (cv != null)
            {
                var msg = msgRepo.getUsersUnreadMsg(cv.id);
                return msg.Count();
            }
            return 0;
        }

    }
}

