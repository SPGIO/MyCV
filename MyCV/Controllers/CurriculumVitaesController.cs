using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCV.Data;
using MyCV.Models;

namespace MyCV.Controllers
{
    public class CurriculumVitaesController : Controller
    {
        private readonly MyCVContext _context;

        public CurriculumVitaesController(MyCVContext context)
        {
            _context = context;
        }

        // GET: CurriculumVitaes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CurriculumVitae.ToListAsync().ConfigureAwait(false));
        }

        // GET: CurriculumVitaes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curriculumVitae = await _context.CurriculumVitae
                .Include(cv           => cv.PersonalInformation)
                .Include(cv           => cv.PersonalInformation.ImageFile)
                .Include(cv           => cv.Experience)
                    .ThenInclude(exp  => exp.Category)
                .Include(cv           => cv.Skills)
                .FirstOrDefaultAsync(m   => m.Id == id)
                .ConfigureAwait(false);
            if (curriculumVitae == null)
            {
                return NotFound();
            }
            
            return View(curriculumVitae);
        }

        // GET: CurriculumVitaes/Create
        public IActionResult Create()
        {
            return View();
        }



        public async Task<ImageFile> GetUploadedImage(IFormFile image)
        {
            long twoMegaBytes = 2097152;
            if (image != null && image.Length > 0 && image.Length < twoMegaBytes)
            {
                using (var memorystream = new MemoryStream())
                {
                    await image.CopyToAsync(memorystream).ConfigureAwait(false);
                    var imagefile = new ImageFile()
                    {
                        Content = memorystream.ToArray()
                    };
                    return imagefile;
                }
            }
            throw new Exception();
        }


        // POST: CurriculumVitaes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CurriculumVitae curriculumVitae, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    curriculumVitae.PersonalInformation.ImageFile = await GetUploadedImage(image).ConfigureAwait(false);
                }
                catch (Exception)
                {

                }
                finally
                {
                    _context.Add(curriculumVitae);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                return RedirectToAction(nameof(Index));

            }
            return View(curriculumVitae);
        }


        // GET: CurriculumVitaes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var curriculumVitae = await _context.CurriculumVitae.FindAsync(id);
            var curriculumVitae = await _context.CurriculumVitae
                .Include(i=> i.PersonalInformation)
                .Include(i=> i.PersonalInformation.ImageFile)
                .FirstOrDefaultAsync(m => m.Id == id)
                .ConfigureAwait(false);
            if (curriculumVitae == null)
            {
                return NotFound();
            }
            return View(curriculumVitae);
        }

        // POST: CurriculumVitaes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CurriculumVitae curriculumVitae, IFormFile image)
        {
            if (curriculumVitae == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    try
                    {
                        ImageFile  imagefile = await GetUploadedImage(image).ConfigureAwait(false);
                        curriculumVitae.PersonalInformation.ImageFile.Content = imagefile.Content;
                    }
                    catch (Exception)
                    {
                    }
                    _context.Update(curriculumVitae);
                    await _context.SaveChangesAsync()
                        .ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurriculumVitaeExists(curriculumVitae.Id))
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
            return View(curriculumVitae);
        }

        // GET: CurriculumVitaes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curriculumVitae = await _context.CurriculumVitae
                .FirstOrDefaultAsync(m => m.Id == id)
                .ConfigureAwait(false);
            if (curriculumVitae == null)
            {
                return NotFound();
            }

            return View(curriculumVitae);
        }

        // POST: CurriculumVitaes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curriculumVitae = await _context.CurriculumVitae.FindAsync(id);
            _context.CurriculumVitae.Remove(curriculumVitae);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool CurriculumVitaeExists(int id)
        {
            return _context.CurriculumVitae.Any(e => e.Id == id);
        }
    }
}
