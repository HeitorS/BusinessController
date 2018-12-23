using System.Security.Cryptography;
using BusinessController.Models;
using BusinessController.DAO;
using System.Web.Mvc;
using System.Linq;
using System.Text;
using System;

namespace BusinessController.Controllers.Areas.Login
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //Variáveis globais
        private FindResource rs = new FindResource();

        /*******************************************************************************************************************************************
        * Função criada para controlar o login do usuário, tendo como parametro o e-mail do usuário e a senha.                                     *
        * Como a senha é salva com criptografia no banco de dados antes de fazer a comparação da senha informada com a senha cadastrada no banco   *
        * deverá fazer a criptografia da senha informada pelo usuário.                                                                             *
        * Caso seja o primeiro login do usuário no sistema ele deverá fazer a alteração da senha que foi criada como padrão.                       *
        *******************************************************************************************************************************************/

        public ActionResult Logar(string usuario, string senha)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    USUARIO user = new USUARIO();
                    user = context.Usuarios.Where(x => x.EMAIL == usuario && x.SENHA == senha && x.ATIVO == "S").FirstOrDefault();
                    if(user != null)
                    {
                        return Json(new { type = "information", message = rs.Find("msg_first_login") }, JsonRequestBehavior.AllowGet);
                    }

                    string novaSenha = CriptografiaMD5.MontaCriptografia(senha);
                    user = context.Usuarios.Where(x => x.EMAIL == usuario && x.SENHA == novaSenha && x.ATIVO == "S").FirstOrDefault();
                    if (user != null)
                    {
                        ViewBag.idUsuario = user.ID;
                        return RedirectToAction("Index", "Home");
                    }

                    return Json(new { type = "warning", message = rs.Find("msg_us_not_found") }, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception e)
            {
                return Json(new { type = "error", message = rs.Find("msg_error") + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        /*************************************************************************************************************************************************
        * Função responsável por trocar a senha do usuário. Quando for fazer a troca sempre devesse utilizar a criptografia MD5 para criptografar a      *
        * senha nova do usuário.                                                                                                                         *
        * Todas as senhas criadas devem seguir o padrão de segurança de dados, atendendo a seguintes regras de segurança:                                *
        *                                                                                                                                                *
        *     - Utilizar um caracte especial                                                                                                             *
        *     - Ter no mínimo 8 caracteres e no máximo 16                                                                                                *
        *     - Não conter parte do nome                                                                                                                 *
        *     - Não pode conter os seguintes caracteres                                                                                                  *
        *           - "@" (arroba).                                                                                                                      *
        *           - "." (ponto).                                                                                                                       *
        *           - "-" (hífen/traço).                                                                                                                 *
        *           - "_" (sublinhado).                                                                                                                  *
        *                                                                                                                                                *
        * Caso deixe de atender a qualquer um desses requisitos o usuário deverá receber uma mensagem com o motivo do erro ou não acatamentos das        *
        * regras implantadas.                                                                                                                            *
        *************************************************************************************************************************************************/
        public ActionResult TrocarSenha(string usuario, string senha, string confirmacao)
        {
            try
            {
                string newSenha = string.Empty;
                //Verifica se a primeira senha é igual a segunda senha digitada
                if(senha == confirmacao)
                    //Verifica se o usuário digitou uma senha com no mínimo 8 caracteres e no máximo 16
                    if (senha.Length >= 8 || senha.Length <= 16)
                        //Verifica se o usuário digitou pelo menos um número na senha
                        if (senha.Any(c => char.IsDigit(c)))
                            //Verifica se tem pelo menos uma letra maiúscula na seha
                            if (senha.Any(c => char.IsUpper(c)))
                                //Verifica se existe pelo menos um caracter minúsculo
                                if (senha.Any(c => char.IsLower(c)))
                                    //Verifica se a senha cótem pelo meno sum caracter especial
                                    if (senha.Any(c => char.IsSymbol(c)) || senha.Contains("#") || senha.Contains("!") || senha.Contains("$") || 
                                        senha.Contains("%") || senha.Contains("&") || senha.Contains("*") || senha.Contains("(") || senha.Contains(")"))
                                    {
                                        newSenha = CriptografiaMD5.MontaCriptografia(senha);
                                        using (DataContext context = new DataContext())
                                        {
                                            USUARIO user = context.Usuarios.First<USUARIO>(x => x.EMAIL == usuario && x.ATIVO == "S") ?? new USUARIO();
                                            if (user != new USUARIO())
                                            {
                                                user.SENHA = newSenha;
                                                context.SaveChanges();
                                                return Json(new { type = "success", message = rs.Find("msg_alt_senha") }, JsonRequestBehavior.AllowGet);
                                            }
                                            else
                                                return Json(new { type = "warning", message = rs.Find("msg_us_not_found") }, JsonRequestBehavior.AllowGet);
                                        }
                                    }
                                    else
                                        return Json(new { type = "warning", message = rs.Find("msg_senha_especial") }, JsonRequestBehavior.AllowGet);
                                else
                                    return Json(new { type = "warning", message = rs.Find("msg_senha_minusculo") }, JsonRequestBehavior.AllowGet);
                            else
                                return Json(new { type = "warning", message = rs.Find("msg_senha_maiusculo") }, JsonRequestBehavior.AllowGet);
                        else
                            return Json(new { type = "warning", message = rs.Find("msg_senha_numero") }, JsonRequestBehavior.AllowGet);
                    else
                        return Json(new { type = "warning", message = rs.Find("msg_senha_minMax") }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { type = "warning", message = rs.Find("msg_senha_diferente") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { type = "error", message = rs.Find("msg_error") + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}