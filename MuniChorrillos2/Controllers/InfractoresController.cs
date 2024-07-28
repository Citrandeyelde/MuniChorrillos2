using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuniChorrillos2.Models;

namespace MuniChorrillos2.Controllers
{
    public class InfractoresController : Controller
    {
        private readonly Bdmultas2Context _context;

        public InfractoresController(Bdmultas2Context context)
        {
            _context = context;  
        }


        // GET: InfractoresController
        public ActionResult Index()
        {
            return View();
        }

        // GET: InfractoresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InfractoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InfractoresController/Create
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

        // GET: InfractoresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InfractoresController/Edit/5
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

        // GET: InfractoresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InfractoresController/Delete/5
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
