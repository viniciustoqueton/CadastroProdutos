using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Infra;

namespace AutoGlass.produtosBLL
{
    public class produtosBLL : IDisposable
    {

        public List<TOProdutos> RetornaProdutos(TOProdutos produtos)
        {
            List<TOProdutos> Produto = new List<TOProdutos>();
            try
            {
                using (produtoDAO dao = new produtoDAO())
                {
                    Produto = dao.RetornaProdutoDAO(produtos);
                }
            }
            catch (Exception ex)
            {

            }
            return (Produto);
        }
        public void Dispose()
        {
            GC.Collect();
        }

        public TOProdutos SalvarProduto(TOProdutos produtos)
        {
            if (produtos.IDProduto.Equals(0))
            {
                produtos = InserirProduto(produtos);
            }
            else
            {
                produtos = AlterarProduto(produtos);
            }
            produtos.Filtro = 1;
            return produtos;
        }
        private TOProdutos InserirProduto(TOProdutos produtos)
        {
            try
            {
                using (produtoDAO dao = new produtoDAO())
                {
                    if (dao.InserirProduto(produtos))
                    {
                        produtos.Sucesso = true;
                        produtos.Mensagem = "Cadastrado com sucesso";
                    }
                    else
                    {
                        produtos.Sucesso = false;
                        produtos.Mensagem = "Erro ao Cadastrar";
                    }
                }
            }
            catch (Exception ex)
            {
                produtos.Sucesso = false;
                produtos.Mensagem = ex.Message;
            }

            return produtos;
        }
        private TOProdutos AlterarProduto(TOProdutos produtos)
        {
            try
            {
                using (produtoDAO dao = new produtoDAO())
                {
                    if (dao.AlterarProduto(produtos))
                    {
                        produtos.Sucesso = true;
                        produtos.Mensagem = "Alterado com sucesso";
                    }
                    else
                    {
                        produtos.Sucesso = false;
                        produtos.Mensagem = "Erro ao Alterar";

                    }
                }
            }
            catch (Exception ex)
            {
                produtos.Sucesso = false;
                produtos.Mensagem = ex.Message;

            }

            return produtos;
        }

        public TOProdutos ConsultarProduto(TOProdutos produtos)
        {
            TOProdutos produto = new TOProdutos();
            try
            {
                using (produtoDAO dao = new produtoDAO())
                {
                    produto = dao.ConsultarProduto(produtos);
                }

                if (produto == null)
                {
                    produto.Sucesso = false;
                    produto.Mensagem = "Erro ao Cadastrar";
                }
            }
            catch (Exception ex)
            {
                produto.Sucesso = false;
                produto.Mensagem = ex.Message;
            }

            return produto;
        }

        public TOProdutos RemoverProduto(TOProdutos produtos)
        {
            try
            {
                using (produtoDAO dao = new produtoDAO())
                {
                    if (dao.RemoverProduto(produtos))
                    {
                        produtos.Sucesso = true;
                        produtos.Mensagem = "Removido com sucesso";
                    }
                    else
                    {
                        produtos.Sucesso = false;
                        produtos.Mensagem = "Erro ao Remover";
                    }
                }
            }
            catch (Exception ex)
            {
                produtos.Sucesso = false;
                produtos.Mensagem = ex.Message;
            }


            return produtos;
        }



    }
}
