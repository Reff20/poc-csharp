using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_Crud
{
    public class Connect_db
    {
        public string stringBuilder()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "192.168.0.1:3306";
                builder.UserID = "sa";
                builder.Password = "secret123";
                builder.InitialCatalog = "usuarios";

                return builder.ConnectionString;
            } 
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString());
                return ex.ToString();
            }
        }
    }
}
