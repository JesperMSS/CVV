using CVSITEHT2021.Models;
using CVSITEHT2021.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CVSITEHT2021.Controllers
{
    public class HomeController : Controller
    {
        private readonly CVDatabase _context;
        public CVRepository cvRepo
        {
            get { return new CVRepository(_context ?? new CVDatabase()); }
        }

        public ProjectRepository projRepo
        {
            get { return new ProjectRepository(_context ?? new CVDatabase()); }
        }


        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var cv = cvRepo.GetAllCvs();
                List<string> Name = new List<string>();
                List<int> cvID = new List<int>();
                for (int i = 0; i <= 5 && i < cv.Count(); i++)
                {
                    CV cV = cv.First();
                    Name.Add(cV.Name);
                    cvID.Add(cV.id);
                    cv.Remove(cV);
                }
                ViewBag.cvID = cvID;
                ViewBag.Name = Name;
            }

            var projects = projRepo.getAllProjects();

            List<string> projectTitle = new List<string>();
            List<int> projId = new List<int>();
            for (int i = 0; i <= 5 && i < projects.Count(); i++)
            {
                Project project = projects.Last();
                projectTitle.Add(project.Title);
                projId.Add(project.ID);
                projects.Remove(project);
            }

            ViewBag.projectTitle = projectTitle;
            ViewBag.projID = projId;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}