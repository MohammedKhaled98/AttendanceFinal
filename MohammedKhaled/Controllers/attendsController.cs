#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MohammedKhaled.Data;
using MohammedKhaled.Models;

namespace MohammedKhaled.Controllers
{
    public class attendsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public attendsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: attends


        
             public async Task<IActionResult> Attendances(int? id)

        {
            var ss = await _context.attend
    .Where(e => e.EmpId==id)
    .ToListAsync();

            return View(ss);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.attend.ToListAsync());
        }

        // GET: attends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attend = await _context.attend
                .FirstOrDefaultAsync(m => m.AId == id);
            if (attend == null)
            {
                return NotFound();
            }

            return View(attend);
        }

        // GET: attends/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: attends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tnow,AId,EmpId,Name,CheckIn,CheckOut,InState,outState,InReason,OutReason")] attend attend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attend);
        }

        // GET: attends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attend = await _context.attend.FindAsync(id);
            if (attend == null)
            {
                return NotFound();
            }
            return View(attend);
        }

        // POST: attends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tnow,AId,EmpId,Name,CheckIn,CheckOut,InState,outState,InReason,OutReason")] attend attend)
        {
            if (id != attend.AId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!attendExists(attend.AId))
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
            return View(attend);
        }

        // GET: attends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attend = await _context.attend
                .FirstOrDefaultAsync(m => m.AId == id);
            if (attend == null)
            {
                return NotFound();
            }

            return View(attend);
        }

        public async Task<IActionResult> checkIn(int? id , attend att)
        {
            DateTime dt=DateTime.Now;   
            var employee = await _context.Employee.FindAsync(id);
           attend attend=new attend();
            attend.EmpId= employee.Id;  
            attend.InReason= att.InReason;
            if (attend.InReason == null) { attend.InReason = "N/A"; }
            attend.Name=employee.Name;
          
            attend.Tin=dt;
            attend.CheckIn = true;
            attend.InState = att.InState;
            attend.OutReason = "N/A";
            attend.outState = "Present";
            attend.WHours = 0;
            employee.State = 1;
            if((DateTime.Now >= DateTime.Parse("7:00:00.00")) && (DateTime.Now < DateTime.Parse("8:30:00.00")))
            {
                attend.InState = "On Time";
                attend.InReason = "N/A";
            }

            else if ((DateTime.Now > DateTime.Parse("8:30:00.00")) && (DateTime.Now < DateTime.Parse("12:00:00.00")))
            {
                attend.InState = "Late";
            }
            else
            {
                attend.InState = "Absent";
            }
                _context.Add(attend);
            await _context.SaveChangesAsync();

            var tempp = _context.attend.Where(j => j.Tin == dt).SingleOrDefault();

            int a = 123;
            employee.atID = tempp.AId;

            
            _context.Update(employee);
            await _context.SaveChangesAsync();
            return View("~/Views/Home/index.cshtml", employee);
        }





        public async Task<IActionResult> checkOut(int? id, attend att)
        {


      
           



            var employee = await _context.Employee.FindAsync(id);


            int idm = employee.atID;

            attend atten = _context.attend.Where(j => j.AId == idm).SingleOrDefault();

            int z = 1;
            
            atten.OutReason= att.InReason;

            z = 2;
            atten.Tout = DateTime.Now;
            atten.CheckOut = true;
            
            employee.State = 2;
            z = 2;

            if (DateTime.Now >= DateTime.Parse("15:00:00.00"))
            {
                atten.outState = "On Time";
                atten.OutReason = "N/A";

                z = 2;
            }

            else if (DateTime.Now < DateTime.Parse("15:00:00.00"))
            {
                atten.outState = "Early";
            }
            else
            {
                atten.outState = "Absent";
            }

            z = 2;
            _context.Update(atten);
            await _context.SaveChangesAsync();

            z = 2;

            _context.Update(employee);
            await _context.SaveChangesAsync();
            z = 2;
            return View("~/Views/Home/index.cshtml", employee);
        }















        // POST: attends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attend = await _context.attend.FindAsync(id);
            _context.attend.Remove(attend);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool attendExists(int id)
        {
            return _context.attend.Any(e => e.AId == id);
        }
    }
}
