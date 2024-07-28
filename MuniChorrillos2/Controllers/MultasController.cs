using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using MuniChorrillos2.Models;
using System.Diagnostics;


namespace MuniChorrillos2.Controllers
{
    public class MultasController : Controller
    {

        private readonly Bdmultas2Context _context;

        public MultasController(Bdmultas2Context context)
        {
            _context = context;
        }



        // GET: MultasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MultasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MultasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MultasController/Create
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

        // GET: MultasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MultasController/Edit/5
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

        // GET: MultasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MultasController/Delete/5
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

        public ActionResult RedirectToExternal()
        {
            return RedirectToAction("Index", "Areas");
        }
    }
}
