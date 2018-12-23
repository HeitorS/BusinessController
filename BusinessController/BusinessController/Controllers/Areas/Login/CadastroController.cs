using System.Collections.Generic;
using BusinessController.Models;
using BusinessController.DAO;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System;

namespace BusinessController.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            return View("~/Views/Login/Cadastro.cshtml");
        }

        public JsonResult Gravar(
            string firstName, 
            string lastName,
            string email,
            string nascimento,
            string mae,
            string cpf,
            string rg,
            string telefone,
            string celular )
        {
            try
            {
                PESSOA pessoa = new PESSOA();
                PESSOA findPessoa = new PESSOA();

                pessoa.NOME = firstName;
                pessoa.SOBRENOME = lastName;
                pessoa.EMAIL = email;
                pessoa.NASCIMENTO = GlobalHelper.Converter(pessoa.NASCIMENTO, nascimento);
                pessoa.MAE = mae;
                pessoa.CPF = cpf;
                pessoa.RG = rg;
                pessoa.TEL = telefone;
                pessoa.CEL = celular;

                using (DataContext context = new DataContext())
                {
                    findPessoa = context.Pessoas.Where(p => p.EMAIL == email).FirstOrDefault();
                    if(findPessoa != null)
                        return Json(new { type = "warning", message = "Esse e-mail já foi cadastrado!" }, JsonRequestBehavior.AllowGet);

                    findPessoa = context.Pessoas.Where(p => p.CPF == cpf).FirstOrDefault();
                    if (findPessoa != null)
                        return Json(new { type = "warning", message = "Esse CPF já foi cadastrado!" }, JsonRequestBehavior.AllowGet);

                    findPessoa = context.Pessoas.Where(p => p.RG == rg).FirstOrDefault();
                    if (findPessoa != null)
                        return Json(new { type = "warning", message = "Esse RG já foi cadastrado!" }, JsonRequestBehavior.AllowGet);

                    context.Pessoas.Add(pessoa);
                    context.SaveChanges();
                    return Json(new { type = "success", message = "Dados Gravados com Sucesso!"}, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception e)
            {
                return Json(new { type = "error", message = "O correu o seguinte erro: " + e.Message}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}