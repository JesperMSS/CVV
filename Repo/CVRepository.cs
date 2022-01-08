using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CVSITEHT2021.Models;
using System.Data.Entity;
using CVSITEHT2021.Shared;

namespace CVSITEHT2021.Repo
{
    public class CVRepository
    {
        private readonly CVDatabase _context;

         
        public CVRepository (CVDatabase context)
        {
            _context = context;
        }
        public CVRepository cvRepo
        {
            get { return new CVRepository(_context ?? new CVDatabase()); }
        }
        private ImageService imageService
        {
            get { return new ImageService(); }
        }

        public CV createCv(CvEditViewModel model)
        {
            CV cV = new CV
            {
                Competences = model.Competences,
                Education = model.Education,
                Name = model.Name,
                PhoneNumber = "9000-9",
                Mail = model.Mail,
                Workplace = model.Workplace,
                PrivateProfile = false
            };

            if (model.Image != null)
            {
                cV.ImagePath = imageService.SaveImageToDisk(model.Image);
                model.ExistingImagePath = cV.ImagePath;
            }
            saveCv(cV);
            return cV;
        }
        public CV getCv(int Id) { 
            return _context.cv
                .Include(x => x.Projects)
                .FirstOrDefault(x => x.id == Id);
        }
        public bool DeleteCv(int id)
        {
            var cv = _context.cv.FirstOrDefault(x => x.id == id);
            if (cv == null) return false;
            _context.cv.Remove(cv);
            _context.SaveChanges();
            return true;
        }
        public CV getCvByUser(string user)
        {
            return _context.cv.Include(x => x.Projects).FirstOrDefault(x => x.Mail == user);
           
        }
        
        public int getIdByUser(string user)
        {
            var cV = _context.cv.Include(x => x.Projects).FirstOrDefault(x => x.Mail == user);

            return cV.id;
        }

         public List<CV> GetAllCvs()
        {
            return _context.cv
                .Include(x => x.Projects)
                .ToList();
        }

        public CV saveCv (CV cV)
        {
            if(cV.id != 0)
            {
                _context.Entry(cV).State = EntityState.Modified;
            }
            else
            {
                _context.cv.Add(cV);
            }
            _context.SaveChanges();
            return cV;
        }
        public List<CV> getAllNonPrivateCV()
        {
            List<CV> cVs = _context.cv.Where(x => x.PrivateProfile == false).ToList();
            return cVs;
        }
    }
}