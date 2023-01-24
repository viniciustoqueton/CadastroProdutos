using AutoGlass.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AutoGlass.Controllers
{
    public class ProdutosController : Controller
    {
        ProdutosDbContext db;
        public ProdutosController()
        {
            db = new ProdutosDbContext();
        }
        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = db.Produtos.ToList();
            return View(produtos);
        }
    }
}
