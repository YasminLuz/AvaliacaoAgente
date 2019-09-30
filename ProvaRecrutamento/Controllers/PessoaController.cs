using ProvaRecrutamento.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaRecrutamento.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult CadastrarPessoa()
        {
            return View(ConnectDAO.AllPessoas());
        }

        public ActionResult CadastrarPessoa1()
        {
            return View();
        }

        public ActionResult EditarPessoa(int id)
        {
            return Json(ConnectDAO.PessoasById(id));
        }

        public ActionResult ExcluirPessoa()
        {
            return View();
        }
   
    }
}