using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeAttendanceManager.Models;
using TimeAttendanceManager.Services;

namespace TimeAttendanceManager.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _service;

        public AttendanceController(IAttendanceService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _service.GetAll();
            return View(records);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AttendanceRecord record)
        {
            await _service.Create(record);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var record = await _service.GetById(id);
            return View(record);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, AttendanceRecord record)
        {
            await _service.Update(id, record);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var record = await _service.GetById(id);
            return View(record);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(string id)
        {
            var record = await _service.GetById(id);
            return View(record);
        }
    }
}
