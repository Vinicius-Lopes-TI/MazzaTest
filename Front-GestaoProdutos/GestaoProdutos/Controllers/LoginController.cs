using RestSharp;
using System;
using System.Web.Mvc;
using Newtonsoft.Json;
using GestaoProdutos.Models;
using System.Web.Security;

namespace GestaoProdutos.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Autenticar(string usuario, string senha)
        {

            var client = new RestClient("http://localhost:62981/Auth/signin");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n    \"Email\": " + '"' + usuario + '"' + ",\r\n    \"senha\": " + '"' + senha + '"' + "\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<ResponseToken>(response.Content);

                System.Web.HttpCookie cookie = new System.Web.HttpCookie("TOKEN", result.accessToken);
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);

                var dataRetorno = new { sucesso = true };
                return Json(dataRetorno);

            }
            else
            {
                var dataRetorno = new { sucesso = false, msg = "Erro de autenticação." };
                return Json(dataRetorno);
            }
        }
    }
}