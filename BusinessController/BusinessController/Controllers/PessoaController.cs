using System.Collections.Generic;
using BusinessController.Models;
using BusinessController.DAO;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System;

namespace BusinessController.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Gravar(string nome, string email)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    PESSOA pessoa = new PESSOA();
                    if(email != "")
                    {
                        var a = context.Usuarios.Where<USUARIO>(x => x.EMAIL == email);
                    }

                    //context.SaveChanges();
                }
                return Json(new { type = "success", message = "Dados Gravados com Sucesso!"}, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { type = "error", message = "O correu o seguinte erro: " + e.Message}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}