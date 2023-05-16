using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFramework;
using JRMS.DAL;
using Dept = JRMS.DTOs.Department;
using JRMS.AbstractionLayer;
using JRMS.UnitOfWork;
using System.Runtime.Intrinsics.Arm;

namespace JRMS.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly JMSDbContext _dbContext;
        private readonly UnitOfWork.IUnitOfWork _unitOfWork;

        public DepartmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            if (id == null || _unitOfWork.DepartmentRepository.GetAll() == null)
            {
                return NotFound();
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
        public async Task<IActionResult> Create(Dept department)
        {

            if (ModelState.IsValid)
            {
                Department d = new Department();
                d.Dept_Name = department.Dept_Name;
                _unitOfWork.DepartmentRepository.Add(d);
                _unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

       // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _unitOfWork.DepartmentRepository.GetAll() == null)
            {
                return NotFound();
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
        public async Task<IActionResult> Edit(int id, Dept department)
        {
            if (id != department.Dept_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    Department d = new Department {Dept_Id = department.Dept_id, Dept_Name = department.Dept_Name };

                    _unitOfWork.DepartmentRepository.Update(d);

                    _unitOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists((department.Dept_id)))
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
            return View(department);
        }

        //GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _unitOfWork.DepartmentRepository.IsNull())
            {
                return NotFound();
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
            if (_unitOfWork.DepartmentRepository.IsNull())
            {
                return Problem("Entity set 'JMSDbContext.departments'  is null.");
            }
            var department = _unitOfWork.DepartmentRepository.GetByID(id);
            if (department != null)
            {
                _unitOfWork.DepartmentRepository.Delete(department.Dept_Id);
            }

            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return _unitOfWork.DepartmentRepository.GetByID(id) != null;

        }
    }
}
