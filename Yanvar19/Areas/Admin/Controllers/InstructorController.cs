using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yanvar19.Contexts;
using Yanvar19.Models;
using Yanvar19.ViewModel.InstructorVM;

namespace Yanvar19.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class InstructorController : Controller
    {
        Yanvar19DbContext _context;

        public InstructorController(Yanvar19DbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Instructors.Select(p => new InstructorListItemVM
            {
                Id = p.Id,
                Name = p.Name,
                Job=p.Job,
                Picture = p.Picture
            }).ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(InstructorCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            Instructors inst = new Instructors 
            { 
               Job=vm.Job,
               Picture=vm.Picture,
               Name =vm.Name,
            };

            await _context.Instructors.AddAsync(inst);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            if (id == null) return BadRequest();
            var data = await _context.Instructors.FindAsync(id);
            if (data == null) return RedirectToAction(nameof(Index));
            return View(new InstructorUPdateVM
            {
                Job = data.Job,
                Picture = data.Picture,
                Name = data.Name
               
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, InstructorUPdateVM vm)
        {
            if (id == null) return BadRequest();
            var data = await _context.Instructors.FindAsync(id);
            data.Name=vm.Name;
            data.Picture=vm.Picture;
            data.Job=vm.Job;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _context.Instructors.FindAsync(id);
            if (data == null) return RedirectToAction(nameof(Index));
            _context.Instructors.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
