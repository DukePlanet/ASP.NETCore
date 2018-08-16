using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLibrary.Models;
using AutoMapper;
using BusinessLibrary.DTO;
using Rotativa.AspNetCore;  
  

namespace CourseEnrollToStudent.Controllers
{
    public class EnrollsController : Controller
    {
        private readonly EnrollContext _context;
       

        public EnrollsController(EnrollContext context)
        {
            _context = context;
           
        }

        // GET: Enrolls
        public async Task<IActionResult> Index()
        {
            List<EnrollDto> enroll = new List<EnrollDto>();
            enroll = await (from a in _context.Enroll
                            join b in _context.Department on
                            a.DeptId equals b.Id
                            join c in _context.Course on
                             a.CourseId equals c.Id
                            join d in _context.Student on
                            a.StudentId equals d.Id
                            select new EnrollDto
                            {
                                DeptCode = b.DeptCode,
                                CourseCode = c.CourseCode,
                                FullName = d.FullName,
                                Id = a.Id,
                                StatusText = (a.Status==1) ? "Active" :"Inactive"
                            }).ToListAsync();



            return View(enroll);
        }


        public JsonResult GetStudentsByDept(int deptId)
        {
            List<Student> student = new List<Student>();
            student = _context.Student.Where(x => x.DeptId == deptId).ToList();
            student.Insert(0, new Student { Id = 0, FullName = "Select One" });
            return Json(new SelectList(student, "Id", "FullName"));
        }

        public JsonResult GetCoursesByDept(int deptId)
        {
            List<Course> course = new List<Course>();
            course = _context.Course.Where(x => x.DeptId == deptId).ToList();
            course.Insert(0, new Course { Id = 0, CourseCode = "Select One" });
            return Json(new SelectList(course, "Id", "CourseCode"));
        }

        // GET: Enrolls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var enroll = await _context.Enroll
            //    .SingleOrDefaultAsync(m => m.Id == id);

            EnrollDto enroll = new EnrollDto();
            enroll = await (from a in _context.Enroll.Where(x=>x.Id==id)
                            join b in _context.Department on
                            a.DeptId equals b.Id
                            join c in _context.Course on
                             a.CourseId equals c.Id
                            join d in _context.Student on
                            a.StudentId equals d.Id
                            select new EnrollDto
                            {
                                DeptCode = b.DeptCode,
                                CourseCode = c.CourseCode,
                                FullName = d.FullName,
                                Id = a.Id,
                                StatusText = (a.Status == 1) ? "Active" : "Inactive"
                            }).SingleOrDefaultAsync();


            if (enroll == null)
            {
                return NotFound();
            }

             return View(enroll);
        }

        // GET: Enrolls/Create
        public IActionResult Create()
        {
            List<Department> dept = new List<Department>();
            List<Student> std = new List<Student>();
            List<Course> course = new List<Course>();

            dept = (from items in _context.Department select items).ToList();
            dept.Insert(0, new Department { Id = 0, DeptCode = "Select One" });
            std.Insert(0, new Student { Id = 0, FullName = "Not Available" });
            course.Insert(0, new Course { Id = 0, CourseCode = "Not Available" });


            ViewBag.Dept = dept;
            ViewBag.Std = std;
            ViewBag.Course = course;

            return View();
        }

        // POST: Enrolls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeptId,CourseId,StudentId,Status")] Enroll enroll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enroll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enroll);
        }


        public async Task<IActionResult> DemoViewAsPDF(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var enroll = await _context.Enroll
            //    .SingleOrDefaultAsync(m => m.Id == id);

            EnrollDto enroll = new EnrollDto();
            enroll = await(from a in _context.Enroll.Where(x => x.Id == id)
                           join b in _context.Department on
                           a.DeptId equals b.Id
                           join c in _context.Course on
                            a.CourseId equals c.Id
                           join d in _context.Student on
                           a.StudentId equals d.Id
                           select new EnrollDto
                           {
                               DeptCode = b.DeptCode,
                               CourseCode = c.CourseCode,
                               FullName = d.FullName,
                               Id = a.Id,
                               StatusText = (a.Status == 1) ? "Active" : "Inactive"
                           }).SingleOrDefaultAsync();


            if (enroll == null)
            {
                return NotFound();
            }

            return new ViewAsPdf("Details", enroll)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Tabloid,
                CustomSwitches = "--print-media-type --header-center \"Student Report\""
            };
        }
      

    // GET: Enrolls/Edit/5
    public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enroll = await _context.Enroll.SingleOrDefaultAsync(m => m.Id == id);
            if (enroll == null)
            {
                return NotFound();
            }

            
            ViewData["DeptId"] = new SelectList(_context.Department, "Id", "DeptCode", enroll.DeptId);
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "CourseCode", enroll.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FullName", enroll.StudentId);

            return View(enroll);
        }

        // POST: Enrolls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeptId,CourseId,StudentId,Status")] Enroll enroll)
        {
            if (id != enroll.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enroll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollExists(enroll.Id))
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
            return View(enroll);
        }

        // GET: Enrolls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enroll = await _context.Enroll
                .SingleOrDefaultAsync(m => m.Id == id);
            if (enroll == null)
            {
                return NotFound();
            }

            return View(enroll);
        }

        // POST: Enrolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enroll = await _context.Enroll.SingleOrDefaultAsync(m => m.Id == id);
            _context.Enroll.Remove(enroll);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollExists(int id)
        {
            return _context.Enroll.Any(e => e.Id == id);
        }
    }
}
