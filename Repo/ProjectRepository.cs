using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CVSITEHT2021.Models;

namespace CVSITEHT2021.Repo
{
    public class ProjectRepository
    {
        private readonly CVDatabase _context;

        public ProjectRepository(CVDatabase context)
        {
            _context = context;
        }

        public Project GetProject(int id)
        {
            return _context.Projects.FirstOrDefault(x => x.ID == id);
        }

        public bool DeleteProject(int id)
        {
            var project = _context.Projects.FirstOrDefault(x => x.ID == id);
            if (project == null) return false;
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return true;
        }

        public List<Project> getAllProjects()
        {
            return _context.Projects.ToList();
        }


        public Project saveProject(Project project)
        {
            if (project.ID != 0)
            {
                _context.Entry(project).State = System.Data.Entity.EntityState.Modified;
            }else
            {
                _context.Projects.Add(project);
            }
            return project;
        }

    }
}
