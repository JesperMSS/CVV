using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using CVSITEHT2021.Models;
using data.Models;
using data.Repo;

namespace CVSITEHT2021.Controllers
{
    public class CVsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly CVDatabase _context;
        public CVRepository cvRepo
        {
            get { return new CVRepository(_context ?? new CVDatabase()); }
        }

        // GET: CVs
        [Authorize]
        public ActionResult Index()
        {
            var user = User.Identity.Name;
            ViewBag.CV = user;

            return View(cvRepo.GetAllCvs());
        }

        // GET: CVs/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV cV = cvRepo.getCv(id);
            if (cV == null)
            {
                return HttpNotFound();
            }
            return View(cV);
        }

        // GET: CVs/Create
        [Authorize]
        public ActionResult Create()
        {
            var user = User.Identity.Name;

           if(cvRepo.getCvByUser(user) == null)
            {
                return View();
            }
            var id = cvRepo.getIdByUser(User.Identity.Name);
            return RedirectToAction("Details/" + id);
        }

        // POST: CVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(data.Shared.CvEditViewModel cV)
        {
            if (ModelState.IsValid)
            {
                cV.Mail = User.Identity.Name;
                cvRepo.createCv(cV);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cV);
        }

        // GET: CVs/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV cV = await db.cv.FindAsync(id);
            CvEditViewModel model = new CvEditViewModel
            {
                Id = cV.id,
                Competences = cV.Competences,
                ExistingImagePath = cV.ImagePath,
                Education = cV.Education,
                Name = cV.Name,
                Workplace = cV.Workplace,
                PhoneNumber = cV.PhoneNumber,
                PrivateProfile = cV.PrivateProfile,
            };
            if (cV == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: CVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(data.Shared.CvEditViewModel cV)
        {
            if (ModelState.IsValid)
            {

                cvRepo.editCv(cV);

                return RedirectToAction("Details/" + cV.Id);
            }
            return View(cV);
        }

        // GET: CVs/Delete/5
        [Authorize]
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
        [Authorize]
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
            if (User.Identity.IsAuthenticated)
            {
                //return View("Index", await db.cv.Where(j => j.Name.Contains
                //(SearchPhrase)).ToListAsync());
                return View("Index", cvRepo.GetAllCvs().Where(j => j.Name.Contains
                 (SearchPhrase)));
            }
            return View("Index", cvRepo.getAllNonPrivateCV().Where(j => j.Name.Contains
                 (SearchPhrase)));
        }

      
    }
}
