using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Presentation.Client.Controllers
{
    public class LoginsController : Controller
    {
        // GET: Logins
        public ActionResult Index()
        {
            return View();
        }

        // GET: Logins/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Logins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logins/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Logins/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Logins/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Logins/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Logins/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}