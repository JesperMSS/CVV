﻿using data.Models;
using data.Repo;
using System.Collections.Generic;
using System.Linq;
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
                var count = cv.Count();
                List<string> Name = new List<string>();
                List<int> cvID = new List<int>();
                for (int i = 0; i <= 5 && i < count; i++)
                {
                    CV cV = cv.First();
                    Name.Add(cV.Name);
                    cvID.Add(cV.id);
                    cv.Remove(cV);
                }

                ViewBag.cvID = cvID;
                ViewBag.Name = Name;
            }
            else
            {
                var notPrivateCV = cvRepo.getAllNonPrivateCV();
                List<string> npName = new List<string>();
                List<int> npcvID = new List<int>();
                var npcount = notPrivateCV.Count();
                for (int i = 0; i <= 5 && i < npcount; i++)
                {
                    CV cV = notPrivateCV.First();
                    npName.Add(cV.Name);
                    npcvID.Add(cV.id);
                    notPrivateCV.Remove(cV);
                }

                ViewBag.cvID = npcvID;
                ViewBag.Name = npName;

            }

            var projects = projRepo.getAllProjects();

            var projcount = projects.Count();
            List<string> projectTitle = new List<string>();
            List<int> projId = new List<int>();
            for (int i = 0; i <= 5 && i < projcount; i++)
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
    }
}