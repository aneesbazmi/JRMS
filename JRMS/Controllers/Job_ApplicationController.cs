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
using AutoMapper;
using System.Data.Common;
using Azure.Core;

namespace JRMS.Controllers
{
    public class Job_ApplicationController : Controller
    {
        private readonly UnitOfWork.IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Job_ApplicationController(UnitOfWork.IUnitOfWork uow, IMapper mapper)
        {
      
            _unitOfWork = uow;
            _mapper = mapper;
            
        }

        // GET: Job_Application
        public  IActionResult Index()
        {

            try
            {
                var _allApplications = _unitOfWork.JobApplicationRepository.GetAll();
                if(_allApplications== null)
                {
                    return Problem("No Job available in the system");
                }
                return View(_allApplications.ToList());
            }
            catch(DbUpdateConcurrencyException  ex)
            {

                return Problem(ex.Message);
            }
            
        }

       // GET: Job_Application/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var job_Application = _unitOfWork.JobApplicationRepository.GetByID(id);
                if (job_Application == null)
                {
                    return NotFound();
                }
                return View(job_Application);
            }
            catch (DbException _dbex)
            {
                return Problem(_dbex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }




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
            try
            {
                if (ModelState.IsValid)
                {
                    Job_Application job_Application = new Job_Application();
                    var d = _mapper.Map<Job_Application>(Ja);

                    _unitOfWork.JobApplicationRepository.Add(d);
                    _unitOfWork.SaveChanges();
                    
                }
                return RedirectToAction(nameof(Index));
            }
            catch (DbException _dbex)
            {
                return Problem(_dbex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            ViewData["Applicant_Id"] = new SelectList(_unitOfWork.applicantRepository.GetAll(), "ApplicantId", "Applicant_Gender", Ja.Applicant_Id);
            return View(Ja);
        }

        // GET: Job_Application/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var job_Application = _unitOfWork.JobApplicationRepository.GetByID(id);
                if (job_Application == null)
                {
                    return NotFound();
                }

                ViewData["Applicant_Id"] = new SelectList(_unitOfWork.applicantRepository.GetAll(), "ApplicantId", "ApplicantId", job_Application.Applicant_Id);
                return View(job_Application);


            }
            catch (DbException _dbex)
            {
                return Problem(_dbex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // POST: Job_Application/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Job_ApplicationDTO Ja)
        {
            if (id != Ja.Application_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Job_Application job_Application = new Job_Application();
                    var d = _mapper.Map<Job_Application>(Ja);


                    _unitOfWork.JobApplicationRepository.Add(d);
                    _unitOfWork.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Job_ApplicationExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Applicant_Id"] = new SelectList(_unitOfWork.applicantRepository.GetAll(), "ApplicantId", "ApplicantId", Ja.Applicant_Id);
            return View(Ja);
        }

        // GET: Job_Application/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }


            try
            {

                var job_Application = _unitOfWork.JobApplicationRepository.GetByID(id);

                if (job_Application == null)
                {
                    return NotFound();
                }
                return View(job_Application);


            }
            catch(DbException ex)
            {
                return Problem(ex.Message);
            }

            catch(Exception ex)
            {
                return Problem(ex.Message);
            }

            
        }

        // POST: Job_Application/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var job_Application = _unitOfWork.JobApplicationRepository.GetByID(id);
                if (job_Application != null)
                {
                    _unitOfWork.applicantRepository.Delete(id);
                    _unitOfWork.SaveChanges();
                }

                return RedirectToAction(nameof(Index));

            }
            catch(DbException ex)
            {
                return Problem(ex.Message);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
           
        }

        private bool Job_ApplicationExists(int id)
        {
            return !(_unitOfWork.JobApplicationRepository.GetByID(id) == null) ;
        }
    }
}
