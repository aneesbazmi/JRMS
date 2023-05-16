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
using JRMS.UnitOfWork;

namespace JRMS.Controllers
{
    public class ApplicantsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicantsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        // GET: Applicants
        public  IActionResult Index()
        {
              return !_unitOfWork.applicantRepository.IsNull() ? 
                          View(_unitOfWork.applicantRepository.GetAll()) :
                          Problem("Entity set 'JMSDbContext.applicants'  is null.");
        }

        // GET: Applicants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _unitOfWork.applicantRepository.IsNull())
            {
                return NotFound();
            }

            var applicant  = _unitOfWork.applicantRepository.GetByID(id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // GET: Applicants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ApplicantDto _ApplicantDto)
        {
            if (ModelState.IsValid)
            {
                Applicant applicant = new Applicant();
                applicant.name = _ApplicantDto.name;
                applicant.Applicant_Gender = _ApplicantDto.Applicant_Gender;
                applicant.address = _ApplicantDto.address;
                applicant.Email_Address = _ApplicantDto.Email_Address;
                applicant.date_of_birth = _ApplicantDto.date_of_birth;
                applicant.Marks_In_Matriculation = _ApplicantDto.Marks_In_Matriculation;
                applicant.Marks_In_Intermediate = _ApplicantDto.Marks_In_Intermediate;
                applicant.Marks_In_Batchelor = _ApplicantDto.Marks_In_Batchelor;

                _unitOfWork.applicantRepository.Add(applicant);
                _unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(_ApplicantDto);
        }

        // GET: Applicants/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _unitOfWork.applicantRepository.IsNull())
            {
                return NotFound();
            }

            var applicant = _unitOfWork.applicantRepository.GetByID(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ApplicantDto _ApplicantDto)
        {
            if (id != _ApplicantDto.ApplicantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Applicant applicant = new Applicant();
                    applicant.ApplicantId = _ApplicantDto.ApplicantId;  
                    applicant.name = _ApplicantDto.name;
                    applicant.Applicant_Gender = _ApplicantDto.Applicant_Gender;
                    applicant.address = _ApplicantDto.address;
                    applicant.Email_Address = _ApplicantDto.Email_Address;
                    applicant.date_of_birth = _ApplicantDto.date_of_birth;
                    applicant.Marks_In_Matriculation = _ApplicantDto.Marks_In_Matriculation;
                    applicant.Marks_In_Intermediate = _ApplicantDto.Marks_In_Intermediate;
                    applicant.Marks_In_Batchelor = _ApplicantDto.Marks_In_Batchelor;
                    _unitOfWork.applicantRepository.Add(applicant);
                    _unitOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicantExists(_ApplicantDto.ApplicantId))
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
            return View(_ApplicantDto);
        }

        // GET: Applicants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _unitOfWork.applicantRepository.IsNull())
            {
                return NotFound();
            }

            var applicant = _unitOfWork.applicantRepository.GetByID(id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.applicantRepository.IsNull())
            {
                return Problem("Entity set 'JMSDbContext.applicants'  is null.");
            }
            var applicant = _unitOfWork.applicantRepository.GetByID(id);
            if (applicant != null)
            {
                _unitOfWork.applicantRepository.Delete(id);
            }
            
           _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicantExists(int id)
        {
            return _unitOfWork.applicantRepository.GetByID(id) ==  null ?  false : true;
        }
    }
}
