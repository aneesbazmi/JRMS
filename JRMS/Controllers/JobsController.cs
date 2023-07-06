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
using System.Linq.Expressions;
using System.Data.Common;

namespace JRMS.Controllers
{
    public class JobsController : Controller
    {
        private readonly UnitOfWork.IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public JobsController(UnitOfWork.IUnitOfWork uow, IMapper mapper)
        {
            _UnitOfWork = uow;
            _mapper = mapper;
        }

        // GET: Jobs
        public  IActionResult Index()
        {
            var Jobs = _UnitOfWork.JobRepository.GetAllJobs();
            return View(Jobs);
        }

        // GET: Jobs/Details/5
        public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {

                var JobByDepartment = _UnitOfWork.JobRepository.BringJobDepartment(id);
                if (JobByDepartment == null)
                {
                    return NotFound();
                }

                return View(JobByDepartment);

            }
            catch(DbException ex)
            {
                return Problem(ex.Message); 
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
           
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            ViewData["Job_Dept_Id"] = new SelectList(_UnitOfWork.DepartmentRepository.GetAll(), "Dept_Id", "Dept_Id");
            
            return View();
        }

        //POST: Jobs/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to.
        //For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

       [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobDto _jobDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Job job = new Job();
                    var jb = _mapper.Map<Job>(_jobDto);
                    _UnitOfWork.JobRepository.Add(jb);
                    _UnitOfWork.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

                
            }

            catch(DbUpdateConcurrencyException ex)
            {
                return Problem(ex.Message);    
            }
            
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
            ViewData["Job_Dept_Id"] = new SelectList(_UnitOfWork.JobRepository.GetAllJobs(), "Dept_Id", "Dept_Id", _jobDto.Job_Dept_Id);
            return View(_jobDto);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _UnitOfWork.JobRepository.IsNull())
            {
                return NotFound();
            }

            var job = _UnitOfWork.JobRepository.BringJobDepartment(id);
            if (job == null)
            {
                return NotFound();
            }
            var data = _UnitOfWork.DepartmentRepository.GetAll();
            ViewData["Job_Dept_Id"] = new SelectList(_UnitOfWork.DepartmentRepository.GetAll(), "Dept_Id", "Dept_Id", job.Job_Dept_Id);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JobDto _jobDto)
        {
            if (id != _jobDto.Job_Id)
            {
                return NotFound();
            }

            Job job = new Job();
            job.Job_Title = _jobDto.Job_Title;
            job.Job_Id = _jobDto.Job_Id;
            job.Job_Result_Declaration_Date = _jobDto.Job_Result_Declaration_Date;
            job.Job_Last_Date_Apply = _jobDto.Job_Last_Date_Apply;
            job.Is_Contract_Based = _jobDto.Is_Contract_Based;
            job.Total_Women_Seats = _jobDto.Total_Women_Seats;
            job.Job_Scale = _jobDto.Job_Scale;
            job.Job_Dept_Id = _jobDto.Job_Dept_Id;
            job.Total_Open_Merit_Seats = _jobDto.Total_Open_Merit_Seats;
            job.Job_Total_Seats = _jobDto.Job_Total_Seats;
            job.Job_Posting_City_Name = _jobDto.Job_Posting_City_Name;
            job.Job_Dept_Id = _jobDto.Job_Dept_Id;
            _UnitOfWork.JobRepository.Add(job);

            if (ModelState.IsValid)
            {
                try
                {
                    _UnitOfWork.JobRepository.Update(job);
                    _UnitOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.Job_Id))
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
            ViewData["Job_Dept_Id"] = new SelectList(_UnitOfWork.JobRepository.GetAll(), "Dept_Id", "Dept_Id", job.Job_Dept_Id);
            return View(_jobDto);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null ||  _UnitOfWork.JobRepository.IsNull())
            {
                return NotFound();
            }

            var job = _UnitOfWork.JobRepository.GetByID(id);
                
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_UnitOfWork.JobRepository.IsNull())
            {
                return Problem("Entity set 'JMSDbContext.jobs'  is null.");
            }
            var job = _UnitOfWork.JobRepository.GetByID(id);
            if (job != null)
            {
                _UnitOfWork.JobRepository.Delete(id);
            }

            _UnitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(int id)
        {
            return (_UnitOfWork.JobRepository.GetByID(id) != null);
        }
    }
}
