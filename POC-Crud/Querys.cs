using POC_Crud.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_Crud
{
    public class Querys
    {
        public UserModel getUserById(int userId)
        {
            Connect_db connect_db = new Connect_db();
            using (SqlConnection con = new SqlConnection(connect_db.stringBuilder()))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand()) 
                { 
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT * FROM tb_usuarios WHERE user_id = " + userId;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var userFinal = new UserModel();

                        userFinal.user_name = reader.GetString(1);
                        userFinal.user_password = reader.GetString(2);
                        userFinal.user_email = reader.GetString(3);
                        userFinal.user_phone = reader.GetString(4);
                        userFinal.user_first_name = reader.GetString(5);
                        userFinal.user_last_name = reader.GetString(6);

                        con.Close();
                        return userFinal;
                    }
                }
            }
        }

        public string createUser(UserModel usuario)
        {
            try
            {
                Connect_db connect_db = new Connect_db();
                using (SqlConnection con = new SqlConnection(connect_db.stringBuilder()))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "INSER INTO tb_user " +
                            "(user_name, user_password, user_email, user_phone, user_first_name, user_last_name)" +
                            "VALUES (@1, @2, @3, @4, @5, @6)";
                        cmd.Parameters.Add(new SqlParameter("@1",usuario.user_name));
                        cmd.Parameters.Add(new SqlParameter("@2", usuario.user_password));
                        cmd.Parameters.Add(new SqlParameter("@3", usuario.user_email));
                        cmd.Parameters.Add(new SqlParameter("@4", usuario.user_phone));
                        cmd.Parameters.Add(new SqlParameter("@5", usuario.user_first_name));
                        cmd.Parameters.Add(new SqlParameter("@6", usuario.user_last_name));
                        cmd.ExecuteReader();
                        con.Close();
                        return "Usuário criado com sucesso";
                    }
                }
            }
            catch (Exception ex) {
                return "Erro: Falha ao criar usuário";
            }
        }
    }
}
