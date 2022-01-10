using data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace data.Repo
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
            return _context.Projects.Include(x => x.CVs)
                .FirstOrDefault(x => x.ID == id);
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

        public void addProjectToCV(string user, int Projid)
        {
            var proj = GetProject(Projid);
            proj.CVs.Add(_context.cv.FirstOrDefault(x => x.Mail == user));
            saveProject(proj);
            _context.SaveChanges();

        }

        public void leaveProject(string user, int Projid)
        {
            var proj = GetProject(Projid);
            proj.CVs.Remove(_context.cv.FirstOrDefault(x => x.Mail == user));
            _context.SaveChanges();
        }

        public Project saveProject(Project project)
        {
            if (project.ID != 0)
            {
                _context.Entry(project).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                _context.Projects.Add(project);
            }
            return project;
        }

    }
}
