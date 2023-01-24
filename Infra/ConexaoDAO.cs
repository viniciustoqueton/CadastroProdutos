
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace AutoGlass.DAO
{
    public class ConexaoDAO
    {
        
        public void Conectar()
        {
            
            string connetionString;
            SqlConnection cnn;
            connetionString = @"data source=LAPTOP-L4A4RATG\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=AUTOGLASS";
            cnn = new SqlConnection(connetionString);
            
            cnn.Open();
            
        }


        public void desconectar()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"data source=LAPTOP-L4A4RATG\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=AUTOGLASS";
            cnn = new SqlConnection(connetionString);
            cnn.Close();
        }

    }
}
