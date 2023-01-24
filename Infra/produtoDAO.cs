
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Entities;



namespace Infra
{
    public  class produtoDAO : IDisposable
    {
        public List<TOProdutos> RetornaProdutoDAO(TOProdutos produtos)
        {
            List<TOProdutos> lista = new List<TOProdutos>();

            string connetionString;
            SqlConnection cnn;
            connetionString = @"data source=LAPTOP-L4A4RATG\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=AUTOGLASS";
            cnn = new SqlConnection(connetionString);

            try
            {
           

                
                cnn.Open();

                SqlCommand command;
                SqlDataReader reader;
                string sql, Output = "";
                sql = "select  IdProduto,Descricao,CASE WHEN Situacao = 0 THEN 'Inativo' ELSE 'Ativo' END AS Situacao, Fabricacao,Validade,CodFornecedor,DescFornecedor,CNPJ from AUTOGLASS.dbo.Produtos where Situacao=" + produtos.Filtro ;
                command = new SqlCommand(sql, cnn);
                reader = command.ExecuteReader();

               

                //SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TOProdutos produto = new TOProdutos();

                    produto.IDProduto = DAOO.Util.ConverteValor.ConverterValorInteiro(reader["IdProduto"]);
                    produto.Descricao = DAOO.Util.ConverteValor.ConverterValorString(reader["Descricao"]);
                    produto.Situacao = DAOO.Util.ConverteValor.ConverterValorString(reader["Situacao"]);
                    produto.Fabricacao = DAOO.Util.ConverteValor.ConverterValorData(reader["Fabricacao"]);
                    produto.Validade = DAOO.Util.ConverteValor.ConverterValorData(reader["Validade"]);
                    produto.CodFornecedor = DAOO.Util.ConverteValor.ConverterValorInteiro(reader["CodFornecedor"]);
                    produto.DescFornecedor = DAOO.Util.ConverteValor.ConverterValorString(reader["DescFornecedor"]);
                    produto.CNPJ = DAOO.Util.ConverteValor.ConverterValorString(reader["CNPJ"]);
                    lista.Add(produto);
                }
               

            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Erro ao Listar dados: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar dados: " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }

            return lista;
        }
        public void Dispose()
        {
            GC.Collect();
        }

        public bool InserirProduto(TOProdutos produtos)
        {        

            try
            {
                string connetionString;
                SqlConnection cnn;
                connetionString = @"data source=LAPTOP-L4A4RATG\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=AUTOGLASS";
                cnn = new SqlConnection(connetionString);
                cnn.Open();

                SqlCommand command;
                SqlDataReader reader;
                string sql, Output = "";
                sql = "Insert Into AUTOGLASS.dbo.Produtos (Descricao,Situacao,Fabricacao,Validade,CodFornecedor,DescFornecedor,CNPJ) values " +
                    "('"+produtos.Descricao + "',1,'"+produtos.Fabricacao + "','"+produtos.Validade + "', '"+produtos.CodFornecedor + "'," +
                    " '"+produtos.DescFornecedor + "', '" + produtos.CNPJ +"')" ; 
                command = new SqlCommand(sql, cnn);
                reader = command.ExecuteReader();

                cnn.Close();
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Erro ao incluir dados: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar dados: " + ex.Message);
            }
            finally
            {
               
            }

            return true;
        }

        public bool AlterarProduto(TOProdutos produtos)
        {
            
            string connetionString;
            SqlConnection cnn;
            connetionString = @"data source=LAPTOP-L4A4RATG\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=AUTOGLASS";
            cnn = new SqlConnection(connetionString);
           

            try
            {
             
                cnn.Open();

                SqlCommand command;
                SqlDataReader reader;
                string sql, Output = "";
                sql = "Update AUTOGLASS.dbo.Produtos Set Descricao= '" + produtos.Descricao +"'" +
                    ",Fabricacao = '" + produtos.Fabricacao +"',Validade='" + produtos.Validade +"'," +
                    "CodFornecedor = " + produtos.CodFornecedor +",DescFornecedor= '" + produtos.DescFornecedor +"',CNPJ = '" + produtos.CNPJ +"' where IdProduto=" + produtos.IDProduto ;
                command = new SqlCommand(sql, cnn);
                reader = command.ExecuteReader();

                


            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Erro ao incluir dados: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar dados: " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }

            return true;
        }



        public TOProdutos ConsultarProduto(TOProdutos produtos)
        {
            TOProdutos ConsultaPatrimonio = new TOProdutos();

            string connetionString;
            SqlConnection cnn;
            connetionString = @"data source=LAPTOP-L4A4RATG\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=AUTOGLASS";
            cnn = new SqlConnection(connetionString);

            try
            {
                cnn.Open();

                SqlCommand command;
                SqlDataReader reader;
                string sql, Output = "";
                sql = "select  IdProduto,Descricao,CASE WHEN Situacao = 0 THEN 'Inativo' ELSE 'Ativo' END AS Situacao, Fabricacao,Validade,CodFornecedor,DescFornecedor,CNPJ from AUTOGLASS.dbo.Produtos where" + produtos.IDProduto ;
                command = new SqlCommand(sql, cnn);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TOProdutos produto = new TOProdutos();

                    produto.IDProduto = DAOO.Util.ConverteValor.ConverterValorInteiro(reader["IdProduto"]);
                    produto.Descricao = DAOO.Util.ConverteValor.ConverterValorString(reader["Descricao"]);
                    produto.Situacao = DAOO.Util.ConverteValor.ConverterValorString(reader["Situacao"]);
                    produto.Fabricacao = DAOO.Util.ConverteValor.ConverterValorData(reader["Fabricacao"]);
                    produto.Validade = DAOO.Util.ConverteValor.ConverterValorData(reader["Validade"]);
                    produto.CodFornecedor = DAOO.Util.ConverteValor.ConverterValorInteiro(reader["CodFornecedor"]);
                    produto.DescFornecedor = DAOO.Util.ConverteValor.ConverterValorString(reader["DescFornecedor"]);
                    produto.CNPJ = DAOO.Util.ConverteValor.ConverterValorString(reader["CNPJ"]);
             

                    ConsultaPatrimonio = produto;
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Erro ao Listar dados: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar dados: " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }


            return ConsultaPatrimonio;
        }

        public bool RemoverProduto(TOProdutos produtos)
        {

            try
            {
                string connetionString;
                SqlConnection cnn;
                connetionString = @"data source=LAPTOP-L4A4RATG\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=AUTOGLASS";
                cnn = new SqlConnection(connetionString);
                cnn.Open();

                SqlCommand command;
                SqlDataReader reader;
                string sql, Output = "";
                sql = "Update AUTOGLASS.dbo.Produtos Set Situacao="+ produtos.Filtro + " where IdProduto=" + produtos.IDProduto;

                command = new SqlCommand(sql, cnn);
                reader = command.ExecuteReader();

                cnn.Close();
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Erro ao incluir dados: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar dados: " + ex.Message);
            }
            finally
            {

            }

            return true;
        }
    }
}
