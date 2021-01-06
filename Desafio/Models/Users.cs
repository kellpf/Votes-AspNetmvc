using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Desafio.Models
{
    [DataContract]
    public class Users : BaseModel
    {
        public Users(int id_user, string user)
        {
            this.Id_user = id_user;
            this.User_name = user;
        }

        [DataMember]
        public int Id_user { get; set; }
        [DataMember]
        public string User_name { get; set; }

    }
}
