using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuniChorrillos2.Models;

namespace MuniChorrillos2.Controllers
{
    public class VehiMunicipalController : Controller
    {
        private Bdmultas2Context _context;

        public VehiMunicipalController(Bdmultas2Context context)
        {
            _context = context;
        }


        // GET: VehiMunicipalController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VehiMunicipalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehiMunicipalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehiMunicipalController/Create
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

        // GET: VehiMunicipalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehiMunicipalController/Edit/5
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

        // GET: VehiMunicipalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehiMunicipalController/Delete/5
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
