using GestaoProdutos.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestaoProdutos.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            var produtos = BuscaProdutos();
            return View(produtos);
        }
        private List<Produto> BuscaProdutos()
        {
            System.Web.HttpCookie token = HttpContext.Request.Cookies.Get("TOKEN");

            var client = new RestClient("http://localhost:62981/Produto");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + token.Value);
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<List<Produto>>(response.Content);

                return result;

            }
            else { return null; }
        }
    }
}