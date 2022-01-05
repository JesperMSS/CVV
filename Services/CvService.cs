using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVSITEHT2021.Models;
using CVSITEHT2021.Repo;
using Shared;

namespace Services
{
    public class CvService
    {

        private readonly CVDatabase _context;

        private CVRepository CVRepository
        {
            get { return new CVRepository(_context ?? new CVDatabase()); }
        }
        private ImageService ImageService
        {
            get { return new ImageService(); }
        }


        public CvEditViewModel GetEditModel(int id)
        {
            var CV = CVRepository.getCv(id);
            return new CvEditViewModel
            {
                Id = CV.id,
                Name = CV.Name,
                PhoneNumber = CV.PhoneNumber,
                Mail = CV.Mail,
                Education = CV.Education,
                Workplace = CV.Workplace,
                Competences = CV.Competences,
                ExistingImagePath = CV.ImagePath

            };
        }

        public CvEditViewModel EditCv(CvEditViewModel model)
        {
            var cv = CVRepository.getCv(model.Id);
            if (cv == null) throw new ArgumentException("Cv fanns inte!");
            if (model.Image != null)
            {
                if (!string.IsNullOrEmpty(cv.ImagePath)) ImageService.RemoveImageFromDiskIfExists(cv.ImagePath); //gör lite cleanup
                cv.ImagePath = ImageService.SaveImageToDisk(model.Image);
                model.ExistingImagePath = cv.ImagePath; //den nya pathen vi nu fick assignar vi så vi kan visa den för användaren med hjälp av BookEditModel i Viewn.
            }

            cv.Name = model.Name;
            cv.PhoneNumber = model.PhoneNumber;
            cv.Education = model.Education;
            cv.Workplace = model.Workplace;
            cv.Competences = model.Competences;
            CVRepository.saveCv(cv);
            return model;
        }

        public CvEditViewModel CreateNewCv(CvEditViewModel model)
        {
            var newCw = new CV()
            {
                id = model.Id,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Mail = model.Mail,
                Education = model.Education,
                Workplace = model.Workplace,
                Competences = model.Competences,
            };
            if (model.Image != null)
            {
                newCw.ImagePath = ImageService.SaveImageToDisk(model.Image);
                model.ExistingImagePath = newCw.ImagePath;
            }
            CVRepository.saveCv(newCw);
            return model;
        }
    }
}