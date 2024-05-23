﻿using ExamDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamDemo.Controllers
{
    public class KitapController : Controller
    {
        private MyDbContext _dbContext;

        public KitapController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public IActionResult Index()
        {
           List<Kitap> kitaplar= _dbContext.Kitaplar.ToList();
          
            return View(kitaplar);
        }
        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(KitapVM kitapVM)
        {
            //kitapVM olarak gelen modelin Validation kontrolunu yapiniz.


            if (ModelState.IsValid)
            {

                Kitap newKitap = new Kitap();
                newKitap.Id = kitapVM.Id;
                newKitap.KitapAdi = kitapVM.KitapAdi;
                newKitap.Yazar = kitapVM.Yazar;
                _dbContext.Kitaplar.Add(newKitap);
                _dbContext.SaveChanges();
                return  View("Index");
            }
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urun = await _dbContext.Kitaplar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        // POST: Urunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var urun = await _dbContext.Kitaplar.FindAsync(id);
            if (urun != null)
            {
                _dbContext.Kitaplar.Remove(urun);
            }

            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
