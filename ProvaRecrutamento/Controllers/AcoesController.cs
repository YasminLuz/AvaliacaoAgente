using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvaRecrutamento.Models;

namespace ProvaRecrutamento.Controllers
{
    public class AcoesController : Controller
    {
        DB_RECRUTAMENTOEntities1 tb = new DB_RECRUTAMENTOEntities1();

        // GET: Acoes
        public ActionResult Index()
        {
            return View(tb.PessoaFisica.ToList());
        }

        // GET: Acoes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Acoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acoes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Acoes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Acoes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Acoes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Acoes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
