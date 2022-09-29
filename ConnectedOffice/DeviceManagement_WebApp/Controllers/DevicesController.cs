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
        public IActionResult Index()
        {
            DeviceRepository DeviceRepository = new DeviceRepository();

            var results = DeviceRepository.Getall();

            return View(results);
        }
    }
}
