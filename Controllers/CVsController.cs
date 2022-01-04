using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CVSITEHT2021.Models;

namespace CVSITEHT2021.Controllers
{
    public class CVsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CVs
        public async Task<ActionResult> Index()
        {
            return View(await db.cv.ToListAsync());
        }

        // GET: CVs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV cV = await db.cv.FindAsync(id);
            if (cV == null)
            {
                return HttpNotFound();
            }
            return View(cV);
        }

        // GET: CVs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Name,PhoneNumber,Mail,Education,Workplace,Competences")] CV cV)
        {
            if (ModelState.IsValid)
            {
                cV.Mail = User.Identity.Name;
                db.cv.Add(cV);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cV);
        }

        // GET: CVs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV cV = await db.cv.FindAsync(id);
            if (cV == null)
            {
                return HttpNotFound();
            }
            return View(cV);
        }

        // POST: CVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Name,PhoneNumber,Mail,Education,Workplace,Competences")] CV cV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cV).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cV);
        }

        // GET: CVs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV cV = await db.cv.FindAsync(id);
            if (cV == null)
            {
                return HttpNotFound();
            }
            return View(cV);
        }

        // POST: CVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CV cV = await db.cv.FindAsync(id);
            db.cv.Remove(cV);
            await db.SaveChangesAsync();
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

        public async Task<ActionResult> NameSearchForm()
        {
            return View();
        }

        public async Task<ActionResult> NameSearchResult(String SearchPhrase)
        {
            return View("Index", await db.cv.Where(j => j.Name.Contains
            (SearchPhrase)).ToListAsync());
        }
    }
}
