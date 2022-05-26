using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Enviando_Arquivos_Mvc.Models;
using System.IO;

namespace Enviando_Arquivos_Mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Remessa arq)
        {
            try
            {
                string nomeArquivo = "";
                string arquivosEnviados = "";
                foreach (var arquivo in arq.Arquivos)
                {
                    if (arquivo.ContentLength > 0)
                    {
                        nomeArquivo = Path.GetFileName(arquivo.FileName);
                        var caminho = Path.Combine(Server.MapPath("~/Documentos"), nomeArquivo);
                        arquivo.SaveAs(caminho);
                    }

                    arquivosEnviados = arquivosEnviados + " , " + nomeArquivo;
                }
                ViewBag.Mensagem = "Arquivo enviados: " + nomeArquivo + ", com comsucesso.";
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = "erro : " + ex.Message;
            }
            return View();
        }

    }
}