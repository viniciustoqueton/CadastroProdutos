
using AutoGlass.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using Entities;


namespace AutoGlass.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(TOProdutos produto)
        {
            ProdutosViewModel viewModel = new ProdutosViewModel();
            viewModel.Produtos = new TOProdutos();
            produto.Filtro = 1;

            using (produtosBLL.produtosBLL bll = new produtosBLL.produtosBLL())
            {
                viewModel.ListaProdutos = bll.RetornaProdutos(produto);
            }

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult CadastroProduto(TOProdutos produto)
        {
            int IDProduto = produto.IDProduto;

            TOProdutos to = new TOProdutos();

            if (IDProduto > 0)
            {
                using (produtosBLL.produtosBLL bll = new produtosBLL.produtosBLL())
                {
                    to = bll.ConsultarProduto(produto);
                }
            }

            return View(to);
        }

        public ActionResult RemoverProduto(TOProdutos produtos)
        {
            {
                int IdProduto = produtos.IDProduto;

                ProdutosViewModel retornoConsulta = new ProdutosViewModel();

                if (IdProduto > 0)
                {
                    produtos.Filtro = 0;
                    using (produtosBLL.produtosBLL bll = new produtosBLL.produtosBLL())
                    {
                        //Faz a consulta do produto selecionado. 
                        produtos.Filtro = 0;
                        produtos = bll.RemoverProduto(produtos);
                        if (produtos.Sucesso)
                            produtos.IDProduto = 0;
                        produtos.Filtro = 1;
                        retornoConsulta.ListaProdutos = bll.RetornaProdutos(produtos);
                    }
                }



                if (produtos.Sucesso)
                    return View("Index", retornoConsulta);
                else
                    return View("Index", retornoConsulta);
            }
        }


        public ActionResult SalvarProduto(TOProdutos produtos)
        {


            ProdutosViewModel prod = new ProdutosViewModel();

            using (produtosBLL.produtosBLL bll = new produtosBLL.produtosBLL())
            {

                produtos = bll.SalvarProduto(produtos);

                prod.Produtos = produtos;

                if (produtos.Sucesso)

                    prod.ListaProdutos = bll.RetornaProdutos(produtos);
            }

            if (produtos.Sucesso)
                return View("Index", prod);
            else
                return View("CadastroProduto", produtos);
        }

        public IActionResult RecuperarProduto(TOProdutos produto)
        {
            ProdutosViewModel viewModel = new ProdutosViewModel();
            viewModel.Produtos = new TOProdutos();
            produto.Filtro = 0;

            using (produtosBLL.produtosBLL bll = new produtosBLL.produtosBLL())
            {
                viewModel.ListaProdutos = bll.RetornaProdutos(produto);
            }

            return View(viewModel);
        }
       
        public ActionResult AtivaProduto(TOProdutos produtos)
        {
            int IdProduto = produtos.IDProduto;

            ProdutosViewModel retornoConsulta = new ProdutosViewModel();

            if (IdProduto > 0)
            {
                produtos.Filtro = 0;
                using (produtosBLL.produtosBLL bll = new produtosBLL.produtosBLL())
                {
                    //Faz a consulta do produto selecionado. 
                    produtos.Filtro = 1;
                    produtos = bll.RemoverProduto(produtos);
                    if (produtos.Sucesso)
                        produtos.IDProduto = 0;
                    produtos.Filtro = 1;
                    retornoConsulta.ListaProdutos = bll.RetornaProdutos(produtos);             
                }
            }

           

            if (produtos.Sucesso)
                return View("Index", retornoConsulta);
            else
                return View("Index", retornoConsulta);
        }

    }
}
