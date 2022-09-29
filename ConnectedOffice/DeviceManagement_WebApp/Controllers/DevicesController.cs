using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IDeviceRepository _deviceRepository;

        public DevicesController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public IActionResult Index()
        {
            return View(_deviceRepository.GetAll());
        }

        // GET: Devices/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _deviceRepository.GetById(id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Device/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Devices/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _deviceRepository.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            _deviceRepository.Update(device);
            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var device = _deviceRepository.GetById(id);
            _deviceRepository.Remove(device);
            _deviceRepository.Update(device);
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(Guid id)
        {
            return _deviceRepository.DeviceEX(id);
        }
    }
}
