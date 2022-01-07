using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CVSITEHT2021.Models;
using CVSITEHT2021.Repo;

namespace CVSITEHT2021.Controllers
{
    public class MessageApiController : ApiController
    {

        private readonly CVDatabase _context;
        public MessageRepository msgRepo
        {
            get { return new MessageRepository(_context ?? new CVDatabase()); }
        }

        [Route("api/SendAPI/{id}/{content}/{sender}")]
        [HttpGet]
        public IHttpActionResult SendMessage(int id, string Content, string sender)
        {
            Message msg = new Message
            {
                content = Content,
                Sender = sender,
                CVId = id,
                isRead = false,
            };
            msgRepo.saveMessage(msg);
            return Ok();
        }
    
    }
}
