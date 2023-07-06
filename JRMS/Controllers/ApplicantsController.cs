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
using AutoMapper;
using System.Data.Common;
using System.Linq.Expressions;

namespace JRMS.Controllers
{
    public class ApplicantsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApplicantsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper= mapper;
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
            if (id == null)
            {
                return BadRequest();
            }

            var applicant  =  _unitOfWork.applicantRepository.GetByID(id);
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
                var app = _mapper.Map<Applicant>(_ApplicantDto);
                    
                _unitOfWork.applicantRepository.Add(applicant);
                _unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(_ApplicantDto);
        }

        // GET: Applicants/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var applicant = _unitOfWork.applicantRepository.GetByID(id);
                if (applicant == null)
                {
                    return NotFound();
                }
                return View(applicant);
            }
            catch (DbException DbExcep) { return Problem(DbExcep.Message); }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
            
            
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
                return BadRequest("ID does not match with the ID provided the DTO");
            }

            if (!ApplicantExists(_ApplicantDto.ApplicantId))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Applicant applicant = new Applicant();
                    var app = _mapper.Map<Applicant>(_ApplicantDto);
                    _unitOfWork.applicantRepository.Add(applicant);
                    _unitOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return Problem(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(_ApplicantDto);
        }

        // GET: Applicants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
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
            //if (_unitOfWork.applicantRepository.IsNull())
            //{
            //    return Problem("Entity set 'JMSDbContext.applicants'  is null.");
            //}

            try
            {
                var applicant = _unitOfWork.applicantRepository.GetByID(id);
                if (applicant != null)
                {
                    _unitOfWork.applicantRepository.Delete(id);
                    _unitOfWork.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
                
            }
            
            catch(DbUpdateConcurrencyException _dbupdateConcurrencyException)
            {
                return Problem(_dbupdateConcurrencyException.Message);
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

        private bool ApplicantExists(int id)
        {
            return _unitOfWork.applicantRepository.GetByID(id) ==  null ?  false : true;
        }
    }
}
