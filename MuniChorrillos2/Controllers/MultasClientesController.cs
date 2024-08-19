using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuniChorrillos2.Models;

namespace MuniChorrillos2.Controllers
{
    public class MultasClientesController : Controller
    {
        private readonly Bdmultas2Context _context;

        public MultasClientesController(Bdmultas2Context context)
        {
            _context = context;
        }
        // GET: MultasClientesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MultasClientesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MultasClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MultasClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MultasClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MultasClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MultasClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MultasClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
