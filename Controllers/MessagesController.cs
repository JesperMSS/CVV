using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CVSITEHT2021.Repo;
using CVSITEHT2021.Models;

namespace CVSITEHT2021.Controllers
{
    public class MessagesController : Controller
    {
        private CVDatabase db = new CVDatabase();
        private readonly CVDatabase _context;
        public CVRepository cvRepo
        {
            get { return new CVRepository(_context ?? new CVDatabase()); }
        }
        public MessageRepository msgRepo
        {
            get { return new MessageRepository(_context ?? new CVDatabase()); }
        }

        // GET: Messages
        public ActionResult Index()
        {
                var cv = cvRepo.getCvByUser(User.Identity.Name);
                if(cv == null)
                {
                return HttpNotFound();
            }
                var messages = msgRepo.getMsgByUser(User.Identity.Name);
                return View(messages.ToList());
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create(int id)
        {

            CV cV = db.cv.FirstOrDefault(x => x.Mail == User.Identity.Name);
            if(cV== null)
            {
                var modelWithOutSender = new MessagesViewModel
                {          
                    Reciver = id,

                };
                return View(modelWithOutSender);
            }

            var model = new MessagesViewModel
            {
                Sender = cV.Name,
                Reciver = id,
            };

            return View(model);
        }

        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageId,title,content,isRead,Sender,CVId")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CVId = new SelectList(db.cv, "id", "Name", message.CVId);
            return View(message);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.CVId = new SelectList(db.cv, "id", "Name", message.CVId);
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageId,title,content,isRead,Sender,CVId")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CVId = new SelectList(db.cv, "id", "Name", message.CVId);
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult markRead(int id)
        {
                msgRepo.markMessageRead(id);
                return RedirectToAction("Index");   
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
