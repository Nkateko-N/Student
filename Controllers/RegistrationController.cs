using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Student_Data.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly RegistrationDbContext _db;
        private readonly IWebHostEnvironment WebHostEnvironment;
        public RegistrationController(RegistrationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            WebHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
           
            var displaydata = _db.Student_Details.ToList();
            return View(displaydata);
        }

        public IActionResult ConvertFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConvertFile(Registration reg)
        {
            
            JObject obj = (JObject)JToken.FromObject(reg);
            CreateFile(obj);
            return View(reg);
        }

        private void CreateFile(JObject obj)
        {
            string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "json");
            var fileName = Guid.NewGuid().ToString() + ".json";
            string filePath = Path.Combine(uploadDir, fileName);
            System.IO.File.WriteAllText(filePath, obj.ToString());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Registration nec)
        {
            if (ModelState.IsValid)
            {
                _db.Add(nec);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
               
            }
            return View(nec);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getStudentdetails = await _db.Student_Details.FindAsync(id);
            return View(getStudentdetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Registration nc)
        {
            if (ModelState.IsValid)
            {
                _db.Update(nc);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nc);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getStudentdetails = await _db.Student_Details.FindAsync(id);
            return View(getStudentdetails);
        }
        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {

            var getStudentdetails = await _db.Student_Details.FindAsync(id);
            _db.Student_Details.Remove(getStudentdetails);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
