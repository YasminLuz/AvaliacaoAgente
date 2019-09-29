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

        public ActionResult ExibirPessoa()
        {
            return View();
        }

        public ActionResult EditarPessoa()
        {
            return View();
        }
    }
}