using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_Crud.Models
{
    public class UserModel
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_password { get; set; }
        public string user_email { get; set; }
        public string user_phone { get; set; }
        public string user_first_name { get; set; }
        public string user_last_name { get; set; }
    }
}
