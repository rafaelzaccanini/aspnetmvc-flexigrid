using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FlexgridComMVC.Helpers;
using FlexgridComMVC.Models;
using System.Linq.Dynamic;

namespace FlexgridComMVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CarregaFlexgrid()
        {
            int indicePaginaAtual = Convert.ToInt32(Request.Params["page"]);
            int itensPorPagina = Convert.ToInt32(Request.Params["rp"]);
            string campoOrdenacao = Request.Params["sortname"];
            string tipoOrdenacao = Request.Params["sortorder"];
            string textoBuscado = Request.Params["query"];
            string campoBuscado = Request.Params["qtype"];

            //IQueryable de Clientes
            var listaClientes = new Cliente().Seleciona();

            //Forma de implementação da busca
            //Func<Cliente, bool> whereClause = (i => (i.GetPropValue<string>(campoBuscado)).ToLower().Contains(textoBuscado.ToLower()));

            //Realiza a ordenação e paginação
            var listaPaginada = listaClientes.Where(String.Format("{0}.Contains(@0)", campoBuscado), textoBuscado)
                                             .OrderBy(campoOrdenacao + " " + tipoOrdenacao)
                                             .Skip((indicePaginaAtual - 1) * itensPorPagina)
                                             .Take(itensPorPagina);
            
            //Cria instância do Flexgrid informando o número da página atual e a quantidade de clientes existentes
            Flexigrid flexigrid = new Flexigrid { page = indicePaginaAtual, total = listaClientes.Count() };

            //Para cada cliente cria uma linha no grid
            foreach (var item in listaPaginada)
            {
                flexigrid.rows.Add(new FlexigridLinha
                {
                    //id da linha - opcional
                    id = item.CodCliente,
                    
                    //celulas da linha - cada string representa uma coluna em nosso grid 
                    //(deve estar na mesma ordem das colunas definidas em nosso script)
                    cell = new List<string>
                    { 
                        item.CodCliente.ToString(),
                        item.Nome,
                        item.Cpf,
                        item.Telefone,
                        item.Endereco
                    }
                });
            }

            return Json(flexigrid);
        }
    }
}
