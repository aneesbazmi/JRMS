using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JRMS.DAL;
using EntityFramework;
using JRMS.DTOs;
using JRMS.AbstractionLayer;
using JRMS.UnitOfWork;
using System.Runtime.Intrinsics.Arm;
using AutoMapper;
using JRMS.DTOs;
using EntityFramework;

namespace JRMS.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly JMSDbContext _dbContext;
        private readonly UnitOfWork.IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        //user/1/tweets

        //tweets/1/



        public DepartmentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

       // GET: Departments
        public IActionResult Index()
        {
            return _unitOfWork.DepartmentRepository.GetAll() != null ?
                        View(_unitOfWork.DepartmentRepository.GetAll()) :
                        Problem("Entity set 'JMSDbContext.departments'  is null.");
        }

        //GET: Departments/Details/5
        public IActionResult Details(int? id)
        {
           
           
            if (id == null)
            {
                return BadRequest();
            }


            var department = _unitOfWork.DepartmentRepository.GetByID(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        //GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Departments/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to.
        //For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

       [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentDTO dTO)
        {

            if (ModelState.IsValid)
            {
                Department dept = new Department();
                var d = _mapper.Map   <DepartmentDTO, Department>(dTO);


                //DepartmentDTO d  = new DepartmentDTO();
                //d.Dept_Name = department.Dept_Name;

                try
                {
                    _unitOfWork.DepartmentRepository.Add(d);
                    _unitOfWork.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateException ex)
                {
                    return Problem(ex.Message);

                }
                catch(Exception ex)
                {
                    return Problem("something went wrong in processing the Reqeust");
                }

                
            }
            return View(dTO);
        }

       // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var department =  _unitOfWork.DepartmentRepository.GetByID(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        //POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DepartmentDTO DeptdTO)
        {
            if (id != DeptdTO.Dept_id)
            {
                return BadRequest("ID does not match the object sent");
            }
            if (!DepartmentExists((DeptdTO.Dept_id)))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var d = _mapper.Map<DepartmentDTO, Department>(DeptdTO);

                    _unitOfWork.DepartmentRepository.Update(d);

                    _unitOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException dbconExce)
                {
                    return Problem(dbconExce.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(DeptdTO);
        }

        //GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }


            var department = _unitOfWork.DepartmentRepository.GetByID(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        //POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //    if (_unitOfWork.DepartmentRepositor)
            //    {
            //        return Problem("Entity set 'JMSDbContext.departments'  is null.");
            //    }
            try
            {
                var department = _unitOfWork.DepartmentRepository.GetByID(id);
                if (department != null)
                {
                    _unitOfWork.DepartmentRepository.Delete(department.Dept_Id);
                    _unitOfWork.SaveChanges();
                }


                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Problem(ex.Message);
            }
           
        }

        private bool DepartmentExists(int id)
        {
            return _unitOfWork.DepartmentRepository.GetByID(id) != null;

        }
    }
}
