using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DDAC_Flight_System.Models;
using Microsoft.AspNetCore.Http;

namespace DDAC_Flight_System.Controllers
{
    public class ViewRecordController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private FlightDbContext _context;

        public ViewRecordController(FlightDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new ViewModel(_context, _session);
            return View("~/Views/Main/ViewRecord.cshtml", viewModel);
        }
    }
}