using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFramework;
using JRMS.DAL;
using JRMS.DTOs;

namespace JRMS.Controllers
{
    public class Job_ApplicationController : Controller
    {
        private readonly UnitOfWork.IUnitOfWork _unitOfWork;

        public Job_ApplicationController(UnitOfWork.IUnitOfWork uow)
        {
            _unitOfWork = uow;
            
        }

        // GET: Job_Application
        public  IActionResult Index()
        {
            var _allApplications = _unitOfWork.JobApplicationRepository.GetAll();
            return View( _allApplications.ToList());
        }

       // GET: Job_Application/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _unitOfWork.JobApplicationRepository.IsNull())
            {
                return NotFound();
            }

            var job_Application = _unitOfWork.JobApplicationRepository.GetByID(id);
            if (job_Application == null)
            {
                return NotFound();
            }

            return View(job_Application);
        }

        // GET: Job_Application/Create
        public IActionResult Create()
        {
            ViewData["Applicant_Id"] = new SelectList(_unitOfWork.applicantRepository.GetAll(), "ApplicantId", "ApplicantId");
            return View();
        }

        // POST: Job_Application/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Job_ApplicationDTO Ja)
        {
            if (ModelState.IsValid)
            {
                Job_Application job_Application = new Job_Application();
                job_Application.Applicant_Id = Ja.Applicant_Id;
                job_Application.Job_Application_Date = Ja.Job_Application_Date;
                job_Application.Job_Id = Ja.Job_Id;
                job_Application.Payment_Method = Ja.Payment_Method; 
                job_Application.Payment_Amount = Ja.Payment_Amount;


                _unitOfWork.JobApplicationRepository.Add(job_Application);
                _unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
           // ViewData["Applicant_Id"] = new SelectList(_unitOfWork.applicantRepository.GetAll(), "ApplicantId", "Applicant_Gender", job_Application.Applicant_Id);
            return View(Ja);
        }

        // GET: Job_Application/Edit/5
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || j)
        //    {
        //        return NotFound();
        //    }

        //    var job_Application = _unitOfWork.JobApplicationRepository.GetByID(id);
        //    if (job_Application == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["Applicant_Id"] = new SelectList(_unitOfWork.applicantRepository.GetAll(), "ApplicantId", "ApplicantId", job_Application.Applicant_Id);
        //    return View(job_Application);
        //}

        // POST: Job_Application/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, Job_ApplicationDTO Ja)
        //{
        //    if (id != Ja.Application_Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            Job_Application job_Application = new Job_Application();
        //            job_Application.Applicant_Id = Ja.Applicant_Id;
        //            job_Application.Job_Application_Date = Ja.Job_Application_Date;
        //            job_Application.Job_Id = Ja.Job_Id;
        //            job_Application.Payment_Method = Ja.Payment_Method;
        //            job_Application.Payment_Amount = Ja.Payment_Amount;


        //            _unitOfWork.JobApplicationRepository.Add(job_Application);
        //            _unitOfWork.SaveChanges();

        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!Job_ApplicationExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Applicant_Id"] = new SelectList(_unitOfWork.applicantRepository.GetAll(), "ApplicantId", "ApplicantId", Ja.Applicant_Id);
        //    return View(Ja);
        //}

        // GET: Job_Application/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null ||_unitOfWork.JobApplicationRepository.IsNull())
        //    {
        //        return NotFound();
        //    }

        //    var job_Application = _unitOfWork.JobApplicationRepository.GetByID(id);
        //        .Include(j => j.Applicant)
        //        .FirstOrDefaultAsync(m => m.Application_Id == id);
        //    if (job_Application == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(job_Application);
        //}

        //// POST: Job_Application/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.job_application == null)
        //    {
        //        return Problem("Entity set 'JMSDbContext.job_application'  is null.");
        //    }
        //    var job_Application = await _context.job_application.FindAsync(id);
        //    if (job_Application != null)
        //    {
        //        _context.job_application.Remove(job_Application);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool Job_ApplicationExists(int id)
        {
            return !(_unitOfWork.JobApplicationRepository.GetByID(id) == null) ;
        }
    }
}
