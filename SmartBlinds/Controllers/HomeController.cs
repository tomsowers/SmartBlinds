using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartBlinds.Models;

namespace SmartBlinds.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Control()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("home/ChangeControl")]
        [HttpPut]
        public IActionResult ChangeControl(SerialCon serial)
        {
            
            serial.UpdateControlMode();
            return Content("Test");
        }

        [Route("home/sendCommand")]
        [HttpPut]
        public IActionResult sendCommand(SerialCon serial)
        {
            
            serial.SendCommand();

            return Content("Test");
        }

        [Route("home/getMode")]
        [HttpGet]
        public IActionResult getMode()
        {
            SerialCon serialCon = SQLConnection.GetLightMode();

            return Json(serialCon);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
